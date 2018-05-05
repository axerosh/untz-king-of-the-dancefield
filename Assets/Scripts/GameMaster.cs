using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;

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
    GameObject stage;

    // Use this for initialization
    void Start () {
        gameState = GameState.GENERATE_CARDS;
        time = Time.time;
        deltaTime = 0;
        accumulatedTimeSinceUpdate = 0;
        rnd = new Random();
        stage = GameObject.Find("Stage");
    }
	
	// Update is called once per frame
	void Update () {
        deltaTime = Time.time - time;
        time = Time.time;
        accumulatedTimeSinceUpdate += deltaTime;

        // New tick
        if(accumulatedTimeSinceUpdate > 1 / UPDATES_PER_SECOND)
        {
            accumulatedTimeSinceUpdate = 0;
            switch (gameState)
            {
                case GameState.STARTING_GAME:
                    break;
                case GameState.GENERATE_CARDS:
                    generateNewCards();
                    gameState = GameState.PICKING_CARD;
                    break;
                case GameState.PICKING_CARD:                   
                    break;
                case GameState.ACTING_OUT_MOVES:
                    break;
                case GameState.GAME_END:
                    break;

            }

            // Change color of plates
        }
	}


    void generateNewCards()
    {
        for(int i = 0; i < cardsToChoose.Length; i++)
        {
            float number = Random.Range(0, 100);

            if(number < 30)
            {
                cardsToChoose[i] = new MoveLeftCard();
            }
            else if(number < 60)
            {
                cardsToChoose[i] = new MoveRightCard();
            }
            else if(number < 70)
            {
                cardsToChoose[i] = new MoveUpCard();
            }
            else if(number < 80)
            {
                cardsToChoose[i] = new MoveDownCard();
            }
            else if (number <= 100)
            {
                cardsToChoose[i] = new MilkTheCowLeftCard();
            }
        }
    }
}
