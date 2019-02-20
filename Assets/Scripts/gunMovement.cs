using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// /
/// </summary>
public class gunMovements : MonoBehaviour
{
    public GameObject ClickPoint;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //=============================================================================
        // this block is for moving crosshair
        //=============================================================================
        // NOTE: the movement of crosshair is determined by mouse moving, NOT location!
        // Please see the difference between this one with another one in CrossScript.cs
        // mouse sensitivity is controlled by var speed 

        float moveHorizontal = Input.GetAxis("Mouse X");
        float moveVertical = Input.GetAxis("Mouse Y");

        transform.position += new Vector3(moveHorizontal * Time.deltaTime * speed, moveVertical * Time.deltaTime * speed, 0);


        // click mouse left button to generate a collider box
        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(ClickPoint, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity);
            if (Input.GetMouseButtonUp(0))
            {
                Destroy(ClickPoint);
            }
        }
    }
}
