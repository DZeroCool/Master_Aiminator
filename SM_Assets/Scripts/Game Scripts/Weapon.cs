using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Weapon : MonoBehaviour
{

    public int score = 0;

    public float reloadtime;
    public int ammo;
    public float time_between_shots;

    public Text score_text;

    public int power;

    private float next_time;
    private int max_ammo;

    private bool reloading = false;
    private bool fired = false;

    public AudioClip[] shooting_sounds;
    public AudioClip reload_sound;
    public AudioSource weapon_source;

    // Start is called before the first frame update
    void Start()
    {
        max_ammo = ammo;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {

        update_score();

        if (Input.GetKeyDown(KeyCode.R) && ammo!=max_ammo) //reload early
        {
            reloading = true;
            ammo = 0;
            next_time = Time.time + reloadtime;

            //play reloading sound
            weapon_source.clip = reload_sound;
            weapon_source.Play();
        }

        //gun reloading
        fired = false;
        if (reloading == false && ammo == 0)
        {
            next_time = Time.time + reloadtime;
            //print("reloading");
            reloading = true;

            //play reloading sound
            weapon_source.clip = reload_sound;
            weapon_source.Play();

        }
        else if(Time.time >= next_time && ammo == 0)
        {
            //print("reloaded, ammo = "+max_ammo);
            reloading = false;
            ammo = max_ammo;
        }

        if (Input.GetMouseButtonDown(0) && !reloading)
        {
            ammo--;
            print(ammo);
            fired = true;

            //play shooting sound
            weapon_source.clip = shooting_sounds[Random.Range(0, shooting_sounds.Length)];
            weapon_source.Play();
        }

        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = mousePos;
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy" && Input.GetMouseButton(0) && fired == true)
        {
            other.gameObject.GetComponent<Enemy>().health -= power;
            other.gameObject.GetComponent<Enemy>().set_inv(0.6f);
            other.gameObject.GetComponent<Enemy>().flash_image();
        }
        else if (other.gameObject.tag == "Projectile" && Input.GetMouseButton(0) && fired == true)
        {
            if (other.gameObject.GetComponent<Projectile>().clickable)
            {
                other.gameObject.SetActive(false);
                GameObject.Destroy(other);
            }
        }
    }

    void update_score()
    {
        score_text.text = "Score: " + score;
    }
}
