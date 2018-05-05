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
        this.danceCard = newDanceCard;
        GetComponent<SpriteRenderer>().sprite = sprites[0];
    }
}
