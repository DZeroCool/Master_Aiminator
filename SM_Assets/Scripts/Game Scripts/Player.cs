    using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float speed = 4;
    public int max_health = 60;
    public float invincibility_time = 0;
    public GameObject gun;
    public int ammo;
    private Vector3 velocity = new Vector3(0, 0, 0);

    public int money;
    public Text money_text;   

    public GameObject LMBAbility;
    public GameObject RMBAbility;
    public GameObject QAbility;
    public GameObject EAbility;
    public GameObject ShiftAbility;

    public Sprite health_bar;
    public Sprite reload_bar;
    public Sprite overhealth_bar;

    public int health; //current player health
    private float next_decrement; //the next time health will decrease when overloaded on health
    //private float invincible = 0;

    // Start is called before the first frame update
    void Start()
    {
        health = max_health;
    }

    // Update is called once per frame
    void Update()
    {

        update_money_ui();

        if(health > max_health && Time.time >= next_decrement) //health can go above max_health, but it goes down gradually.
        {
            this.transform.Find("Player HUD").GetComponent<PHUD>().set_health_icon(overhealth_bar);
            next_decrement = Time.time + 0.5f;
            health--;
        }
        else if(health <= max_health)
        {
            this.transform.Find("Player HUD").GetComponent<PHUD>().set_health_icon(health_bar);
        }


        if (health <= 0) //If player dies, quit application *WILL CHANGE LATER*
        {

            Application.Quit();
        }

        if (Input.GetKeyDown(KeyCode.LeftControl) && Input.GetKeyDown(KeyCode.Escape)) //Lft-Ctrl + Esc to quit application
        {
            Application.Quit();
        }

        if (Input.GetKey(KeyCode.D))
        {
            velocity += new Vector3(speed, 0, 0);
            this.gameObject.transform.localScale = new Vector3(1, 1, 1);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            velocity += new Vector3(-speed, 0, 0);
            this.gameObject.transform.localScale = new Vector3(-1, 1, 1);
        }

        if (Input.GetKey(KeyCode.W))
        {
            velocity += new Vector3(0, speed, 0);
        }
        else if(Input.GetKey(KeyCode.S))
        {
            velocity += new Vector3(0, -speed, 0);
        }

        this.gameObject.GetComponent<Animator>().SetBool("isMoving", velocity.magnitude > 0);
        this.gameObject.GetComponent<Rigidbody2D>().velocity = velocity;
        velocity = new Vector3(0, 0, 0);


    }

    void update_money_ui()
    {
        money_text.text = "Money: " + money;
    }

    void set_player_invincible()
    {
        //ADD INVINCIBILITY FRAMES
    }



}
