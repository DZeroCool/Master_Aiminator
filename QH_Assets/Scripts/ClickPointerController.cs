using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This class is Controlling ClickPointer
// public var lifeTime control how long clickpoint staying in screen.
// Dont input number larger than 0.1, it may wrongly interact with other objects.

public class ClickPointerController : MonoBehaviour
{
    public float lifeTime;
    private float startTime;

    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if ((Time.time - startTime) >= lifeTime)
        {
            Destroy(this.gameObject);
        }
    }

    // detect click, destroy itself
    private void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(this.gameObject);
    }
}
