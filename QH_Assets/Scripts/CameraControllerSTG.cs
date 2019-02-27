using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This class is to control camera in RTS and Psuedo FPS modes
// The moving of camera is associate to mouse moving, please see update()
// Camera moving speed can be adjust by public int var speed, speed = 0 is RTS mode, speed > 0 is Psuedo FPS mode

public class CameraControllerSTG : MonoBehaviour
{
    //public GameObject Crosshair;
    public float speed;
    public Boundary boundary;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // camera moving is associated to mouse moving
        // get mouse moving information
        float moveHorizontal = Input.GetAxis("Mouse X");
        float moveVertical = Input.GetAxis("Mouse Y");

        // camera is moved by mouse moving 
        //transform.position += new Vector3(moveHorizontal * Time.deltaTime * speed, moveVertical * Time.deltaTime*speed, 0);
        transform.position = new Vector3(
           Mathf.Clamp((transform.position.x + moveHorizontal * Time.deltaTime * speed), boundary.xMin, boundary.xMax
           ),
       Mathf.Clamp((transform.position.y + moveVertical * Time.deltaTime * speed), boundary.yMin, boundary.yMax),
       transform.position.z);
    }
}
