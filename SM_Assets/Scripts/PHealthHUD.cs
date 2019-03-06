﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PHealthHUD : MonoBehaviour
{

    private float health;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        health = transform.parent.GetComponent<Player>().health; //updating health
        this.transform.position = transform.parent.transform.position + new Vector3(0, 0.5f);
        this.transform.localScale = new Vector3(health, 1f, 1f);
    }
}
