﻿using UnityEngine;
using System.Collections;
using System;

public class NetworkSnakeController : MonoBehaviour, IController {

    private SnakeState snakeState;


    public Component getControllerComponent()
    {
        return this;
    }
    void Awake()
    {
        this.snakeState = this.GetComponent<SnakeState>();
        this.snakeState.head.AddComponent<NetworkSnakeHeadController>().snakeState = this.snakeState;
    }

    public Vector3 GetDesiredMove()
    {
        return (Input.mousePosition - new Vector3(Screen.width, Screen.height, 0.0f) * 0.5f);
    }

    void OnDestroy()
    {
        Destroy(this.snakeState.head.GetComponent<NetworkSnakeHeadController>());
    }

    public void ReplicateSnakeState(slyther.flatbuffers.SnakeState fSnakeState)
    {
        this.snakeState.head.transform.position = new Vector3(fSnakeState.GetParts(fSnakeState.Head).Position.X, fSnakeState.GetParts(fSnakeState.Head).Position.Y, 0.0f);
        this.snakeState.snakeSkinID = 1;//int.Parse(snakeState.Skin);
        this.snakeState.name = fSnakeState.Name;
        this.snakeState.score = (int)fSnakeState.Score;
    }

}
