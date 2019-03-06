using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public float health;
    public float speed;
    public enum movement_type {Idle, Follow, Random}
    public movement_type movement;
    public float vision; //the distance the enemy can see/is triggered by the enemy
    public float shyness; //the distance at which an enemy "is shy" and will move backwards
    public bool night_vision = false; //can the enemy see through walls?

    public bool is_spawning = true; //each enemy takes 1 second to spawn
    private float spawn_time = 0;

    private float tmp_vision;
    private float tmp_shyness;

    public Enemy(int new_health, int new_speed, movement_type new_movement)
    {
        health = new_health;
        speed = new_speed;
        movement = new_movement;
    }

    private Vector3 velocity = new Vector3(0, 0, 0);
    private Vector3 position = new Vector3(0, 0, 0);
    private Vector3 player_position = new Vector3(0, 0, 0);

    // Start is called before the first frame update
    void Start()
    {

        this.GetComponent<Animator>().SetBool("is_spawning", true);

        spawn_time = Time.time + 1f;

        tmp_vision = vision;
        tmp_shyness = shyness;

        if (player_visible(GameObject.FindGameObjectWithTag("Player")))
        {
            for (int i = 0; i < this.transform.childCount; i++)
            {
                this.transform.GetChild(i).gameObject.SetActive(true);
            }
            
        }
        else
        {
            for (int i = 0; i < this.transform.childCount; i++)
            {
                this.transform.GetChild(i).gameObject.SetActive(false);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (Time.time < spawn_time) //can't fire while spawning
        {
            for (int i = 0; i < this.transform.childCount; i++)
            {
                this.transform.GetChild(i).gameObject.SetActive(false);
            }
            this.GetComponent<Animator>().SetBool("is_spawning", true);
            is_spawning = true;
        }
        else
        {
            for (int i = 0; i < this.transform.childCount; i++)
            {
                this.transform.GetChild(i).gameObject.SetActive(true);
            }

            this.GetComponent<Animator>().SetBool("is_spawning", false);
            is_spawning = false;
        }


        player_position = GameObject.FindGameObjectWithTag("Player").transform.position; //sets the players position

        if (player_visible(GameObject.FindGameObjectWithTag("Player")))
        {
            for(int i = 0; i < this.transform.childCount; i++)
            {
                this.transform.GetChild(i).gameObject.SetActive(true);
            }
        }
        else
        {
            for (int i = 0; i < this.transform.childCount; i++)
            {
                this.transform.GetChild(i).gameObject.SetActive(false);
            }
        }

        //Movement
        if(is_spawning)
        {
            //Do nothing
        }
        else if(movement == movement_type.Follow)
        {
            this.gameObject.GetComponent<Rigidbody2D>().velocity = player_follow();
        }
        else if(movement == movement_type.Idle)
        {
            this.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector3(0, 0);
        }
        else if(movement == movement_type.Random)
        {
            this.vision = Random.Range(0, tmp_vision);
            this.shyness = Random.Range(0, tmp_shyness);
        }

    }

    Vector3 player_follow() //Makes the Constantly home into the Player
    {
        //velocity.x = Mathf.Sqrt((this.transform.position.x - player_position.x) * (this.transform.position.x - player_position.x)) / Mathf.Abs(this.transform.position.x - player_position.x);
        //if (this.transform.position.x > player_position.x) velocity.x *= -1;
        //velocity.y = Mathf.Sqrt((this.transform.position.y - player_position.y) * (this.transform.position.y - player_position.y)) / Mathf.Abs(this.transform.position.y - player_position.y);
        //if (this.transform.position.y > player_position.y) velocity.y *= -1;

        velocity.x = Mathf.Sqrt(((this.transform.position - player_position).magnitude * (this.transform.position - player_position).magnitude) + ((this.transform.position.x - player_position.x) * (this.transform.position.x - player_position.x)));
        if (this.transform.position.x > player_position.x) velocity.x *= -1;

        velocity.y = Mathf.Sqrt(((this.transform.position - player_position).magnitude * (this.transform.position - player_position).magnitude) + ((this.transform.position.y - player_position.y) * (this.transform.position.y - player_position.y)));
        if (this.transform.position.y > player_position.y) velocity.y *= -1;

        velocity = velocity / velocity.magnitude; //Linearizing vector


        if (!player_visible(GameObject.FindGameObjectWithTag("Player"))) velocity = new Vector3(0, 0, 0);
        if (is_shy(GameObject.FindGameObjectWithTag("Player"))) velocity = -velocity;

        return velocity * speed;
    }

    public bool player_visible(GameObject player) //Checks to see if the player is visible (can't see through walls)
    {
        return Mathf.Abs(player.transform.position.magnitude - gameObject.transform.position.magnitude) <= vision;
        //return Physics2D.Raycast(this.transform.position, this.transform.position - player_position, vision);
    }

    public bool is_shy(GameObject player)
    {
        if (shyness.Equals(0)) return false;
        return Mathf.Abs(player.transform.position.magnitude - gameObject.transform.position.magnitude) <= shyness;
        //return !Physics2D.Raycast(this.transform.position, this.transform.position - player_position, shyness);
    }

    public void took_damage()
    {
        for(int i = 0; i < 3; i++)
        {

        }
    }

}
