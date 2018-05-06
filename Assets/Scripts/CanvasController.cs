using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasController : MonoBehaviour {
 
    public Text[] playerWinTexts = new Text[2];

    public void showWinText(int playerId)
    {
        this.playerWinTexts[playerId].enabled = true;
    }

    // Use this for initialization
    void Start () {
		
	}
}
