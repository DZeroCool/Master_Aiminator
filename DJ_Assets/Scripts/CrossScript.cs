using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This class is to control crosshair in RTS and Psudo FPS modes.
// The location of crosshair is same as mouse position on World (ScreenToWorldPoint method).
// Click the mouse left button will create an instance of clickPoint which is interactive 
// with Target (game object).

public class CrossScript : MonoBehaviour
{
    public GameObject ClickPoint;

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
        // move crosshair to current mouse position, please note ScreenToWorldPoint()
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = mousePosition;

        // click mouse left button to generate an instance of ClickPoint, whose collider box
        // is interactive with Targets.
        if (Input.GetMouseButtonDown(0))
        {
             Instantiate(ClickPoint, new Vector3(mousePosition.x, mousePosition.y, 0), Quaternion.identity);
            if (Input.GetMouseButtonUp(0))
            {
                Destroy(ClickPoint);
            }
         }

        //============================================================================
        // this black is for keyboard moving
        //============================================================================
        // float moveHorizontal = Input.GetAxis("Horizontal");
        // float moveVertical = Input.GetAxis("Vertical");
        //
        //rb2d.AddForce(new Vector2(moveHorizontal * speed, moveVertical * speed));
        //============================================================================

    }
}
