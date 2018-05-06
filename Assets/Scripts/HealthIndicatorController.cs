using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthIndicatorController : MonoBehaviour {

    public PlayerController player;
    public SpriteRenderer[] hearts = new SpriteRenderer[5];

    // Use this for initialization
    void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {
        // Make remaning hearts visible
        for (int hp_i = 0; hp_i < hearts.Length; ++hp_i)
        {
            hearts[hp_i].enabled = player.health > hp_i;
        }
    }
}
