﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class SnakeMeshGenerator : MonoBehaviour {
    public Texture snakeSkin;
	public SnakeState snake;
	public MeshFilter meshFilter;
	public MeshRenderer meshRenderer;

    public float snakeRadius;
    public float snakeVertexDensity = 3.0f;
    public float snakeLength;
    public float snakeTailStartLength;

    public bool modelMatrixEnabled = false;

    private Texture2D backboneEncTex;
    private int backboneEncTexDim;

    private int backboneVertsLength;

    private void EncodeBackboneTexPoint(int i, Vector2 point)
    {
        int x = i % this.backboneEncTexDim;
        int y = i / this.backboneEncTexDim;
        this.backboneEncTex.SetPixel(x, y, new Color(point.x, point.y, 0.0f, 0.0f));
    }

    private void FlushBackboneTex()
    {
        this.backboneEncTex.Apply();
    }

	// Use this for initialization
	void Awake () {
        this.backboneVertsLength = (int)(this.snake.MaxSnakeLength() * this.snakeVertexDensity / this.snake.MaxSnakeThickness()) + 1;
        CalcParameters();

        this.meshFilter.mesh = this.generateBackboneMesh();
        if (modelMatrixEnabled)
            this.meshRenderer.material.shader = Shader.Find("Unlit/SnakeGenShaderM");
        else
            this.meshRenderer.material.shader = Shader.Find("Unlit/SnakeGenShader");

        // Tex dimension is nearest power of two of the square root of the maximum number of backbone points
        this.backboneEncTexDim = (int)Mathf.Pow(2, ((int)Mathf.Log(Mathf.Sqrt((float)SnakeState.MAX_BACKBONE_POINTS) + 1.0f, 2.0f) + 1));
        this.backboneEncTex = new Texture2D(this.backboneEncTexDim, this.backboneEncTexDim, TextureFormat.RGBAFloat, false);
        this.backboneEncTex.filterMode = FilterMode.Point;
        this.backboneEncTex.anisoLevel = 1;
        for (int i = 0; i < SnakeState.MAX_BACKBONE_POINTS; i++)
            this.EncodeBackboneTexPoint(i, new Vector2(0.0f, 0.0f));
        this.backboneEncTex.Apply();
    }

    private Mesh generateBackboneMesh()
    {
        Mesh bbMesh = new Mesh();
        
        Vector3[] vertices = new Vector3[backboneVertsLength * 2];
        int[] triangles = new int[(backboneVertsLength - 1) * 6];

       // Debug.Log(backboneVertsLength);

        // Generate vertices
        // Head section should have higher density
        float distance = 0.0f;
        float distanceDelta = 1.0f / this.snakeVertexDensity;
        for (int i = 0; i < backboneVertsLength; i++)
        {
            vertices[i * 2].x = distance;
            vertices[i * 2].y = -1;
            vertices[i * 2].z = 1.0f;
            vertices[i * 2 + 1].x = distance;
            vertices[i * 2 + 1].y = 1;
            vertices[i * 2 + 1].z = 0.0f;

            distance += (i > 10 ? distanceDelta : distanceDelta / 4.0f);
        }

        // Generate triangle sequence
        for (int i = 0; i < backboneVertsLength - 1; i++)
        {
            triangles[(i * 6) + 0] = (i * 2);
            triangles[(i * 6) + 1] = (i + 1) * 2;
            triangles[(i * 6) + 2] = (i * 2) + 1;
            triangles[(i * 6) + 3] = (i * 2) + 1;
            triangles[(i * 6) + 4] = (i + 1) * 2;
            triangles[(i * 6) + 5] = ((i + 1) * 2) + 1;
        }
        
        bbMesh.vertices = vertices;
        bbMesh.triangles = triangles;
        bbMesh.UploadMeshData(false);

        return bbMesh;
    }

    void OnEnable()
    {
        this.meshRenderer.enabled = true;
    }

    void OnDisable()
    {
        this.meshRenderer.enabled = false;
    }

    private void CalcParameters()
    {
        this.snakeTailStartLength = this.snakeLength - 5.0f;

        this.snakeLength = this.snake.GetSnakeLength();
        this.snakeRadius = this.snake.GetSnakeThickness() / 2.0f;
    }

    void Update ()
    {
        CalcParameters();

        for (int i = 0; i < snake.GetBackboneLength(); i++)
        {
            Vector2 pt = snake.GetBackbonePoint(i);
            this.EncodeBackboneTexPoint(i, pt);
        }

        this.FlushBackboneTex(); // Update backbone texture

        this.meshRenderer.material.SetInt("_BackboneTexDim", this.backboneEncTexDim);
        this.meshRenderer.material.SetTexture("_BackboneTex", this.backboneEncTex);
        this.meshRenderer.material.SetInt("_BackboneLength", this.snake.GetBackboneLength());
        this.meshRenderer.material.SetFloat("_SnakeLength", this.snakeLength);
        this.meshRenderer.material.SetFloat("_SnakeRadius", this.snakeRadius);
        this.meshRenderer.material.SetInt("_SnakeGlowEnabled", this.snake.isTurbo ? 1 : 0);
        this.meshRenderer.material.SetFloat("_SnakeGlowOffset", Time.time * 10.0f);

        this.snakeSkin = Resources.Load<Texture>("SnakeSkin" + this.snake.snakeSkinID);
        this.meshRenderer.material.mainTexture = snakeSkin;
    
        this.meshFilter.mesh.bounds = snake.LocalBounds();
    }
}
