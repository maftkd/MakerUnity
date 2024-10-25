using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sounds : MonoBehaviour
{
//     public AudioClip applause;
//     public AudioClip barkingDog;
//     public AudioClip fireAlarm;
//     public AudioClip funkyJazz;
    public AudioClip talkingStudents;
    public AudioClip thunderstorm;
    public AudioClip whales;

    private void Awake()
    {
        LoadSounds();
    }

    private void LoadSounds()
    {
        // applause = Resources.Load<AudioClip>("Sounds/Applause");
        // barkingDog = Resources.Load<AudioClip>("Sounds/BarkingDog");
        // fireAlarm = Resources.Load<AudioClip>("Sounds/FireAlarm");
        // funkyJazz = Resources.Load<AudioClip>("Sounds/FunkyJazz");
        talkingStudents = Resources.Load<AudioClip>("Sounds/TalkingStudents");
        thunderstorm = Resources.Load<AudioClip>("Sounds/Thunderstorm");
        whales = Resources.Load<AudioClip>("Sounds/WhaleSong");
    }
}