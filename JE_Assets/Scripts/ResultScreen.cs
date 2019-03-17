using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ResultScreen : MonoBehaviour
{
    private int score;
    private int kills;

    public Text scoreText;
    public Text yourHitText;
    public Text hitRateText;

    // Start is called before the first frame update
    void Start()
    {
        score = PlayerStats.Score;
        kills = PlayerStats.Kills;

        scoreText.text = "Total target Number: " + score;
        yourHitText.text = "You hit: " + kills;
        if (kills > 0)
        {
            hitRateText.text = "Your hit rate:  " + (int)(((float)kills) / (kills + PlayerStats.Misses) * 100) + "%";
        }
        else
        {
            hitRateText.text = "Your hit rate: 0%";
        }

    }
    public void RestartGame()
    {
        SceneManager.LoadScene("5TargetStart");
    }
}