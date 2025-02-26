using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightingHelper : MonoBehaviour
{
    public Mood[] moods;

    public static LightingHelper Instance;

    private Vector4[] ambientColors;
    
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
        
        // Initialize ambient colors
        ambientColors = new Vector4[32];
        for (int i = 0; i < 32; i++)
        {
	        ambientColors[i] = Vector4.zero;
        }

        for (int i = 0; i < moods.Length && i < 32; i++)
        {
	        ambientColors[i] = ColorToVec4(moods[i].ambientColor);
        }
        
        Shader.SetGlobalVectorArray("_AmbientColors", ambientColors);
    }

    Vector4 ColorToVec4(Color c)
    {
	    return new Vector4(c.r, c.g, c.b, c.a);
    }
}
