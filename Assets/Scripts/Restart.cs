using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Restart : MonoBehaviour
{
    // This method restart game by loading Start scene
    public void RestartGame()
    {
        Application.LoadLevel("Start");
    }

}
