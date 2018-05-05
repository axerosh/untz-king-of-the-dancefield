using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageBuilder : MonoBehaviour
{
    public GameObject plateType;

    public int w;
    public int h;
    private List<List<GameObject>> plates = new List<List<GameObject>>();

    // Use this for initialization
    void Start () {

        float originX = - w / 2.0f + 0.5f;
        float originZ = - h / 2.0f + 0.5f;

        for (int x = 0; x < w; x++)
        {
            plates.Add(new List<GameObject>());
            for (int z = 0; z < h; z++)
            {
                plates[x].Add(Instantiate(plateType));
                plates[x][z].transform.position = new Vector3(originX + x, -0.25f, originZ + z);
                plates[x][z].transform.parent = transform;
            }
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
