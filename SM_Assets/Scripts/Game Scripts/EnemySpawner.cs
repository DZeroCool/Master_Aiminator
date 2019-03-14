using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//spawns enemies randomly
public class EnemySpawner : MonoBehaviour
{
    private GameObject enemy;

    public GameObject drop_table;

    //The different enemy tables
    public GameObject[] enemy_list_1;
    public GameObject[] enemy_list_2;
    public GameObject[] enemy_list_3;

    //private Dictionary<string, GameObject> enemy_table;

    private GameObject[] enemy_list;

    private float timer;
    public enum difficulty {very_easy, easy, medium, hard, insane, cyborg_hell}
    public difficulty current_diff;

    public float enemy_multiplier; //the multiplier that is added to enemy
    private float time_to_spawn; //the time between enemy spawns
    private int num_enemies; //the number of enemies that are spawned every "round"
    private int max_enemy; //the highest tier of enemy that can spawn
    private float enemy_value; //used to get the monster from the list of monsters

    private float next_spawn;

    private RaycastHit hit;

    // Start is called before the first frame update
    void Start()
    {
        enemy_list = enemy_list_1;
        print(enemy_list);
        next_spawn = Time.time + 10;

        for (int i = 0; i < enemy_list.Length; i++) //converts the list of enemies into a dictionary
        {
            print(i + ": " + enemy_list[i].name);
        }

        //print(enemy_table);
    }

    // Update is called once per frame
    void Update()
    {
        timer = Time.timeSinceLevelLoad; //keeping track of current time

        //Difficulty increases by one level every 5-10 minutes
        //The higher the difficulty, the more monster spawns, more difficult monsters spawn
        //However more loot will spawn
        if (timer < 200)
            current_diff = difficulty.very_easy;
        else if (timer < 400)
            current_diff = difficulty.easy;
        else if (timer < 600)
            current_diff = difficulty.medium;
        else if (timer < 800)
            current_diff = difficulty.hard;
        else if (timer < 1000)
            current_diff = difficulty.insane;
        else
            current_diff = difficulty.cyborg_hell;

        set_spawner(current_diff);

        spawn_enemies();

    }

    void set_spawner_position()
    {
        this.transform.position = this.transform.parent.transform.position + (new Vector3(Random.Range(2f, 5f) * (Random.Range(-1, 1) == -1 ? -1 : 1), Random.Range(2f, 5f) * (Random.Range(-1, 1) == -1 ? -1 : 1)) );
        //print(this.transform.position);
    }

    void spawn_enemies()
    {
        if (Time.time >= next_spawn)
        {
            for (int i = 0; i < num_enemies; i++)
            {
                enemy_value = Random.Range(0, 100); //used to calculate which enemy is spawned
                enemy = get_monster(enemy_value); //sets monster based on random value
                //enemy.GetComponent<Enemy>().speed *= enemy_multiplier; //enemy multiplier (Needs some fine tuning)
                Instantiate(enemy, this.transform.position, Quaternion.identity);
                set_spawner_position(); //setting a different position for variability
            }
            next_spawn = Time.time + time_to_spawn;
        }
    }

    GameObject get_monster(float value)
    {
        return enemy_list[Random.Range(0, enemy_list.Length)];
    }

    void set_spawner(difficulty current_difficulty)
    {
        if(current_diff == difficulty.very_easy)
        {
            time_to_spawn = 20;
            enemy_multiplier = 1;
            num_enemies = Random.Range(8, 10);
            enemy_list = enemy_list_1;
        }
        else if(current_diff == difficulty.easy)
        {
            time_to_spawn = 18;
            enemy_multiplier = 1;
            num_enemies = Random.Range(9, 11);
        }
        else if(current_diff == difficulty.medium)
        {
            time_to_spawn = 18;
            enemy_multiplier = 1.5f;
            num_enemies = Random.Range(9, 11);
            enemy_list = enemy_list_2;
        }
        else if(current_diff == difficulty.hard)
        {
            time_to_spawn = 16;
            enemy_multiplier = 1.5f;
            num_enemies = Random.Range(10, 12);
        }
        else if(current_diff == difficulty.insane)
        {
            time_to_spawn = 16;
            enemy_multiplier = 2f;
            num_enemies = Random.Range(10, 12);
            enemy_list = enemy_list_3;
        }
        else if(current_diff == difficulty.cyborg_hell)
        {
            time_to_spawn = 15;
            enemy_multiplier = 2f;
            num_enemies = Random.Range(10, 12);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Pit" || other.tag == "Wall" || other.tag == "Enemy") //FIX THIS
        {
            this.transform.position = this.transform.parent.transform.position;
            set_spawner_position();
            print(other.tag);
        }

    }


    // private void OnCollisionStay2D(Collision2D other)
    // {
    //     if (other.gameObject.tag == "Wall")
    //         set_spawner_position();
    //
    //     if (other.gameObject.tag == "Background")
    //         set_spawner_position();
    // }
}
