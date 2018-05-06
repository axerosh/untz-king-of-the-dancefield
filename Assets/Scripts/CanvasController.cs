using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasController : MonoBehaviour {
 
    public MeshRenderer[] playerWinTexts = new MeshRenderer[2];

    public void showWinText(int playerId)
    {
        this.playerWinTexts[playerId].enabled = true;
    }

    // Use this for initialization
    void Start () {
		
	}
}
