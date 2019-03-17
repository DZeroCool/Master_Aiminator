using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController5Target : MonoBehaviour
{
    public GameObject Crosshair;
    private Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(Crosshair.transform.position.x, Crosshair.transform.position.y, offset.z);
    }
}
