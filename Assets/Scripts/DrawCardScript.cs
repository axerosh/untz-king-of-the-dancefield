using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawCardScript : MonoBehaviour {

    public DanceCard danceCard;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void updateCard(DanceCard newDanceCard)
    {
        danceCard = newDanceCard;
    }
}
