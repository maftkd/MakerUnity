using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightingHelper : MonoBehaviour
{
    public Mood[] moods;

    public static LightingHelper Instance;
    
    //#hook to auto-generate enum
	public enum Moods
	{
		Default,
		Misty,
	}
	//#endhook
    
    void Awake()
    {
        Instance = this;
    }

    public void SetMood(Room room, Moods mood)
    {
        Mood myMood = moods[(int)mood];
    }
}
