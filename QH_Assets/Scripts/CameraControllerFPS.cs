using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This class is to control camera in FPS mode.
// The moving of camera is associate to crosshair location, please see update()
// Camera moving speed is NOT adjustable, since it is determined by the speed of crosshair,. 

public class CameraControllerFPS : MonoBehaviour
{
    public GameObject Crosshair;
    private Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        // get initial location, only z is useful in Update().
        offset = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(Crosshair.transform.position.x, Crosshair.transform.position.y, offset.z);
    }
}
