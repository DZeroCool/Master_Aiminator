using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerStates 
{
    private static int targetNumber=0;
    private static int hitNumber=0;
    private static int crossType=0;
    private static float mouseSensitivity = 40;
    private static int gameTime = 10;
    private static int gameDifficulty=0;
    private static int gameMode=0;

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

    public static int CrossType
    {
        get
        {
            return crossType;
        }
        set
        {
            crossType = value;
        }
    }

    public static float MouseSensitivity
    {
        get
        {
            return mouseSensitivity;
        }
        set
        {
            mouseSensitivity = value;
            //Debug.Log("mouse sensi: " + mouseSensitivity);
        }
    }

    public static int GameTime
    {
        get
        {
            return gameTime;
        }
        set
        {
            gameTime = value;
        }
    }

    public static int GameDifficulty
    {
        get
        {
            return gameDifficulty;
        }
        set
        {
            gameDifficulty = value;
        }
    }
    public static int GameMode
    {
        get
        {
            return gameMode;
        }
        set
        {
            gameMode = value;
        }
    }
}
