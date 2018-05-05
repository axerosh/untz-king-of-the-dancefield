using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardController : MonoBehaviour {

    public DanceCard danceCard;
    public Sprite[] sprites = new Sprite[1];


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void setDanceCard(DanceCard newDanceCard)
    {
        //0. Up
        //1. Right
        //2. Left
        //3. Down
        //4. Attack_Right
        //5. Attack_Up
        //6. Attack_Left
        //7. Attack_Down
        //8. Attack_Move_Left
        //9. Attack_Move_Right
        //10. Attack_All



        this.danceCard = newDanceCard;
        if (newDanceCard is MoveUpCard)
        {
            GetComponent<SpriteRenderer>().sprite = sprites[0];
        }
        else if(newDanceCard is MoveRightCard)
        {
            GetComponent<SpriteRenderer>().sprite = sprites[1];
        }
        else if (newDanceCard is MoveLeftCard)
        {
            GetComponent<SpriteRenderer>().sprite = sprites[2];
        }
        else if (newDanceCard is MoveDownCard)
        {
            GetComponent<SpriteRenderer>().sprite = sprites[3];
        }
        else if (newDanceCard is AttackRightCard)
        {
            GetComponent<SpriteRenderer>().sprite = sprites[4];
        }
        else if (newDanceCard is AttackUpCard)
        {
            GetComponent<SpriteRenderer>().sprite = sprites[5];
        }
        else if (newDanceCard is AttackLeftCard)
        {
            GetComponent<SpriteRenderer>().sprite = sprites[6];
        }
        else if (newDanceCard is AttackDownCard)
        {
            GetComponent<SpriteRenderer>().sprite = sprites[7];
        }
        else if (newDanceCard is AttackMoveLeftCard)
        {
            GetComponent<SpriteRenderer>().sprite = sprites[8];
        }
        else if (newDanceCard is AttackMoveRightCard)
        {
            GetComponent<SpriteRenderer>().sprite = sprites[9];
        }
        else if (newDanceCard is AttackAllCard)
        {
            GetComponent<SpriteRenderer>().sprite = sprites[10];
        }
    }
}
