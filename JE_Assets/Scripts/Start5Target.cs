using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Start5Target : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void start5Target()
    {
        SceneManager.LoadScene("5Targets");
    }
    public void startLR()
    {
        SceneManager.LoadScene("TargetsLR");
    }
}
