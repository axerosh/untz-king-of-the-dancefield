using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour {

    public PlayerController[] players = new PlayerController[1];
    enum GameState { STARTING_GAME, PICKING_CARD, ACTING_OUT_MOVES, GAME_END, GENERATE_CARDS };

    GameState gameState;
    float time;
    float deltaTime;
    float accumulatedTimeSinceUpdate;
    float TICK_TIME = 0.8f; // seconds
    DanceCard [] cardsToChoose = new DanceCard [6];
    Random rnd;

    public int playerC = 2;
    private int maxMoves = 2;
    private Queue<DanceCard>[] playerQs;

    void selectCard(int cardI, int playerI)
    {
        if(this.gameState != GameState.PICKING_CARD)
        {
            return;
        }

        Queue<DanceCard> curQ = this.playerQs[playerI];
        curQ.Enqueue(cardsToChoose[cardI]);

        if (curQ.Count > maxMoves)
        {
            curQ.Dequeue();
        }
    }

    // Use this for initialization
    void Start () {
        gameState = GameState.GENERATE_CARDS;
        time = Time.time;
        deltaTime = 0;
        accumulatedTimeSinceUpdate = 0;
        rnd = new Random();

        playerQs = new Queue<DanceCard>[playerC];
        for (int i = 0; i < playerC; i++)
        {
            playerQs[i] = new Queue<DanceCard>();
        }
    }
	
	// Update is called once per frame
	void Update () {
        deltaTime = Time.time - time;
        time = Time.time;
        accumulatedTimeSinceUpdate += deltaTime;

        // New tick
        if(accumulatedTimeSinceUpdate > TICK_TIME)
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
            foreach (Transform row in transform)
            {
                foreach (Transform plate in row)
                {
                    PlateChangeColor colorChanger = (PlateChangeColor)plate.gameObject.GetComponent(typeof(PlateChangeColor));
                    colorChanger.ChangeToRandomColor();
                }
            }
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
