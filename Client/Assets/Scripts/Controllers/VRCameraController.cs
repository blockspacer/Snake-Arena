﻿using UnityEngine;
using System.Collections;

public class VRCameraController : MonoBehaviour {
    public const float SCALE_FACTOR = 20.0f;
    public SnakeState snakeToTrack = null;
    public float LerpAmount = 0.1f;
    private GameWorld gameWorld;
    private Vector3 targetPosition;

    void Start()
    {
        this.gameWorld = GameObject.FindGameObjectWithTag("World").GetComponent<GameWorld>();
    }

    void Update()
    {
        FollowSnake();
        CalculateFarPlane();
    }

    void FollowSnake()
    {
        GameObject snake = GameObject.FindGameObjectWithTag("Player");
        if (snake)
        {
            snakeToTrack = snake.GetComponent<SnakeState>();
            this.targetPosition = snakeToTrack.transform.position;
            this.targetPosition += Vector3.back * SCALE_FACTOR * snakeToTrack.GetSnakeThickness();
            transform.position = Vector3.Lerp(this.transform.position, targetPosition, LerpAmount);
        }
        else
            snakeToTrack = null;
    }

    void CalculateFarPlane()
    {
        if (snakeToTrack)
        {
            Vector3 farPoint = this.snakeToTrack.transform.position + this.snakeToTrack.SnakeFogDistance() * Vector3.up;
            Vector3 nearPoint = this.targetPosition;
            Camera.main.farClipPlane = (nearPoint - farPoint).magnitude * 1.1f;
        }
    }
}
