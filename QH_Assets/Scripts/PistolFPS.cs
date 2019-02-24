using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistolFPS : MonoBehaviour
{

    public GameObject Crosshair;
    private Vector2 offSet;
    // Start is called before the first frame update
    void Start()
    {
        Vector2 pistolIniPosition = transform.position;
        Vector2 crossIniPosition = Crosshair.transform.position;
        offSet = pistolIniPosition - crossIniPosition;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 crossCurPosition = Crosshair.transform.position;
        transform.position = crossCurPosition + offSet;

    }
}
