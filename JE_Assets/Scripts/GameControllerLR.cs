using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameControllerLR : MonoBehaviour
{
    public float xMin;
    public float xMax;
    public float yRangeMin;
    public float yRangeMax;
    public float startWaitTime;
    public float maxNumTargets;

    public float gameTime;
    private float startTime;
    public GameObject Target;

    public Text scoreText;
    public Text streakText;
    public Text hitNumberText;
    public Text hitRateText;

    private int hitNumber;
    private int missCounter;
    int hitPercent = 100;

    private int streak;
    private int score;

    // The method to generate target at random location on the map
    void SpawnTargets()
    {
        Vector3 newSpawnPoint;
        int side = Random.Range(0 , 2);
        float size = Random.Range(1 , 5);
        float yPosition = Random.Range(yRangeMin, yRangeMax);
        if (side % 2 == 0)
        {
            newSpawnPoint = new Vector3(xMin, yPosition, size);
        }else
        {
            newSpawnPoint = new Vector3(xMax, yPosition, size);
        }
        GameObject test = Instantiate(Target, newSpawnPoint, Quaternion.identity);
        test.transform.localScale = new Vector3(2 / size, 2 / size, 1);

    }


    // Start is called before the first frame update
    void Start()
    {
        //set game mode
        PlayerStats.CurrentGame = "LR";
        // first target spawn is delayed
        Cursor.visible = false;
        new WaitForSeconds(startWaitTime);
        startTime = Time.time;

        // setup display text
        scoreText.text = "Score: 0";
        streakText.text = "Current Streak: 0";
        hitNumberText.text = "You hit: 0";
        hitRateText.text = "Hit rate is: 0%";

        //variable set up
        score = 0;
        streak = 0;

        //spawn initial wave of targets
        for (int i = 0; i < maxNumTargets; i++)
        {
            SpawnTargets();
        }

    }

    // Update is called once per frame
    void Update()
    {
        //If game time is up
        if ((Time.time - startTime) >= gameTime)
        {
            Cursor.visible = true;
            new WaitForSeconds(2);
            PlayerStats.Kills = hitNumber;
            PlayerStats.Score = score;
            PlayerStats.Accuracy = hitPercent;
            PlayerStats.Streak = streak;
            PlayerStats.Misses = missCounter;
            SceneManager.LoadScene("Results");
        }

        hitNumberText.text = "You hit: " + hitNumber;
        scoreText.text = "Score : " + score;
        streakText.text = "Current Streak: " + streak;
        if (score > 0)
            {
            hitPercent = (int)((float)hitNumber / (hitNumber + missCounter) * 100);
            hitRateText.text = "Hit rate is: " + hitPercent + "%";
        } else
            {
                hitRateText.text = "Hit rate is: 0%";
            }
        
   }

    // Called when a target is hit;
    public void HitNumberPlusOne()
    {
        score += 1 + streak / 5;
        streak++;
        hitNumber++;
        GetComponent<AudioSource>().Play();
        SpawnTargets();
    }
    //Called when no target is hit
    public void Miss()
    {
        streak = 0;
        missCounter++;
    }
}
