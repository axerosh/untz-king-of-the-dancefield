using System.Collections;
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

        for (int i = 0; i < this.players.Length; ++i)
        {
            cards[i] = this.playerQs[i].Dequeue();

            players[i].move(cards[i].movePoint.x, cards[i].movePoint.y);
        }
    }

    // Update is called once per frame
    void Update () {
        
        accumulatedTimeSinceUpdate += Time.deltaTime;

        // New tick
        if (accumulatedTimeSinceUpdate > TICK_TIME)
        {
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

                        uiText.text = "";
                    }
                    break;
                case GameState.ACTING_OUT_MOVES:
                    executeCard();
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

    void updateCardSprites()
    {
        for(int i = 0; i < cardControllers.Length; i++)
        {
            cardControllers[i].setDanceCard(cardsToChoose[i]);
        }
    }
}