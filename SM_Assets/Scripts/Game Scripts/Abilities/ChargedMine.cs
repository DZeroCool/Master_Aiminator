using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargedMine : MonoBehaviour
{

    public float cd = 4;
    public float damage = 0;
    public float range = 1.5f;
    public int max_stacks = 4;

    public GameObject mine;

    private int current_stacks;

    private int lifespan = 20;
    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        current_stacks = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if(current_stacks > 0)
        {
            current_stacks--;
            place_mine();
        }

    }


    public void place_mine()
    {
        
    }

}
