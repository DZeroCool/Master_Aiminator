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


public class Enemy1Script : MonoBehaviour
{
    public float lifeTime;
    private float startTime;
    private float timeInterval;
    private float nextSizeChangTime;
    private GameController gameController;
    private Animator animator;

    private float currentTime = 0;
    private float endTime;
    private bool shoot = false;
    // this var is set how many steps from size 50% to size 100%,
    // the higher number, the more smooth animation is.
    private float changingSteps = 40.0f;

    // Start is called before the first frame update
    void Start()
    {
        
        animator = GetComponent<Animator>();
        //
        startTime = Time.time;
        timeInterval = lifeTime / changingSteps;
        nextSizeChangTime = 0;

        // cannot pass gameController at unity editor interface
        // have to do this to FIND game controller
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
            gameController.TargetNumberAddOne();
        }

        if (gameController == null)
        {
            Debug.Log("Cannot find 'GameController' script!");
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (this.transform.localScale.x > 30)
        {
            Destroy(this.gameObject);
        }



        // target life setting
        if ((Time.time - startTime) >= lifeTime && !shoot )
        {
            // self-destroy aftr lifetime
            //Destroy(this.gameObject);
            // and updat total number of targets in gamecontroller
            //gameController.TargetNumberAddOne();
            Time.timeScale = 0.0f;
        }

        // target size changing
        if(Time.time > nextSizeChangTime && !shoot)
        {
            // find how many % size change per step;
            float sizePerStep = 80f / changingSteps;
            transform.localScale += new Vector3(sizePerStep, sizePerStep, 0);
            nextSizeChangTime = Time.time + timeInterval;
        }
        
        if (shoot == true && Time.time > endTime)
        {
            //this.gameObject.SetActive(false);

            Destroy(this.gameObject);
        }
    }

    // detect click, destroy itself and update scores
    private void OnTriggerEnter2D(Collider2D other) {

        //GameObject collider = other.tag;

        if (other.tag == "Target")
        {
            return;
        }

        if (other.tag == "ClickPoint")
        {
            animator.SetTrigger("shot");
        }

        currentTime = Time.time;
        endTime = currentTime + 5;
        shoot = true;

           // Destroy(this.gameObject);
 
        gameController.HitNumberPlusOne();
        

    }
}
