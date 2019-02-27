using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This class is Target. 
// There is a publuc inta var lifeTime to control how long a target shows in screen
// Feathers: 
// 1) target has a life time, once life time is reached, it will self-destroy and update
// total number of target in GameCotroller; 
// 2) target size is changing during its life, size starts at 50%; 
// 3) once a target is destroyed by clicking, it update hit number and total number of 
// targets in GameController.


public class TargetScript : MonoBehaviour
{
    public float lifeTime;
    //public float movingSpeed;
    public float xRangeMin;
    public float xRangeMax;
    public float yRangeMin;
    public float yRangeMax;

    private float startTime;
    private float timeInterval;
    private float nextSizeChangTime;
    private GameController gameController;
    private bool moving;
    private Vector2 startPosition;
    private Vector2 endPosition;
    private float movingAngle;

    // this var is set how many steps from size 50% to size 100%,
    // the higher number, the more smooth animation is.
    private float changingSteps = 40.0f;
    private float movingSpeed;

    // Start is called before the first frame update
    void Start()
    {
        //
        startTime = Time.time;
        timeInterval = lifeTime / changingSteps;
        nextSizeChangTime = 0;
        if (PlayerStates.GameDifficulty == 3 || PlayerStates.GameDifficulty == 4)
        {
            moving = true;
            startPosition = transform.position;
            endPosition = new Vector2(Random.Range(xRangeMin, xRangeMax), Random.Range(yRangeMin, yRangeMax));
            movingAngle = Mathf.Atan((startPosition.y - endPosition.y)/(startPosition.x - endPosition.x));
        }

        if (PlayerStates.GameDifficulty == 3)
        {
            movingSpeed = 5;
        } else if (PlayerStates.GameDifficulty == 4)
        {
            movingSpeed = 15;
        }

            //set game difficulty
            int gameDifficulty = PlayerStates.GameDifficulty;
        if (gameDifficulty == 2)
        {
            lifeTime = 1;
        }
        else if (gameDifficulty == 1)
        {
            lifeTime = 2;
        } else
        {
            lifeTime = 3;
        }

        // cannot pass gameController at unity editor interface
        // have to do this to FIND game controller
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
        }

        if (gameController == null)
        {
            Debug.Log("Cannot find 'GameController' script!");
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // target life setting
        if ((Time.time - startTime) >= lifeTime)
        {
            // self-destroy aftr lifetime
            Destroy(this.gameObject);
            // and update total number of targets in gamecontroller
            gameController.TargetNumberAddOne();
        }

        // target size changing
        if(Time.time > nextSizeChangTime)
        {
            // find how many % size change per step;
            float sizePerStep = 0.5f / changingSteps;
            transform.localScale += new Vector3(sizePerStep, sizePerStep, 0);
            nextSizeChangTime = Time.time + timeInterval;
        }

        move();
        
    }

    // detect click, destroy itself and update scores
    private void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(this.gameObject);
        gameController.HitNumberPlusOne();
        gameController.TargetNumberAddOne();
    }

    private void move()
    {
        float y = Mathf.Sin(movingAngle);
        float x = Mathf.Cos(movingAngle);
        this.transform.position += new Vector3(x * Time.deltaTime * movingSpeed, y * Time.deltaTime * movingSpeed, 0);
    }
}
