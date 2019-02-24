using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameSetting : MonoBehaviour
{

    public Slider mouseSensiSlider;
    public InputField gameTimeInput;
    public Dropdown gameDifficulty;
    public Dropdown gameMode;

    // Start is called before the first frame update
    void Start()
    {
        mouseSensiSlider.minValue = 40;
        mouseSensiSlider.maxValue = 200;

    }

    // Update is called once per frame
    void Update()
    {
        setMouse();
        setGameTimt();
        setGameDifficulty();
        setGameMode();
    }

    public void setCrossType(int type)
    {
        PlayerStates.CrossType = type;

    }

    public void setMouse()
    {
        float sensitivity = mouseSensiSlider.value;
        PlayerStates.MouseSensitivity = sensitivity;
    }

    public void setGameTimt()
    {
        int gameTime = 10;
        try
        {
            gameTime = int.Parse(gameTimeInput.text);
            Debug.Log("game time: " + gameTime);
        }

        catch (FormatException e){
            return;
        }

        if (gameTime > 10 && gameTime <= 120)
        {
            PlayerStates.GameTime = gameTime;
        }  else if(gameTime > 120)
        {
            PlayerStates.GameTime = 120;
        }  else
        {
            PlayerStates.GameTime = 10;
        }
    }

    public void setGameDifficulty()
    {
        PlayerStates.GameDifficulty = gameDifficulty.value;
    }

    public void setGameMode()
    {
        PlayerStates.GameMode = gameMode.value;
    }
}
