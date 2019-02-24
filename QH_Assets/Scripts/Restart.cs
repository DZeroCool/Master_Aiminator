//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    // This method restart game by loading Start scene
    public void RestartGame()
    {
        //Application.LoadLevel("Start");
        SceneManager.LoadScene("Start");
    }

}
