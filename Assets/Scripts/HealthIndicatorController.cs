using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthIndicatorController : MonoBehaviour {

    public PlayerController player;
    public GameObject[] hearts = new GameObject[5];

    private bool[] heartsAlive;
    private ArrayList moveHearts = new ArrayList();

    public float MOVE_SPEED = 10;

    // Use this for initialization
    void Start () {
        this.heartsAlive = new bool[hearts.Length];

        for (int i = 0; i < hearts.Length; ++i)
        {
            this.heartsAlive[i] = true;
        }
	}

    private void killHeart(int i)
    {
        this.moveHearts.Add(this.hearts[i]);
        this.heartsAlive[i] = false;
    }

    // Update is called once per frame
    void Update()
    {
        foreach(var heart in this.moveHearts)
        {
            if (((GameObject)heart).transform.position.y >= -20)
            {
                ((GameObject)heart).transform.Translate(Vector3.down * Time.deltaTime * this.MOVE_SPEED);
            }
        }

        // Make remaning hearts visible
        for (int hp_i = 0; hp_i < hearts.Length; ++hp_i)
        {
            if (
                !(player.health > hp_i)
                &&
                heartsAlive[hp_i]
                )
            {
                killHeart(hp_i);
            }
        }
    }
}
