using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    // animator of pistol
    private Animator pistolAnimator;

    // Start is called before the first frame update
    void Start()
    {
        // find animator of pistol
        GameObject pistol = GameObject.FindWithTag("Pistol");
        pistolAnimator = pistol.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // fire pistol
        if (Input.GetMouseButtonDown(0))
        {
            pistolAnimator.SetTrigger("PistolFire");
        }
    }

    public void play()
    {
        int gameMode = PlayerStates.GameMode;
        if (gameMode == 0)
        {
            loadRTSmode();
        } else if (gameMode == 1)
        {
            loadSTGmode();
        } else if (gameMode ==2)
        {
            loadFPSmode();
        }
    }


    public void loadRTSmode()
    {
        //Application.LoadLevel("RTS_Scene");
        SceneManager.LoadScene("RTS_Scene");
    }

    public void loadSTGmode()
    {
        //Application.LoadLevel("STG_Scene");
        SceneManager.LoadScene("STG_Scene");
    }

    public void loadFPSmode()
    {
        //Application.LoadLevel("FPS_Scene");
        SceneManager.LoadScene("FPS_Scene");
    }

    public void loadSetting()
    {
        //Application.LoadLevel("Setting");
        SceneManager.LoadScene("Setting");
    }

    public void quitGame()
    {
        Application.Quit();
    }
}
