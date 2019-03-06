using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//spawns enemies randomly
public class EnemySpawner : MonoBehaviour
{
    private GameObject enemy;

    public List<GameObject> enemy_list;
    //private Dictionary<string, GameObject> enemy_table;

    private float timer;
    public enum difficulty {very_easy, easy, medium, hard, insane, cyborg_hell}
    public difficulty current_diff;

    public float enemy_multiplier; //the multiplier that is added to enemy
    private float time_to_spawn; //the time between enemy spawns
    private int num_enemies; //the number of enemies that are spawned every "round"
    private int max_enemy; //the highest tier of enemy that can spawn
    private float enemy_value; //used to get the monster from the list of monsters

    private float next_spawn;

    // Start is called before the first frame update
    void Start()
    {
        next_spawn = Time.time + 10;

        for (int i = 0; i < enemy_list.Capacity; i++) //converts the list of enemies into a dictionary
        {
            print(i + ": " + enemy_list[i].name);
            //enemy_table.Add(enemy_list[i].name, enemy_list[i]);
        }

        //print(enemy_table);
    }

    // Update is called once per frame
    void Update()
    {
        timer = Time.time; //keeping track of current time

        //Difficulty increases by one level every 5 minutes
        //The higher the difficulty, the more monster spawns, more difficult monsters spawn
        //However more loot will spawn
        if (timer < 600)
            current_diff = difficulty.very_easy;
        else if (timer < 1200)
            current_diff = difficulty.easy;
        else if (timer < 1800)
            current_diff = difficulty.medium;
        else if (timer < 2400)
            current_diff = difficulty.hard;
        else if (timer < 3000)
            current_diff = difficulty.insane;
        else
            current_diff = difficulty.cyborg_hell;

        set_spawner(current_diff);

        spawn_enemies();

    }

    void set_spawner_position()
    {
        this.transform.position = GameObject.FindGameObjectWithTag("Player").transform.position + new Vector3(Random.Range(-5f, 5f), Random.Range(-5f, 5f));
    }

    void spawn_enemies()
    {
        if (Time.time >= next_spawn)
        {
            for (int i = 0; i < num_enemies; i++)
            {
                enemy_value = Random.Range(0, 100); //used to calculate which enemy is spawned
                set_spawner_position();
                enemy = get_monster(enemy_value); //sets monster based on random value
                enemy.GetComponent<Enemy>().speed *= enemy_multiplier;

                Instantiate(enemy, this.transform.position, Quaternion.identity);
            }
            next_spawn = Time.time + time_to_spawn;
        }
    }

    GameObject get_monster(float value)
    {
        if (value <= 80)
            return enemy_list[1];
        return enemy_list[0];
    }

    void set_spawner(difficulty current_difficulty)
    {
        if(current_diff == difficulty.very_easy)
        {
            time_to_spawn = 20;
            enemy_multiplier = 1;
            num_enemies = Random.Range(3, 5);
            max_enemy = 1;
        }
        else if(current_diff == difficulty.easy)
        {
            time_to_spawn = 20;
            enemy_multiplier = 1;
            num_enemies = Random.Range(5, 7);
        }
        else if(current_diff == difficulty.medium)
        {
            time_to_spawn = 20;
            enemy_multiplier = 1.5f;
            num_enemies = Random.Range(5, 7);
            max_enemy = 2;
        }
        else if(current_diff == difficulty.hard)
        {
            time_to_spawn = 18;
            enemy_multiplier = 1.5f;
            num_enemies = Random.Range(6, 9);
        }
        else if(current_diff == difficulty.insane)
        {
            time_to_spawn = 18;
            enemy_multiplier = 2f;
            num_enemies = Random.Range(6, 9);
            max_enemy = 3;
        }
        else if(current_diff == difficulty.cyborg_hell)
        {
            time_to_spawn = 16;
            enemy_multiplier = 2f;
            num_enemies = Random.Range(7, 11);
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag != "Floor")
            set_spawner_position();

        if (other.gameObject.tag == "Background")
            set_spawner_position();

    }

    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.tag == "Wall")
            set_spawner_position();

        if (other.gameObject.tag == "Background")
            set_spawner_position();
    }
}
