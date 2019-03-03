using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed;
    public enum projectile_movement {linear, homing, random}; //how does the projectile move
    public projectile_movement movement;

    public float damage; //How much damage the projectile will do
    public bool destructible; //does the projectile get destroyed when it hits a wall/the player
    public bool clickable; //does the projectile get destroyed if clicked?
    public float variability; //variability of velocity of projectiles, 0 is least variable, 1 is most variable

    private Vector3 velocity;

    //Some shorthand notations for some commonly used objects
    private Rigidbody2D rb;
    private Vector3 player_position;


    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();


        if (movement == projectile_movement.linear)
        {
            linear_movement();
        }

        else if (movement == projectile_movement.random)
        {
            random_movement();
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (movement == projectile_movement.homing)
        {
            linear_movement();
        }
    }

    void linear_movement()
    {
        player_position = GameObject.FindGameObjectWithTag("Player").transform.position; //sets the players position
        //velocity.x = speed * (this.transform.position.y - player_position.y);
        //velocity.y = speed * (this.transform.position.y - player_position.y);

        velocity.x = Mathf.Sqrt( ( (this.transform.position - player_position).magnitude * (this.transform.position - player_position).magnitude) + ((this.transform.position.x - player_position.x) * (this.transform.position.x - player_position.x)));
        if (this.transform.position.x > player_position.x) velocity.x *= -1;
        
        velocity.y = Mathf.Sqrt( ( (this.transform.position - player_position).magnitude * (this.transform.position - player_position).magnitude) + ((this.transform.position.y - player_position.y) * (this.transform.position.y - player_position.y)));
        if (this.transform.position.y > player_position.y) velocity.y *= -1;

        velocity = velocity / velocity.magnitude; //Linearizing vector

        //Edge cases were when player was adjacent to enemy
        if (Mathf.Abs(this.transform.position.x - player_position.x) <= 0.2) //If player and enemy are on the same x plane
        {
            if (this.transform.position.y > player_position.y) velocity.y = -1; //If the player is left of the enemy, shoot left
            else velocity.y = 1; //Else shoot right
            velocity.x = 0;
        }
        if (Mathf.Abs(this.transform.position.y - player_position.y) <= 0.2) //If the player and enemy are on the same y plane
        {
            if (this.transform.position.x > player_position.x) velocity.x = -1; //If the player is below the enemy, shoot below
            else velocity.x = 1; //Else shoot left
            velocity.y = 0;
        }

        
        //print(Mathf.Sqrt((velocity.x * velocity.x) + (velocity.y * velocity.y)));



        //variability
        velocity.x += variability * Random.Range(-1f, 1f) * velocity.x;
        velocity.y += variability * Random.Range(-1f, 1f) * velocity.y;
        rb.velocity = velocity * speed;
    }

    void random_movement()
    {
        rb.velocity = new Vector3(Random.Range(-180, 180), Random.Range(-180, 180));
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (destructible) //deactivate object when it hits a wall, player, or enemy if it is destructible
        {
            if(other.gameObject.tag == "Wall" || other.gameObject.tag == "Player")
            {
                if(other.gameObject.tag == "Player")
                {
                    other.GetComponent<Player>().health -= damage;
                    //print(":D Player health is working now :D "+other.GetComponent<Player>().health);
                }
                gameObject.SetActive(false);
            }
        }
        if (clickable)
        {
            if(other.gameObject.tag == "Player")
            {
                other.GetComponent<Player>().health -= damage;
                
            }
            gameObject.SetActive(false);
        }
    }


}
