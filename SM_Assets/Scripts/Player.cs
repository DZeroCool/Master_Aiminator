using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 4;
    public float health = 3;
    public float invincibility_time = 0;
    public GameObject gun;
    public int ammo;
    private Vector3 velocity = new Vector3(0, 0, 0);

    //private float invincible = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

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


        if(gameObject.GetComponent<Rigidbody2D>().IsSleeping())
        {

        }


    }


    void set_player_invincible()
    {
        //ADD INVINCIBILITY FRAMES
    }
}
