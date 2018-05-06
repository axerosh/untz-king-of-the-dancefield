using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageScript : MonoBehaviour {

    public GameObject[] rows = new GameObject[4];

    private float tileDist;

	// Use this for initialization
	void Start () {
        Transform pos1 = rows[0].GetComponent<RowScript>().plates[0].transform;
        Transform pos2 = rows[0].GetComponent<RowScript>().plates[1].transform;

        this.tileDist = Vector3.Distance(pos1.position, pos2.position);
    }

    public float getTileDist()
    {
        return tileDist;
    }

    public bool insideFloor(int x, int y)
    {
        return (x >= 0) &&
                (y >= 0) &&
                (y < rows.Length) && 
                (x < rows[0].GetComponent<RowScript>().plates.Length);
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
