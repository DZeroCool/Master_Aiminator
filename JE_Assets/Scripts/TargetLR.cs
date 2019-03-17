using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetLR : MonoBehaviour
{
    private float startTime;
    public float speed;
    private float depth = 1;
    private Vector3 destination;


    private GameControllerLR gameController;

    // Start is called before the first frame update
    void Start()
    {
        //gets end destination for the target
        destination = new Vector3(transform.position.x * -1, transform.position.y, 1);
        depth = transform.position.z;

        // cannot pass gameController at unity editor interface
        // have to do this to FIND game controller
        GameObject gameControllerObject = GameObject.FindWithTag("GameLR");
        //if (gameControllerObject != null)
        //{
            gameController = gameControllerObject.GetComponent<GameControllerLR>();
        //}

        //if (gameController == null)
        //{
        //    Debug.Log("Cannot find 'GameController' script!");
        //}
    
    }

    void Update()
    {
        float step = speed * Time.deltaTime / depth;
        transform.position = Vector3.MoveTowards(transform.position, destination, step);

        //Once target reaches destination, a new one is set.
        if (transform.position.x == destination.x)
        {
            destination = new Vector3(transform.position.x * -1, transform.position.y, 1);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.name == "ClickPointLR Variant(Clone)")
        {
            gameController.HitNumberPlusOne();
            Destroy(this.gameObject);
        }
    }

}
