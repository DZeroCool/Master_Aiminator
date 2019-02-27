using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistolSTG : MonoBehaviour
{
    private Vector2 offset;

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 cameraPosition = Camera.main.transform.position;
        transform.position = cameraPosition + offset;
    }
}
