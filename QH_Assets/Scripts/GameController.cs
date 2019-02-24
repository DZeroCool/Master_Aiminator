using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using System.Collections;
using UnityEngine.SceneManagement;

// The class of Game Controller.
// Mouse is disabled inside game screen.

public class GameController : MonoBehaviour
{
    // public vars of the range for target spawning
    public float xRangeMin;
    public float xRangeMax;
    public float yRangeMin;
    public float yRangeMax;

    // public vars controling when and how often targets spawning
    public float startWaitTime;
    public float timeInterval;
    public float endWaitTime;

    // public vars of game time
    public float gameTime;

    public GameObject Target;

    // vars of game scores
    public Text totalNumberText;
    public Text hitNumberText;
    public Text hitRateText;

    private float startTime;
    private float nextTarget;
    private int targetNumber;
    private int hitNumber;

    // animator of pistol
    private Animator pistolAnimator;

    // The method to generate target at random location on the map
    void SpawnTargets()
    {
        float xPosition = 10;
        float yPosition = 10;
        Vector3 newSpawnPosition = new Vector3(xPosition, yPosition, 0);
        Instantiate(Target, newSpawnPosition, Quaternion.identity);

    }


    // Start is called before the first frame update
    void Start()
    {
        // set game difficulty
        if (PlayerStates.GameDifficulty == 2)
        {
            timeInterval = 1;
        } else if (PlayerStates.GameDifficulty == 1)
        {
            timeInterval = 2;
        }
        else
        {
            timeInterval = 3;
        }


        // get game time from setting
        gameTime = PlayerStates.GameTime;

        // find animator of pistol
        GameObject pistol = GameObject.FindWithTag("Pistol");
        pistolAnimator = pistol.GetComponent<Animator>();

        // first target spawn is delayed
        new WaitForSeconds(startWaitTime);
        startTime = Time.time;
        nextTarget = 0;
        targetNumber = 0;

        // setup display text
        totalNumberText.text = "Total number: 0";
        hitNumberText.text = "You hit: 0";
        hitRateText.text = "Hit rate is: 0%";

        //Set Cursor to not be visible
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        // fire pistol
        if (Input.GetMouseButtonDown(0))
        {
            pistolAnimator.SetTrigger("PistolFire");
        }

        // Randomly generate targets 
        if ((Time.time - startTime) < gameTime && Time.time > nextTarget && Time.time > startTime + startWaitTime)
       {
            //SpawnTargets();

            float xPosition = Random.Range(xRangeMin, xRangeMax);
            float yPosition = Random.Range(yRangeMin, yRangeMax);
            //float xPosition = 10;
            //float yPosition = 10;
            Vector3 newSpawnPosition = new Vector3(xPosition, yPosition, 0);
            Instantiate(Target, newSpawnPosition, Quaternion.identity);
            nextTarget = Time.time + timeInterval;
        
       }
       // Display results
       totalNumberText.text = "Total number: " + targetNumber;
       hitNumberText.text = "You hit: " + hitNumber;
            
       if (targetNumber > 0)
         {
          int hitPercent = (int)((float)hitNumber / targetNumber * 100);
          hitRateText.text = "Hit rate is: " + hitPercent + "%";
       } else
          {
                hitRateText.text = "Hit rate is: 0%";
          }
        
        // restart game
        if ((Time.time - startTime) > gameTime + endWaitTime)
        {
            //new WaitForSeconds(endWaitTime);
            // Application.LoadLevel("End");
            SceneManager.LoadScene("End");
            PlayerStates.TargetNumber = targetNumber;
            PlayerStates.HitNumber = hitNumber;
            Cursor.visible = true;
        }

    }

    // gettr for target number.
    public int getTargetNumber()
    {
        return targetNumber;
    }

    // setter for hit number.
    public void HitNumberPlusOne()
    {
        hitNumber++;
    }

    // setter for target number.
    public void TargetNumberAddOne()
    {
        targetNumber++;
    }
}
