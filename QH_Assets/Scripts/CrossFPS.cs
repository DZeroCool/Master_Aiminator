using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[System.Serializable]
public class Boundary
{
    public float xMin, xMax, yMin, yMax;
}


// This class is to control crosshair in FPS mode.
// Location of crosshair is moved by mouse moving. Notice, NOT by mouse location.
// Therefore, public inst var speed can be set to change corsshair / mouse sensitivity
// Click the mouse left button will create an instance of clickPoint which is interactive 
// with Target (game object).

public class CrossFPS : MonoBehaviour
{
    public GameObject ClickPoint;
    public float speed;
    public Boundary boundary;

    public Sprite[] spriteArray;

    // Start is called before the first frame update
    void Start()
    {
        speed = PlayerStates.MouseSensitivity;
        this.GetComponent<SpriteRenderer>().sprite =spriteArray[PlayerStates.CrossType];
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

        transform.position = new Vector3(
            Mathf.Clamp((transform.position.x + moveHorizontal * Time.deltaTime * speed), boundary.xMin, boundary.xMax
            ),
        Mathf.Clamp((transform.position.y + moveVertical * Time.deltaTime * speed), boundary.yMin, boundary.yMax), 
        0);

 
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
