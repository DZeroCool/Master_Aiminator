using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EWeapon : MonoBehaviour
{

    public GameObject projectile;

    public enum power_type { Passive, Player_Focused, Random_Spread, Player_Focused_Spread, Circle, Homing}; //what kind of projectile does the enemy shoot
    public power_type power;
    public float wait_time = 0.5f; //time between firing projectiles in seconds
    public int damage; //How much damage does each projectile do
    public float speed; //Speed of projectiles
    public float variability = 0; //Between 0 and 1, how random the shots are speed and accuracy wise, 0 being least random
    public bool clickable = false; //Is the Projectile destroyed if the player clicks on it?
    public bool destructable = true; //Is the Projetile destroyed if it hits the player or a wall?

    //public AudioSource weapon_source;
    //public AudioClip weapon_sound;

    private float next_shot; //The time at which the next shot is shot

    private Vector3 player_position;

    // Start is called before the first frame update
    void Start()
    {
        projectile.GetComponent<Projectile>().variability = this.variability;
        projectile.GetComponent<Projectile>().speed = this.speed;
        projectile.GetComponent<Projectile>().damage = this.damage;
        projectile.GetComponent<Projectile>().clickable = this.clickable;
        projectile.GetComponent<Projectile>().destructible = this.destructable;

        //weapon_source.clip = weapon_sound; //setting the source to play the shooting clip
        //weapon_source.volume = 0.1f;

    }

    // Update is called once per frame
    void Update()
    {
        //this.gameObject.transform.LookAt(GameObject.FindGameObjectWithTag("Player").transform);
        if(power == power_type.Passive)
        {
              //Do Nothing :)
        }
        else if (power == power_type.Player_Focused && Time.time >= next_shot)
        {
            projectile.GetComponent<Projectile>().movement = Projectile.projectile_movement.linear;
            Instantiate(projectile, this.transform.position, Quaternion.identity);
            next_shot = Time.time + wait_time;
            //weapon_source.Play();
        }
        else if (power == power_type.Homing && Time.time >= next_shot)
        {
            projectile.GetComponent<Projectile>().movement = Projectile.projectile_movement.homing;
            Instantiate(projectile, this.transform.position, Quaternion.identity);
            next_shot = Time.time + wait_time;
            //weapon_source.Play();
        }
    }
}
