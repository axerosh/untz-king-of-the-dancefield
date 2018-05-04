using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public string[] inputNames;

	// Use this for initialization
	void Start () {
        	
	}
	
    void selectCard(int i)
    {
        Debug.Log("Selcted card");
        Debug.Log(i);
    }

	// Update is called once per frame
	void Update () {
        for(int i = 0; i < 4; ++i)
        {
            if (Input.GetButton(inputNames[i]))
            {
                this.selectCard(i);
            }
        }
    }
}
