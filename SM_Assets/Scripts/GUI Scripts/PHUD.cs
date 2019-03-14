using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PHUD : MonoBehaviour
{

    public Sprite health_image;
    public Sprite ammo_image;

    private float health;
    private int ammo;

    private GameObject health_object;
    private GameObject ammo_object;

    // Start is called before the first frame update
    void Start()
    {
        health_object = new GameObject("Health UI");
        health_object.AddComponent<SpriteRenderer>();
        health_object.GetComponent<SpriteRenderer>().sprite = health_image;
        health_object.GetComponent<SpriteRenderer>().sortingLayerName = "Cursor + UI";

        ammo_object = new GameObject("Ammo UI");
        ammo_object.AddComponent<SpriteRenderer>();
        ammo_object.GetComponent<SpriteRenderer>().sprite = ammo_image;
        ammo_object.GetComponent<SpriteRenderer>().sortingLayerName = "Cursor + UI";
    }

    // Update is called once per frame
    void Update()
    {
        health = transform.parent.GetComponent<Player>().health; //updating health
        health_object.transform.position = transform.parent.transform.position + new Vector3(0, 0.5f);
        health_object.transform.localScale = new Vector3(health/10, 1f, 1f);

        ammo = GameObject.FindGameObjectWithTag("Player Weapon").GetComponent<Weapon>().ammo;
        ammo_object.transform.position = transform.parent.transform.position + new Vector3(0, 0.7f);
        ammo_object.transform.localScale = new Vector3(ammo, 1f, 1f);
    }

    public void set_health_icon(Sprite new_health_icon)
    {
        health_object.GetComponent<SpriteRenderer>().sprite = new_health_icon;
    }
}
