using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadLevel : MonoBehaviour
{
    public PhysicsScene2D level_to_load;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if(other.tag == "Cursor" && Input.GetMouseButton(0))
        {
            
        }
    }

}
