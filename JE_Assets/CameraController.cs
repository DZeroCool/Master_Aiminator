using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject Crosshair;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float postionsX = Crosshair.transform.position.x;
        float postionsY = Crosshair.transform.position.y;

        transform.position = new Vector3(postionsX, postionsY, -10);
    }
}
