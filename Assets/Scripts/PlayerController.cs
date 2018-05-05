using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float MOVE_SPEED = 3;

    public string[] inputNames;
    public int startHealth = 10;
    private int health;
    public int x = 0;
    public int y = 0;

    private bool moving = false;
    private Vector3 destination;

    // Use this for initialization
    void Start () {
        this.health = startHealth;
	}

    /*
     * x,y are coordinates on the board
     * worldX, worldY are coordinates in the world
     */
    void moveTo(int x, int y, int worldX, int worldY)
    {
        this.moving = true;
        this.destination = new Vector3(worldX, worldY, this.transform.position.z);
    }
    
    void damage(int amount)
    {
        this.health -= amount;

        if(this.health <= 0)
        {
            this.health = 0;
            this.die();
        }
    }

    void die()
    {
        Debug.Log("Dead");
    }

    void selectCard(int i)
    {
        
    }

	// Update is called once per frame
	void Update () {
        if (this.moving)
        {
            Vector3 newPos = Vector3.MoveTowards(this.transform.position, this.destination, this.MOVE_SPEED*Time.deltaTime);
            this.transform.SetPositionAndRotation(newPos, this.transform.rotation);

            if(this.transform.position == this.destination)
            {
                this.moving = false;
            }
        }

        for(int i = 0; i < 4; ++i)
        {
            if (Input.GetButton(inputNames[i]))
            {
                this.selectCard(i);
            }
        }
    }
}
