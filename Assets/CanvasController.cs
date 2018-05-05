using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasController : MonoBehaviour {

    public Text player1HealthText;
    public Text player2HealthText;
    public PlayerController player1Controller;
    public PlayerController player2Controller;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        player1HealthText.text = "Player 1 Health\n" + player1Controller.health;
        //TODO uncomment when player 2 is added
        //player2HealthText.text = "Player 2 Health\n" + player2Controller.health;
    }
}
