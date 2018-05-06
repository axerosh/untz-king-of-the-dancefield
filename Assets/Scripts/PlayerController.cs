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

    //Variables for blinking red
    private bool blinkRed = false;
    private bool isRed = false;
    private float timeSinceBlink = 0;
    public float BLINK_TIME = 0.1f;
    private SpriteRenderer spriteRend;

    // Use this for initialization
    void Start () {
        this.health = startHealth;

        this.spriteRend = this.playerAnim.gameObject.GetComponent<SpriteRenderer>();
        //this.setRed(true);
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

        // Blinking
        if (blinkRed)
        {
            this.timeSinceBlink += Time.deltaTime;

            if (this.timeSinceBlink >= this.BLINK_TIME)
            {
                this.timeSinceBlink -= this.BLINK_TIME;

                if (this.isRed)
                {
                    this.spriteRend.color = Color.white;
                    this.isRed = false;
                }
                else
                {
                    this.spriteRend.color = Color.red;
                    this.isRed = true;
                }
            }
        }
    }
    
    public void setRed(bool red)
    {
        this.blinkRed = red;

        if (red)
        {
            this.timeSinceBlink = 0;
            this.spriteRend.color = Color.red;
            this.isRed = true;
        }
        else
        {
            this.spriteRend.color = Color.white;
            this.isRed = false;
        }
    }
}
