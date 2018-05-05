﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour {

    public PlayerController[] players = new PlayerController[1];
    enum GameState { STARTING_GAME, PICKING_CARD, ACTING_OUT_MOVES, GAME_END };

    GameState gameState;
    float time;
    float deltaTime;
    float accumulatedTimeSinceUpdate;
    int UPDATES_PER_SECOND = 60;

	// Use this for initialization
	void Start () {
        gameState = GameState.STARTING_GAME;
        time = Time.time;
        deltaTime = 0;
        accumulatedTimeSinceUpdate = 0;
	}
	
	// Update is called once per frame
	void Update () {
        deltaTime = Time.time - time;
        time = Time.time;
        accumulatedTimeSinceUpdate += deltaTime;

        if(accumulatedTimeSinceUpdate > 1 / UPDATES_PER_SECOND)
        {
            switch (gameState)
            {
                case GameState.STARTING_GAME:
                    break;
                case GameState.PICKING_CARD:
                    break;
                case GameState.ACTING_OUT_MOVES:
                    break;
                case GameState.GAME_END:
                    break;

            }
        }
	}
}
