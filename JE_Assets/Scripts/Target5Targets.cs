using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target5Targets : MonoBehaviour
{
    private GameController5Target gameController;

    // Start is called before the first frame update
    void Start()
    {
        // cannot pass gameController at unity editor interface
        // have to do this to FIND game controller
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController5Target>();
        }

        if (gameController == null)
        {
            Debug.Log("Cannot find 'GameController' script!");
        }
        
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        gameController.HitNumberPlusOne();
        Destroy(this.gameObject);
    }

}
