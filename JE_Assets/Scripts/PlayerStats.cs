using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerStats
{
    private static int score, kills, streak, accuracy, misses;
    private static string currentGame;

    public static string CurrentGame
    {
        get
        {
            return currentGame;
        }
        set
        {
            currentGame = value;
        }
    }
    public static int Kills
    {
        get
        {
            return kills;
        }
        set
        {
            kills = value;
        }
    }

    public static int Score
    {
        get
        {
            return score;
        }
        set
        {
            score = value;
        }
    }

    public static int Streak
    {
        get
        {
            return streak;
        }
        set
        {
            streak = value;
        }
    }

    public static int Accuracy
    {
        get
        {
            return accuracy;
        }
        set
        {
            accuracy = value;
        }
    }
    public static int Misses
    {
        get
        {
            return misses;
        }
        set
        {
            misses = value;
        }
    }
}
