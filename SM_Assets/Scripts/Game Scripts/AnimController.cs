using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //DOESN'T WORK, NEED TO FIX
        if(this.GetComponent<Enemy>().velocity.magnitude >= 0)
        {
           //this.GetComponent<Animator>().SetBool("is_facing_front", true);
        }
        else
       {
            //this.GetComponent<Animator>().SetBool("is_facing_front", false);
        }
        //this.GetComponent<Animator>().SetBool("is_facing_front", true); 
    }
}
