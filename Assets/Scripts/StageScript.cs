using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageScript : MonoBehaviour {

    public GameObject[] rows = new GameObject[4];

	// Use this for initialization
	void Start () {
		
	}

    public Vector3 getWorldCoords(int x, int y)
    {
        GameObject row = this.rows[y];
        GameObject tile = row.GetComponent<RowScript>().plates[x];

        Vector3 pos = tile.transform.position;
        return pos;
    }

	// Update is called once per frame
	void Update () {
		
	}
}
