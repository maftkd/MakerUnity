using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightingHelper : MonoBehaviour
{
    public Mood[] moods;

    public static LightingHelper Instance;

    private Vector4[] ambientColors;

    public RoomManager roomManager;
    
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

        SetAmbientColors();
    }

    Vector4 ColorToVec4(Color c)
    {
	    return new Vector4(c.r, c.g, c.b, c.a);
    }

    void SetAmbientColors()
    {
        for (int i = 0; i < moods.Length && i < 32; i++)
        {
	        ambientColors[i] = ColorToVec4(moods[i].ambientColor);
        }
        
        Shader.SetGlobalVectorArray("_AmbientColors", ambientColors);
	    
    }

    public void UpdateLightingData()
    {
	    SetAmbientColors();
	    
	    // reposition lights
	    foreach (Room room in roomManager.GetRoomList())
	    {
		    SpawnPointLights(room, (Moods)room.moodIndex);
	    }
	    
	    //todo - set other colors if needed?
    }

    public void SpawnPointLights(Room room, Moods mood)
    {
	    // clear old lights
		// might be more efficient to pool, we shall see...
		room.lightPosTemp.Clear();
		for (int i = room.Ceiling.transform.childCount - 1; i >= 0; i--)
		{
			GameObject.Destroy(room.Ceiling.transform.GetChild(i).gameObject);
		}
		
	    Mood myMood = moods[(int)mood];
	    
	    float gridSize = Mathf.Sqrt(1f / myMood.lightSourceDensity);
	    int numCols = Mathf.FloorToInt(room.size.x / gridSize);
	    int numRows = Mathf.FloorToInt(room.size.y / gridSize);
	    
	    //add a couple rows and columns as a buffer of sorts to help with non rectangular rooms
	    //numCols += numCols;
	    //numRows += numRows;
	    
	    Vector3 gridStart = room.centerOfMass;
	    gridStart -= room.xAxis * (((numCols - 1) / 2f) * gridSize);
	    gridStart -= room.zAxis * (((numRows - 1) / 2f) * gridSize);
	    for (int y = 0; y < numRows; y++)
	    {
		    for (int x = 0; x < numCols; x++)
		    {
			    Vector3 pos = gridStart + room.xAxis * (x * gridSize) + room.zAxis * (y * gridSize);
			    room.lightPosTemp.Add(pos);
		    }
	    }

	    foreach (Vector3 pos in room.lightPosTemp)
	    {
		    GameObject pointLight = new GameObject("Point Light");
		    pointLight.transform.position = pos;
		    pointLight.transform.SetParent(room.Ceiling.transform);
		    
		    Light light = pointLight.AddComponent<Light>();
		    light.type = LightType.Point;
		    light.color = myMood.lightColor;
		    light.range = myMood.lightRadius;
		    light.intensity = myMood.lightIntensity;
	    }
    }
}
