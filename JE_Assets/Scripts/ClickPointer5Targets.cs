using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickPointer5Targets : MonoBehaviour
{
    public float lifeTime;
    private float startTime;
    private GameController5Target gameController;
    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;

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

    // Update is called once per frame
    void Update()
    {
        if ((Time.time - startTime) >= lifeTime)
        {
            gameController.Miss();
            Destroy(this.gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(this.gameObject);
    }
}
