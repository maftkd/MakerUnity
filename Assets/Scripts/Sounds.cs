using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sounds : MonoBehaviour
{
    private AudioClip applause;
    private AudioClip barkingDog;
    private AudioClip fireAlarm;
    private AudioClip funkyJazz;
    public AudioClip talkingStudents;
    public AudioClip thunderstorm;
    public AudioClip whales;
    public AudioClip screaming;
    public AudioClip waterflow;
    public AudioClip squeakyMetal;
    public AudioClip windChimes;
    public AudioClip hyenas;
    public AudioClip rumbling;
    public AudioClip horrorTone;
    public AudioClip piercingStatic;
    public AudioClip cricketsInTheRain;

    private void Awake()
    {
        LoadSounds();
    }

    private void LoadSounds()
    {
        applause = Resources.Load<AudioClip>("Sounds/Applause");
        barkingDog = Resources.Load<AudioClip>("Sounds/BarkingDog");
        fireAlarm = Resources.Load<AudioClip>("Sounds/FireAlarm");
        funkyJazz = Resources.Load<AudioClip>("Sounds/FunkyJazz");
        talkingStudents = Resources.Load<AudioClip>("Sounds/TalkingStudents");
        thunderstorm = Resources.Load<AudioClip>("Sounds/Thunderstorm");
        whales = Resources.Load<AudioClip>("Sounds/WhaleSong");
        screaming = Resources.Load<AudioClip>("Sounds/Screaming");
        waterflow = Resources.Load<AudioClip>("Sounds/Waterflow");
        squeakyMetal = Resources.Load<AudioClip>("Sounds/SqueakyMetal");
        windChimes = Resources.Load<AudioClip>("Sounds/WindChimes");
        hyenas = Resources.Load<AudioClip>("Sounds/Hyenas");
        rumbling = Resources.Load<AudioClip>("Sounds/Rumbling");
        horrorTone = Resources.Load<AudioClip>("Sounds/HorrorTone");
        piercingStatic = Resources.Load<AudioClip>("Sounds/PiercingStatic");
        cricketsInTheRain = Resources.Load<AudioClip>("Sounds/CricketsInTheRain");
    }
}