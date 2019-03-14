using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{

    public AudioClip[] music;
    public AudioSource boombox;

    // Start is called before the first frame update
    void Start()
    {
        boombox.loop = true;
        boombox.volume = 0.8f;
        boombox.clip = music[Random.Range(0, music.Length)];
        boombox.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
