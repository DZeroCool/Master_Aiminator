using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{

    public int effectiveness; //how effective the pickup is
    public enum collectible {health, money};
    public collectible type_of_collectible;
    private Vector3 player_position; //players current position

    public int vision = 5;

    private int speed = 2; //since pickups need to move as well.
    private bool reached_pickup_radius; //did the player touch the pickup radius?



    // Start is called before the first frame update
    void Start()
    {
        player_position = GameObject.FindGameObjectWithTag("Player").transform.position;
    }

    // Update is called once per frame
    void Update()
    {

        player_position = GameObject.FindGameObjectWithTag("Player").transform.position;
        if(player_position.magnitude - this.transform.position.magnitude <= vision) move_towards_player(); //once the player is in the radius, go towards the player

    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player")
        {
            if (type_of_collectible == collectible.health)
                GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().health += effectiveness;
            else if (type_of_collectible == collectible.money)
                GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().money += effectiveness;
            this.gameObject.SetActive(false);
            print("Money: " + GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().money);
            print("Health: " + GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().health);
        }
    }

    public void move_towards_player()
    {
        this.GetComponent<Rigidbody2D>().velocity = new Vector2(player_position.x - this.transform.position.x, player_position.y - this.transform.position.y) * speed;
        if (this.GetComponent<Rigidbody2D>().velocity.magnitude < GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().speed)
            this.GetComponent<Rigidbody2D>().velocity *= 2;
    }

}
