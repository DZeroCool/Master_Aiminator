    using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float speed = 4;
    public int max_health = 60;
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

    private bool is_invincible = false;
    private float invincibility_time = 0;
    private bool blink_sprite = false;
    private float next_blink; //stores Time.time value of next blink

    public int health; //current player health
    private float next_decrement; //the next time health will decrease when overloaded on health

    private Color default_color;

    // Start is called before the first frame update
    void Start()
    {
        health = max_health;
        default_color = this.GetComponent<SpriteRenderer>().color;
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

        if(is_invincible && Time.time >= invincibility_time)
        {
            is_invincible = false;
            this.GetComponent<SpriteRenderer>().color = Color.white;
            blink_sprite = false;
        }

        if(blink_sprite && Time.time >= next_blink)
        {
            //Blinking Sprite every 0.2 seconds
            if (GetComponent<SpriteRenderer>().color == Color.clear)
                this.GetComponent<SpriteRenderer>().color = Color.white;
            else
                this.GetComponent<SpriteRenderer>().color = Color.clear;

            next_blink = Time.time + 0.1f;
        }



    }

    void update_money_ui()
    {
        money_text.text = "Money: " + money;
    }

    public void set_inv_time(float time)
    {
        invincibility_time = Time.time + time;
    }

    public void set_invicibility(bool inv)
    {
        this.is_invincible = inv;
    }

    public bool get_invincibility()
    {
        return is_invincible;
    }

    public void set_blink(bool cond)
    {
        blink_sprite = cond;
    }



}
