using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputTest : MonoBehaviour {

	// Use this for initialization
	void Start () {
        	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButton("p1_0"))
        {
            Debug.Log("AXEEEL");
        }
    }
}
