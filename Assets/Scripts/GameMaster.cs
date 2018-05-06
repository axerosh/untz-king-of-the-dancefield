using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameMaster : MonoBehaviour {

    public int SELECT_TICKS = 15;
    public float VICTORY_TIME = 5;

    public PlayerController[] players = new PlayerController[1];
    enum GameState { STARTING_GAME, PICKING_CARD, ACTING_OUT_MOVES, GAME_END, GENERATE_CARDS };

    public TextMesh countdownLabel;

    public CardController[] playerOnePickedCardIndicator = new CardController[2];
    public CardController[] playerTwoPickedCardIndicator = new CardController[2];
    public JukeboxController jukebox;

    GameState gameState;
    float accumulatedTimeSinceUpdate;
    float TICK_TIME = 0.4f; // seconds
    DanceCard [] cardsToChoose = new DanceCard [6];
    public CardController[] cardControllers = new CardController[6];
    Random rnd;

    public int ticksPerMove = 2;
    public int halfMoveTicks = 1;

    public GameObject keyboardLabels;

    private int curMoves;

    private int maxMoves = 2;
    private Queue<DanceCard>[] playerQs;

    private int curTicks;

    private DanceCard[] lastCards;

    public CanvasController canvasCont;

    public void selectCard(int cardI, int playerI)
    {
        if(this.gameState != GameState.PICKING_CARD)
        {
            return;
        }

        Queue<DanceCard> curQ = this.playerQs[playerI];

        // Can not select same card two times
        if (curQ.Contains(cardsToChoose[cardI])
            &&
            !((curQ.Count == maxMoves) && (curQ.Peek() == cardsToChoose[cardI]))
            )
        {
            return;
        }

        curQ.Enqueue(cardsToChoose[cardI]);

        if (curQ.Count > maxMoves)
        {
            curQ.Dequeue();   
        }

        this.updateSelected();
    }

    void updateSelected()
    {
        if (this.playerQs[0].Count == 1)
        {
            playerOnePickedCardIndicator[0].setPicked(true);
            playerOnePickedCardIndicator[1].setPicked(false);
        }
        else if (this.playerQs[0].Count == 2)
        {
            playerOnePickedCardIndicator[0].setPicked(true);
            playerOnePickedCardIndicator[1].setPicked(true);
        }
        else
        {
            playerOnePickedCardIndicator[0].setPicked(false);
            playerOnePickedCardIndicator[1].setPicked(false);
        }
        
        if (this.playerQs[1].Count == 1)
        {
            playerTwoPickedCardIndicator[0].setPicked(true);
            playerTwoPickedCardIndicator[1].setPicked(false);
        }
        else if (this.playerQs[1].Count == 2)
        {
            playerTwoPickedCardIndicator[0].setPicked(true);
            playerTwoPickedCardIndicator[1].setPicked(true);
        }
        else
        {
            playerTwoPickedCardIndicator[0].setPicked(false);
            playerTwoPickedCardIndicator[1].setPicked(false);
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
        keyboardLabels.SetActive(false);
    }

    void executeCard()
    {
        DanceCard[] cards = new DanceCard[this.players.Length];

        // Move & pop cards
        for (int i = 0; i < this.players.Length; ++i)
        {
            if (this.playerQs[i].Count > 0)
            {
                cards[i] = this.playerQs[i].Dequeue();

                // actual move
                players[i].move(cards[i].movePoint.x, cards[i].movePoint.y);

                // Set animation
                players[i].setAnimation(cards[i].anim);
            }
            else
            {
                // If no card go back to idle
                players[i].setAnimation(DanceAnim.IDLE);
            }
        }

        this.updateSelected();

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
                            players[k].setRed(true);
                            players[k].damage((int)curCard.damage);
                        }
                    }
                }
            }
        }

        this.lastCards = cards;
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
                    jukebox.changeTrack();
                    generateNewCards();
                    updateCardSprites();
                    gameState = GameState.PICKING_CARD;
                    curTicks = SELECT_TICKS;
                    countdownLabel.text = this.curTicks.ToString();
                    playerOnePickedCardIndicator[0].setPicked(false);
                    playerOnePickedCardIndicator[1].setPicked(false);
                    playerTwoPickedCardIndicator[0].setPicked(false);
                    playerTwoPickedCardIndicator[1].setPicked(false);
                    break;
                case GameState.PICKING_CARD:
                    this.curTicks -= 1;
                    countdownLabel.text = this.curTicks.ToString();

                    if (this.curTicks <= 0)
                    {
                        this.gameState = GameState.ACTING_OUT_MOVES;

                        countdownLabel.text = "";
                        this.curTicks = 1;
                        this.curMoves = maxMoves + 1;

                        this.hideCardSprites();
                    }
                    break;
                case GameState.ACTING_OUT_MOVES:
                    this.curTicks -= 1;

                    // Sort of inbetween two moves
                    if (this.curTicks == (ticksPerMove-halfMoveTicks))
                    {
                        // Check collisions
                        // Handle collisions
                        for (int i = 0; i < this.players.Length; ++i)
                        {
                            for (int j = 0; j < this.players.Length; ++j)
                            {
                                if ((i != j) && (players[i].x == players[j].x) && (players[i].y == players[j].y))
                                {
                                    if (this.lastCards[i] != null)
                                    {
                                        int backDeltaX = -this.lastCards[i].movePoint.x / Mathf.Max(Mathf.Abs(lastCards[i].movePoint.x), 1);
                                        int backDeltaY = -this.lastCards[i].movePoint.y / Mathf.Max(Mathf.Abs(lastCards[i].movePoint.y), 1);
                                        players[i].move(backDeltaX, backDeltaY);
                                    }

                                    if (this.lastCards[j] != null)
                                    {
                                        int backDeltaX = -this.lastCards[j].movePoint.x / Mathf.Max(Mathf.Abs(lastCards[j].movePoint.x), 1);
                                        int backDeltaY = -this.lastCards[j].movePoint.y / Mathf.Max(Mathf.Abs(lastCards[j].movePoint.y), 1);
                                        players[j].move(backDeltaX, backDeltaY);
                                    }
                                }
                            }
                        }
                    }

                    if (this.curTicks <= 0)
                    {
                        this.curMoves -= 1;

                        // Reset everybodys color
                        for (int i = 0; i < this.players.Length; ++i)
                        {
                            this.players[i].setRed(false);
                        }

                        if (this.curMoves <= 0)
                        {
                            // Go back

                            // Back to idle animation
                            for (int i = 0; i < this.players.Length; ++i)
                            {
                                this.players[i].setAnimation(DanceAnim.IDLE);
                            }

                            this.gameState = GameState.GENERATE_CARDS;
                        }
                        else
                        {
                            //Execute 
                            executeCard();
                            this.curTicks = ticksPerMove;
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

    public void win(int playerId)
    {
        this.canvasCont.showWinText(playerId);
        this.players[playerId].setAnimation(DanceAnim.SPIN);

        this.gameState = GameState.GAME_END;
        Invoke("restartGame", this.VICTORY_TIME);
    }

    private void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void generateNewCards()
    {
        for(int i = 0; i < cardsToChoose.Length; i++)
        {
            float number = Random.Range(0, 101);

            if(number < 20)
            {
                cardsToChoose[i] = new MoveLeftCard();
            }
            else if(number < 40)
            {
                cardsToChoose[i] = new MoveRightCard();
            }
            else if(number < 50)
            {
                cardsToChoose[i] = new MoveUpCard();
            }
            else if(number < 60)
            {
                cardsToChoose[i] = new MoveDownCard();
            }
            else if (number < 70)
            {
                cardsToChoose[i] = new AttackLeftCard();
            }
            else if (number < 80)
            {
                cardsToChoose[i] = new AttackRightCard();
            }
            else if (number < 85)
            {
                cardsToChoose[i] = new AttackMoveLeftCard();
            }
            else if (number < 90)
            {
                cardsToChoose[i] = new AttackMoveRightCard();
            }
            else if (number <= 100)
            {
                cardsToChoose[i] = new AttackAllCard();
            }
        }
    }

    void hideCardSprites()
    {
        for (int i = 0; i < cardControllers.Length; i++)
        {
            cardControllers[i].setPicked(false);
        }
        keyboardLabels.SetActive(false);
    }

    void updateCardSprites()
    {
        for(int i = 0; i < cardControllers.Length; i++)
        {
            cardControllers[i].setDanceCard(cardsToChoose[i]);
        }

        keyboardLabels.SetActive(true);
    }
}