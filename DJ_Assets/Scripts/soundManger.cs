using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundManger : MonoBehaviour
{
    public AudioSource good;
    public AudioSource hurt;
    public AudioSource out_of_gum;
    public AudioSource ugly;
    public AudioSource you_and_me;
    public AudioSource back_2_work;
    public AudioSource clean_up;
    public AudioSource come_get_some;


    public static AudioClip DukeNukemSaying1;
    public static AudioClip DukeNukemSaying2;
    public static AudioClip DukeNukemSaying3;
    public static AudioClip DukeNukemSaying4;
    public static AudioClip DukeNukemSaying5;
    public static AudioClip DukeNukemSaying6;
    public static AudioClip DukeNukemSaying7;
    public static AudioClip DukeNukemSaying8;

    static AudioSource audioSRC;

    // to deley sound playing
    private bool play;
    private float playStartTime;
    private float playStopTime;
    // Start is called before the first frame update
    void Start()
    {
        DukeNukemSaying1 = Resources.Load<AudioClip> ("gotta_hurt");
        DukeNukemSaying2 = Resources.Load<AudioClip>("out_of_gum_x");
        DukeNukemSaying3 = Resources.Load<AudioClip>("ugly");
        DukeNukemSaying4 = Resources.Load<AudioClip>("you_and_me");
        DukeNukemSaying5 = Resources.Load<AudioClip>("back_2_work_y");
        DukeNukemSaying6 = Resources.Load<AudioClip>("clean-up");
        DukeNukemSaying7 = Resources.Load<AudioClip>("come_get_some_x");
        DukeNukemSaying8 = Resources.Load<AudioClip>("good");

        audioSRC = GetComponent<AudioSource>();
        play = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayGood()
    {

        int i = Random.RandomRange(1, 9);
        Debug.Log(i);

        if (play)
        {
            switch (i)
            {
                case 1:
                    good.Play();
                    play = false;
                    playStartTime = Time.time;
                    playStopTime = playStartTime + 1.6f;
                    break;
                case 2:
                    hurt.Play();
                    play = false;
                    playStartTime = Time.time;
                    playStopTime = playStartTime + 2.4f;
                    break;
                case 3:
                    out_of_gum.Play();
                    play = false;
                    playStartTime = Time.time;
                    playStopTime = playStartTime + 4.8f;
                    break;
                case 4:
                    ugly.Play();
                    play = false;
                    playStartTime = Time.time;
                    playStopTime = playStartTime + 2f;
                    break;
                case 5:
                    you_and_me.Play();
                    play = false;
                    playStartTime = Time.time;
                    playStopTime = playStartTime + 3.55f;
                    break;
                case 6:
                    back_2_work.Play();
                    play = false;
                    playStartTime = Time.time;
                    playStopTime = playStartTime + 2.4f;
                    break;
                case 7:
                    clean_up.Play();
                    play = false;
                    playStartTime = Time.time;
                    playStopTime = playStartTime + 2.4f;
                    break;
                case 8:
                    come_get_some.Play();
                    play = false;
                    playStartTime = Time.time;
                    playStopTime = playStartTime + 1.6f;
                    break;

            }
        } else
        {
            if (Time.time > playStopTime)
            {
                play = true;
            }
        }
    }

    public void PlaySound(int i)
    {
        switch (i) { 
            case 1:
                audioSRC.PlayOneShot(DukeNukemSaying1);
                break;

            case 2:
                audioSRC.PlayOneShot(DukeNukemSaying2);
                break;

            case 3:
                audioSRC.PlayOneShot(DukeNukemSaying3);
                break;

            case 4:
                audioSRC.PlayOneShot(DukeNukemSaying4);
                break;

            case 5:
                audioSRC.PlayOneShot(DukeNukemSaying5);
                break;

            case 6:
                audioSRC.PlayOneShot(DukeNukemSaying6);
                break;

            case 7:
                audioSRC.PlayOneShot(DukeNukemSaying7);
                break;

            case 8:
                audioSRC.PlayOneShot(DukeNukemSaying8);
                break;


        }
    }
}
