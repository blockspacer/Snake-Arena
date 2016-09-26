﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using slyther.flatbuffers;

public class SnakeState : MonoBehaviour {

    public GameObject head;

    public float speedFactor;

    public int snakeSkinID;
    public int score;
    public string name;

    public static int MAX_BACKBONE_POINTS = 5000;
    public static int GROWTH_CAP = 40000;
    public static float MIN_LENGTH = 1.0f;
    public static float MIN_THICKNESS = 0.2f;
    public static float GROWTH_RATE = 1.0f / 100.0f;
    
    private Vector2[] backbone;
    private int backboneStartIdx;
    private int backboneLength;

    // Use this for initialization
    void Start() {
        // Default backbone
        this.InitBackbone();
        this.AddBackboneHeadPoint(new Vector2(0.0f, 0.0f));
        this.AddBackboneHeadPoint(new Vector2(0.0f, 1.0f));
        this.AddBackboneHeadPoint(new Vector2(0.0f, 2.0f));
    }

    void Update()
    {
        //transform.position = GetBackbonePoint(he); //transform.position;
    }

    private void InitBackbone()
    {
        this.backbone = new Vector2[MAX_BACKBONE_POINTS];
        this.backboneStartIdx = 0;
        this.backboneLength = 0;
    }

    public Bounds LocalBounds()
    {
        Bounds b = new Bounds();
        float radius = GetSnakeThickness() / 2.0f;
        for (int i = 0; i < GetBackboneLength(); i++)
        {
            Vector2 pt = GetBackbonePoint(i);
            b.Encapsulate(transform.InverseTransformPoint(pt + new Vector2(radius, radius)));
            b.Encapsulate(transform.InverseTransformPoint(pt + new Vector2(-radius, radius)));
            b.Encapsulate(transform.InverseTransformPoint(pt + new Vector2(radius, -radius)));
            b.Encapsulate(transform.InverseTransformPoint(pt + new Vector2(-radius, -radius)));
        }

        return b;
    }

    private void TrimBackbone()
    {
        if (this.backboneLength <= 10)
            return;

        float accDistance = 0.0f;
        Vector3 prev = this.GetBackbonePoint(0);
        int i;
        for (i = 1; i < this.backboneLength; i++)
        {
            Vector3 curr = this.GetBackbonePoint(i);
            Vector3 segmentVector = curr - prev;
            float segmentMagnitude = segmentVector.magnitude;
            accDistance += segmentMagnitude;
            if (accDistance > this.GetSnakeLength())
                break;
            prev = curr;
        }

        this.backboneLength = i + 1;
    }

    public void AddBackboneHeadPoint(Vector2 point)
    {
        if (backboneLength >= MAX_BACKBONE_POINTS - 1)
        {
            Debug.LogError("Backbone point maximum exceeded.");
            return;
        }
        backboneStartIdx = backboneStartIdx - 1;
        if (backboneStartIdx < 0) backboneStartIdx = MAX_BACKBONE_POINTS - 1;
        backbone[backboneStartIdx] = point;
        backboneLength++;
        
        TrimBackbone();
    }

    public void ReplicateState(NetworkSnakeState state)
    {
        NetworkSnakePartState snakePartState = new NetworkSnakePartState();
        this.backboneStartIdx = state.Head;
        
        if (state.Tail < state.Head)
        {
            this.backboneLength = state.Tail + MAX_BACKBONE_POINTS - state.Head;
        }
        else
        {
            this.backboneLength = state.Tail - state.Head;
        }
        
        for (int i = 0; i < state.PartsLength; i++)
        {
            state.GetParts(snakePartState, i);
            this.backbone[snakePartState.Index] = new Vector2(snakePartState.Position.X, snakePartState.Position.Y);
        }
    }

    public void UpdateBackboneHeadPoint(Vector2 point)
    {
        this.backbone[this.backboneStartIdx] = point;
    }

    public int GetBackboneLength()
    {
        return this.backboneLength;
    }

    public Vector2[] GetRawBackboneArray()
    {
        return this.backbone;
    }

    public int GetRawBackboneStartIdx()
    {
        return this.backboneStartIdx;
    }

    public Vector2 GetBackbonePoint(int idx)
    {
        return this.backbone[(backboneStartIdx + idx) % MAX_BACKBONE_POINTS];
    }

    public Vector2 GetLocalBackbonePoint(int idx)
    {
        return GetBackbonePoint(idx) - (Vector2) transform.position;
    }

    public Vector3 CalcBackboneParametizedPosition(float distance)
    {
        if (this.backboneLength == 0)
            return Vector3.zero;

        float accDistance = 0.0f;
        Vector3 prev = this.GetBackbonePoint(0);
        for (int i = 0; i < this.backboneLength; i++)
        {
            Vector3 curr = this.GetBackbonePoint(i);
            Vector3 segmentVector = curr - prev;
            float segmentMagnitude = segmentVector.magnitude;
            if (accDistance + segmentMagnitude >= distance)
            {
                float t = distance - accDistance;
                return prev + segmentVector.normalized * t;
            }
            else
            {
                accDistance += segmentMagnitude;
            }
            prev = curr;
        }
        return Vector3.zero;
    }

    public float CappedScore()
    {
        return Mathf.Min(GROWTH_CAP, this.score);
    }

    public float GetSnakeLength()
    {
        return MIN_LENGTH + GROWTH_RATE * CappedScore();
    }

    public float GetSnakeThickness()
    {
        return MIN_THICKNESS + GROWTH_RATE * Mathf.Sqrt(CappedScore());
    }

    public float MaxSnakeLength()
    {
        return MIN_LENGTH + GROWTH_RATE * GROWTH_CAP;
    }
}
