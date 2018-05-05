using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DanceCards;

public class GameMaster : MonoBehaviour {

    public PlayerController[] players = new PlayerController[1];
    enum GameState { STARTING_GAME, PICKING_CARD, ACTING_OUT_MOVES, GAME_END, GENERATE_CARDS };

    GameState gameState;
    float time;
    float deltaTime;
    float accumulatedTimeSinceUpdate;
    int UPDATES_PER_SECOND = 60;
    DanceCard [] cardsToChoose = new DanceCard [6];
    Random rnd;

    // Use this for initialization
    void Start () {
        gameState = GameState.STARTING_GAME;
        time = Time.time;
        deltaTime = 0;
        accumulatedTimeSinceUpdate = 0;
        rnd = new Random();

    }
	
	// Update is called once per frame
	void Update () {
        deltaTime = Time.time - time;
        time = Time.time;
        accumulatedTimeSinceUpdate += deltaTime;

        if(accumulatedTimeSinceUpdate > 1 / UPDATES_PER_SECOND)
        {
            accumulatedTimeSinceUpdate = 0;
            switch (gameState)
            {
                case GameState.STARTING_GAME:
                    break;
                case GameState.GENERATE_CARDS:
                    
                case GameState.PICKING_CARD:
                    break;
                case GameState.ACTING_OUT_MOVES:
                    break;
                case GameState.GAME_END:
                    break;

            }
        }
	}


    void generateNewCards()
    {
        for(int i = 0; i < cardsToChoose.Length; i++)
        {
            float number = Random.Range(0, 1);

            if(number < 0.30f)
            {
                
            }
            else if(number < 0.60f)
            {

            }
            else if(number < 0.70f)
            {

            }
        }
    }
}
