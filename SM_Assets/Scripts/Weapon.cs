using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public float reloadtime = 2f;
    public int ammo;

    private float next_time;
    private int max_ammo;

    private bool reloading = false;
    private bool fired = false;

    // Start is called before the first frame update
    void Start()
    {
        max_ammo = ammo;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        //gun reloading
        fired = false;
        if (reloading == false && ammo == 0)
        {
            next_time = Time.time + reloadtime;
            print("reloading");
            reloading = true;
        }
        else if(Time.time >= next_time && ammo == 0)
        {
            print("reloaded, ammo = "+max_ammo);
            reloading = false;
            ammo = max_ammo;
        }

        if (Input.GetMouseButtonDown(0) && !reloading)
        {
            ammo--;
            print(ammo);
            fired = true;
        }

        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = mousePos;
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy" && Input.GetMouseButton(0) && fired == true)
        {
            other.gameObject.GetComponent<Enemy>().health -= 1;
            other.gameObject.GetComponent<Enemy>().took_damage();
            if(other.gameObject.GetComponent<Enemy>().health <= 0)
            {
                other.gameObject.SetActive(false);
            }
        }
        else if (other.gameObject.tag == "Projectile" && Input.GetMouseButton(0) && fired == true)
        {
            if (other.gameObject.GetComponent<Projectile>().clickable)
            {
                other.gameObject.SetActive(false);
            }
        }
    }
}
