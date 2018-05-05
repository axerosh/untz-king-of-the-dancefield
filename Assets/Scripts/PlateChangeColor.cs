using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateChangeColor : MonoBehaviour
{

    public Texture[] textures = new Texture[9];

    private Material material;

    // Use this for initialization
    void Start()
    {
        //Fetch the Material from the Renderer of the GameObject
        material = GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ChangeToRandomColor()
    {
        material.SetTexture("_MainTex", textures[Random.Range(0, textures.Length)]);
    }
}
