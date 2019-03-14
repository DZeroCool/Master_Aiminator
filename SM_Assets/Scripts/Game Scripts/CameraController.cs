using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    Vector2 playerPosition = new Vector2(0, 0);

    //public GUIText score_text; //FIX THIS

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;
    }
    // Update is called once per frame
    void Update()
    {
        playerPosition.x = GameObject.FindGameObjectWithTag("Player").transform.position.x;
        playerPosition.y = GameObject.FindGameObjectWithTag("Player").transform.position.y;
        this.gameObject.transform.position = new Vector3(playerPosition.x, playerPosition.y, -10);
        //score_text.text = "Score: " + GameObject.FindGameObjectWithTag("Player Weapon").GetComponent<Weapon>().score;
    }
}
