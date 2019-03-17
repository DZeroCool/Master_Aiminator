using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController5Target : MonoBehaviour
{
    public float xRangeMin;
    public float xRangeMax;
    public float yRangeMin;
    public float yRangeMax;
    public float startWaitTime;
    public float maxNumTargets;

    public float gameTime;
    private float startTime;

    public GameObject Target;
    public GameObject Target2;
    public GameObject Target3;
    public GameObject Target4;
    public GameObject Target5;

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

        float xPosition = Random.Range(xRangeMin, xRangeMax);
        float yPosition = Random.Range(xRangeMin, xRangeMax);
        int zPosition = Random.Range(0, 5);
        Vector3 newSpawnPosition = new Vector3(xPosition, yPosition, 1);
        switch (zPosition)
        {
            case 0:
                Instantiate(Target, newSpawnPosition, Quaternion.identity);
                break;
            case 1:
                Instantiate(Target2, newSpawnPosition, Quaternion.identity);
                break;
            case 2:
                Instantiate(Target3, newSpawnPosition, Quaternion.identity);
                break;
            case 3:
                Instantiate(Target4, newSpawnPosition, Quaternion.identity);
                break;
            case 4:
                Instantiate(Target5, newSpawnPosition, Quaternion.identity);
                break;
        }

    }


    // Start is called before the first frame update
    void Start()
    {
        // first target spawn is delayed
        PlayerStats.CurrentGame = "5Target";
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

        //Spawns initial wave of targets
        for (int i = 0; i < maxNumTargets; i++)
        {
            SpawnTargets();
        }



    }

    // Update is called once per frame
    void Update()
    {
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
            hitRateText.text = "Hit rate is: " + hitPercent;
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
    //Called when you miss a target
    public void Miss()
    {
        streak = 0;
        missCounter++;
    }
}
