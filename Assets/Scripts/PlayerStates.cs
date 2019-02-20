using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerStates 
{
    private static int targetNumber;
    private static int hitNumber;

    public static int TargetNumber
    {
        get
        {
            return targetNumber;
        }
        set
        {
            targetNumber = value;
        }
    }

    public static int HitNumber
    {
        get
        {
            return hitNumber;
        }
        set
        {
            hitNumber = value;
        }
    }
}
