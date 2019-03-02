using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    public void loadRTSmode()
    {
        Application.LoadLevel("RTS_Scene");
    }

    public void loadSTGmode()
    {
        Application.LoadLevel("STG_Scene");
    }

    public void loadFPSmode()
    {
        Application.LoadLevel("FPS_Scene");
    }

    public void loadSetting()
    {
        Application.LoadLevel("Setting");
    }
}
