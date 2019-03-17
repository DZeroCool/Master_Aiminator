using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossScriptJE : MonoBehaviour
{
    public GameObject ClickPoint;
    public GameObject ClickPointLR;
    public float speed;
    //public float xMin, xMax, yMin, yMax;
    private float mouseX;
    private float mouseY;


    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0,0,-5);

    }

    // Update is called once per frame
    void Update()
    {
        float moveHorizontal = Input.GetAxis("Mouse X");
        float moveVertical = Input.GetAxis("Mouse Y");
        transform.position += new Vector3(moveHorizontal * Time.deltaTime * speed, moveVertical * Time.deltaTime * speed, 0);
        //this is if you want to add cursor boundaries
       // transform.position = new Vector3
       //(
       //    Mathf.Clamp(transform.position.x, xMin, xMax),
       //    Mathf.Clamp(transform.position.y, yMin, yMax),
       //    0

       //);
        if (Input.GetMouseButtonUp(0))
        {
            if (PlayerStats.CurrentGame == "5Target") {
                GetComponent<AudioSource>().Play();
                Instantiate(ClickPoint, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity);
            }
            else if (PlayerStats.CurrentGame == "LR")
            {
                GetComponent<AudioSource>().Play();
                Instantiate(ClickPointLR, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity);
            }
        }

    }

}
