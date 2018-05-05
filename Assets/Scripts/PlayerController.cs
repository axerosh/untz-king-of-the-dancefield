using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float MOVE_SPEED = 3;

    public GameMaster gm;
    public StageScript stage;

    public Animator playerAnim;

    public string[] inputNames;
    public int startHealth = 10;
    public int health;
    public int x = 0;
    public int y = 0;

    public int playerI = 0;

    private bool moving = false;
    private Vector3 destination;

    // Use this for initialization
    void Start () {
        this.health = startHealth;
	}

    public void setAnimation(DanceAnim anim)
    {
        playerAnim.SetInteger("anim", (int)anim);
    }

    /*
     * x,y are coordinates on the board
     * worldX, worldY are coordinates in the world
     */
    public void move(int deltaX, int deltaY)
    {
        int newX = this.x + deltaX;
        int newY = this.y + deltaY;

        if(stage.insideFloor(newX, newY))
        {
            this.moving = true;
            this.destination = stage.getWorldCoords(newX, newY);

            this.x = newX;
            this.y = newY;
        }
        else
        {
            this.die();
        }
    }
    
    public void damage(int amount)
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
        gm.selectCard(i, playerI);
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

        for(int i = 0; i < inputNames.Length; ++i)
        {
            if (Input.GetButton(inputNames[i]))
            {
                this.selectCard(i);
            }
        }
    }
    
    public void setRed(bool red)
    {
        SpriteRenderer rend =  this.playerAnim.gameObject.GetComponent<SpriteRenderer>();

        if (red)
        {
            rend.color = Color.red;
        }
        else
        {
            rend.color = Color.white;
        }
    }
}
