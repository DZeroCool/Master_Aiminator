using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndingData : MonoBehaviour
{
    private int targetNumber;
    private int hitNumber;

    public Text targetNumberText;
    public Text yourHitText;
    public Text hitRateText;

    // Start is called before the first frame update
    void Start()
    {
        targetNumber = PlayerStates.TargetNumber;
        hitNumber = PlayerStates.HitNumber;

        targetNumberText.text = "Total target Number: " + targetNumber;
        yourHitText.text = "You hit: " + hitNumber;
        if (targetNumber > 0)
        {
            hitRateText.text = "Your hit rate:  " + (int)(((float) hitNumber) / targetNumber * 100) + "%";
        } else
        {
            hitRateText.text = "Your hit rate: 0%";
        }
        
    }
}
