using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public int health;
    public float speed;
    public enum movement_type {Idle, Follow, Random}
    public movement_type movement;
    public float vision; //the distance the enemy can see/is triggered by the enemy
    public float shyness; //the distance at which an enemy "is shy" and will move backwards

    public bool is_spawning = true; //each enemy takes 1 second to spawn
    private float spawn_time = 0;

    public int score = 10; //how much the enemy is worth point wise

    private float tmp_vision;
    private float tmp_shyness;

    private float next_time_phase;
    private bool already_asleep; //did I already set the gameObject to be stationary?

    private GameObject drop;

    public Enemy(int new_health, int new_speed, movement_type new_movement)
    {
        health = new_health;
        speed = new_speed;
        movement = new_movement;
    }

    public Vector3 velocity = new Vector3(0, 0, 0);
    private Vector3 position = new Vector3(0, 0, 0);
    private Vector3 player_position = new Vector3(0, 0, 0);

    // Start is called before the first frame update
    void Start()
    {

        next_time_phase = Time.time + 1; //changes behavior every second

        this.GetComponent<Animator>().SetBool("is_spawning", true);

        spawn_time = Time.time + 1f;

        tmp_vision = vision;
        tmp_shyness = shyness;

        if (player_visible())
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
                if(this.transform.GetChild(i).tag == "Weapon")
                    this.transform.GetChild(i).gameObject.SetActive(false);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (Time.time < spawn_time) //can't fire while spawning
        {
            is_curr_spawning(true);
        }
        else
        {
            is_curr_spawning(false);
        }


        player_position = GameObject.FindGameObjectWithTag("Player").transform.position; //sets the players position

        if (player_visible())
        {
            set_children(true);
        }
        else
        {
            set_children(false);
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
            if(Time.time >= next_time_phase) {
              next_time_phase = Time.time + 1;
              this.vision = Random.Range(0, tmp_vision);
              this.shyness = Random.Range(0, tmp_shyness);
            }
            this.gameObject.GetComponent<Rigidbody2D>().velocity = player_follow();
        }

        if(health <= 0) //enemy is dead
        {
            GameObject.FindGameObjectWithTag("Player Weapon").GetComponent<Weapon>().score += score;
            if (player_visible() && Random.Range(0, 10) < this.GetComponentInChildren<MonsterItem>().drop_rate)
            {
                print("Dropped" + drop.name);
                Instantiate(drop, transform.position, Quaternion.identity);
            }
            //Instantiate(drop, transform.position, Quaternion.identity);
            gameObject.SetActive(false);
        }

    }

    private void is_curr_spawning(bool spawning)
    {
        set_children(!spawning);
        this.GetComponent<Animator>().SetBool("is_spawning", spawning);
        is_spawning = spawning;
    }

    Vector3 player_follow() //Makes the Constantly home into the Player
    {

        velocity.x = Mathf.Sqrt(Mathf.Pow((this.transform.position - player_position).magnitude, 2f) + Mathf.Pow(this.transform.position.x - player_position.x, 2));
        if (this.transform.position.x > player_position.x) velocity.x *= -1;

        velocity.y = Mathf.Sqrt(((this.transform.position - player_position).magnitude * (this.transform.position - player_position).magnitude) + ((this.transform.position.y - player_position.y) * (this.transform.position.y - player_position.y)));
        if (this.transform.position.y > player_position.y) velocity.y *= -1;

        velocity = velocity / velocity.magnitude; //Linearizing vector


        //velocity = this.transform.position - player_position;


        if (!player_visible()) velocity = Vector3.zero;
        if (is_shy(GameObject.FindGameObjectWithTag("Player"))) velocity = -velocity;
          
        //if there's a wall, move backwards
        RaycastHit2D hit = Physics2D.Raycast(transform.position, velocity, 2f);
        if (hit.transform.tag == "Wall") velocity = -velocity;

        return velocity * speed;
    }

    public bool player_visible() // returns true if the player is visible (withing the visibility value)
    {
        return Mathf.Abs(GameObject.FindGameObjectWithTag("Player").transform.position.magnitude - gameObject.transform.position.magnitude) <= vision;
        //return Physics2D.Raycast(this.transform.position, this.transform.position - player_position, vision);
    }

    public bool is_shy(GameObject player) //returns true if the player is too close to the enemy (if the enemy has a shyness factor)
    {
        if (shyness.Equals(0)) return false;
        return Mathf.Abs(player.transform.position.magnitude - gameObject.transform.position.magnitude) <= shyness;
        //return !Physics2D.Raycast(this.transform.position, this.transform.position - player_position, shyness);
    }

    public void set_drop(GameObject drop_item) //sets the item that the monster is currently holding to drop_item
    {
        drop = drop_item;
    }

    public GameObject get_drop() //returns the item that the monster is currently holding
    {
        return drop;
    }

    public void set_children(bool value) //sets all children to be active or not active.
    {
        for (int i = 0; i < this.transform.childCount; i++)
        {
            this.transform.GetChild(i).gameObject.SetActive(value);
        }
    }

    public void flash_image() //flashes sprite to indicate damage being taken
    {
        Color this_color = this.GetComponent<SpriteRenderer>().color;
        
        //this.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0);
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag != "Floor" || other.tag != "Projectile")
        {
           // print(other.tag);
           // gameObject.SetActive(false);
        }
    }


}
