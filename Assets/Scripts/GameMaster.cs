﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMaster : MonoBehaviour {

    public int SELECT_TICKS = 10;

    public PlayerController[] players = new PlayerController[1];
    enum GameState { STARTING_GAME, PICKING_CARD, ACTING_OUT_MOVES, GAME_END, GENERATE_CARDS };

    public Text uiText;

    GameState gameState;
    float accumulatedTimeSinceUpdate;
    float TICK_TIME = 0.8f; // seconds
    DanceCard [] cardsToChoose = new DanceCard [6];
    public CardController[] cardControllers = new CardController[6];
    Random rnd;

    public int ticksPerMove = 4;
    private int curMoves;

    private int maxMoves = 2;
    private Queue<DanceCard>[] playerQs;

    private int curTicks;

    public void selectCard(int cardI, int playerI)
    {
        if(this.gameState != GameState.PICKING_CARD)
        {
            return;
        }

        Queue<DanceCard> curQ = this.playerQs[playerI];
        
        // Can not select same card two times
        if ((curQ.Count > 0) && 
            (curQ.Peek() != cardsToChoose[cardI]) 
            &&
            (curQ.Count == maxMoves)
            &&
            curQ.Contains(cardsToChoose[cardI]) 
            )
        {
            return;
        }

        curQ.Enqueue(cardsToChoose[cardI]);

        if (curQ.Count > maxMoves)
        {
            curQ.Dequeue();   
        }
    }

    // Use this for initialization
    void Start () {
        gameState = GameState.GENERATE_CARDS;
        accumulatedTimeSinceUpdate = 0;
        rnd = new Random();

        playerQs = new Queue<DanceCard>[this.players.Length];
        for (int i = 0; i < this.players.Length; i++)
        {
            playerQs[i] = new Queue<DanceCard>();
        }

        updatePlateColors();
    }

    void executeCard()
    {
        DanceCard[] cards = new DanceCard[this.players.Length];

        // Move
        for (int i = 0; i < this.players.Length; ++i)
        {
            if (this.playerQs[i].Count > 0)
            {
                cards[i] = this.playerQs[i].Dequeue();

                players[i].move(cards[i].movePoint.x, cards[i].movePoint.y);
            }
        }

        // Handle collisions
        for (int i = 0; i < this.players.Length; ++i)
        {
            for (int j = 0; j < this.players.Length; ++j)
            {
                if ((i != j) && (players[i].x == players[j].x) && (players[i].y == players[j].y))
                {
                    if (cards[i] != null)
                    {
                        players[i].move(-cards[i].movePoint.x, -cards[i].movePoint.y);
                    }

                    if (cards[j] != null)
                    {
                        players[j].move(-cards[j].movePoint.x, -cards[j].movePoint.y);
                    }
                }
            }
        }

        //Attack
        for (int i = 0; i < this.players.Length; ++i)
        {
            DanceCard curCard = cards[i];

            if (curCard != null)
            {
                for (int j = 0; j < curCard.damagePoints.Length; ++j)
                {
                    int dmgX = players[i].x + curCard.damagePoints[j].x;
                    int dmgY = players[i].y + curCard.damagePoints[j].y;

                    for (int k = 0; k < this.players.Length; ++k)
                    {
                        if ((players[k].x == dmgX) && (players[k].y == dmgY))
                        {
                            players[k].damage((int)curCard.damage);
                        }
                    }
                }
            }
        }
    }

    // Update is called once per frame
    void Update () {
        accumulatedTimeSinceUpdate += Time.deltaTime;

        // New tick
        if (accumulatedTimeSinceUpdate > TICK_TIME)
        {
            Debug.Log(this.gameState);

            accumulatedTimeSinceUpdate = 0;
            switch (gameState)
            {
                case GameState.STARTING_GAME:
                    break;
                case GameState.GENERATE_CARDS:
                    generateNewCards();
                    updateCardSprites();
                    gameState = GameState.PICKING_CARD;
                    curTicks = SELECT_TICKS;
                    uiText.text = this.curTicks.ToString();
                    break;
                case GameState.PICKING_CARD:
                    this.curTicks -= 1;
                    uiText.text = this.curTicks.ToString();

                    if (this.curTicks <= 0)
                    {
                        this.gameState = GameState.ACTING_OUT_MOVES;

                        this.uiText.text = "";
                        this.curTicks = 1;
                        this.curMoves = 2;
                    }
                    break;
                case GameState.ACTING_OUT_MOVES:
                    this.curTicks -= 1;

                    if (this.curTicks <= 0)
                    {
                        executeCard();
                        this.curMoves -= 1;

                        if (this.curMoves <= 0)
                        {
                            this.gameState = GameState.GENERATE_CARDS;
                        }
                    }
                    break;
                case GameState.GAME_END:
                    break;

            }
            
            updatePlateColors();
        }
	}

    void updatePlateColors()
    {
        foreach (Transform row in transform)
        {
            foreach (Transform plate in row)
            {
                PlateChangeColor colorChanger = (PlateChangeColor)plate.gameObject.GetComponent(typeof(PlateChangeColor));
                colorChanger.ChangeToRandomColor();
            }
        }
    }

    void generateNewCards()
    {
        for(int i = 0; i < cardsToChoose.Length; i++)
        {
            float number = Random.Range(0, 101);

            if(number < 25)
            {
                cardsToChoose[i] = new MoveLeftCard();
            }
            else if(number < 50)
            {
                cardsToChoose[i] = new MoveRightCard();
            }
            else if(number < 58)
            {
                cardsToChoose[i] = new MoveUpCard();
            }
            else if(number < 65)
            {
                cardsToChoose[i] = new MoveDownCard();
            }
            else if (number < 70)
            {
                cardsToChoose[i] = new AttackDownCard();
            }
            else if (number < 75)
            {
                cardsToChoose[i] = new AttackUpCard();
            }
            else if (number < 80)
            {
                cardsToChoose[i] = new AttackLeftCard();
            }
            else if (number < 85)
            {
                cardsToChoose[i] = new AttackRightCard();
            }
            else if (number < 90)
            {
                cardsToChoose[i] = new AttackMoveLeftCard();
            }
            else if (number < 95)
            {
                cardsToChoose[i] = new AttackMoveRightCard();
            }
            else if (number <= 100)
            {
                cardsToChoose[i] = new AttackAllCard();
            }
        }
    }

    void updateCardSprites()
    {
        for(int i = 0; i < cardControllers.Length; i++)
        {
            cardControllers[i].setDanceCard(cardsToChoose[i]);
        }
    }
}