using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using Moods = LightingHelper.Moods;

[CreateAssetMenu(menuName = "Classrooms")]
public class Room : ScriptableObject
{
    public GameObject Collider;
    public GameObject Ceiling;
    public GameObject Floor;
    public List<GameObject> Walls = new();
    public string RoomName;

    private Renderer CeilingRenderer;
    private Renderer FloorRenderer;
    private List<Renderer> WallRenderers;
    private AudioSource AudioSource;
    private int moodIndex;
    
    //frame of reference
    public Vector3 origin;
    public Vector3 xAxis;
    public Vector3 zAxis;
    public Vector2 size;

    public void Setup(GameObject floor, GameObject ceiling, List<GameObject> walls, GameObject collider)
    {
        Floor = floor;
        Ceiling = ceiling;
        Walls = walls;
        Collider = collider;

        InitializeRenderers();

        // temp - set to a random mood on start
        int numMoods = Enum.GetNames(typeof(Moods)).Length;
        Moods randomMood = (Moods)UnityEngine.Random.Range(0, numMoods);
        SetMood(randomMood);

        CalculateLocalBoundingBox();
    }

    private void InitializeRenderers()
    {
        if (Floor != null)
            FloorRenderer = Floor.GetComponent<Renderer>();

        if (Ceiling != null)
            CeilingRenderer = Ceiling.GetComponent<Renderer>();

        WallRenderers = new List<Renderer>();
        for (int i = 0; i < Walls.Count; i++)
        {
            WallRenderers.Add(Walls[i].GetComponent<Renderer>());
        }
    }

    public void SetCeilingTexture(Texture myTexture)
    {
        SetTexture(CeilingRenderer, myTexture);
    }

    public void SetFloorTexture(Texture myTexture)
    {
        SetTexture(FloorRenderer, myTexture);
    }

    public void SetWallTexture(Texture myTexture, int i)
    {
        if (i >= 0 && i < WallRenderers.Count)
        {
            SetTexture(WallRenderers[i], myTexture);
        }
        else
        {
            Debug.LogError("Wall index out of range.");
        }
    }

    public void SetAllWallsTexture(Texture myTexture)
    {
        for (int i=0; i < WallRenderers.Count; i++)
        {
            SetTexture(WallRenderers[i], myTexture);
        }
    }

    private void SetTexture(Renderer rend, Texture myTexture)
    {

        if (myTexture != null)
        {
            if (rend != null && rend.material != null)
            {
                rend.material.mainTexture = myTexture;
            }
            else
            {
                Debug.LogError("Renderer Component not found or material missing");
            }
        }
        else
        {
            return;
        }
    }

    public void SetSoundEffect(AudioClip sound)
    {
        TriggerSFX sfxScript = Collider.AddComponent<TriggerSFX>();
        sfxScript.sound_Clip = sound;
    }

    public void SpawnSpheres(string color, int amount)
    {
        MeshFilter meshFilter = Floor.GetComponent<MeshFilter>();

        Vector3 localCenter = meshFilter.mesh.bounds.center;
        Vector3 floorCenter = meshFilter.transform.TransformPoint(localCenter);

        GameObject redSphere = Resources.Load<GameObject>("Prefabs/RedSphere");
        GameObject blueSphere = Resources.Load<GameObject>("Prefabs/BlueSphere");
        GameObject greenSphere = Resources.Load<GameObject>("Prefabs/GreenSphere");


        if (color == "red")
        {
            for (int i = 0; i < amount; i++)
            {
                GameObject instance = GameObject.Instantiate(redSphere);
                instance.transform.SetLocalPositionAndRotation(floorCenter, Quaternion.Euler(0, 0, 0));
            }
        }
        else if (color == "blue")
        {
            for (int i = 0; i < amount; i++)
            {
                GameObject instance = GameObject.Instantiate(blueSphere);
                instance.transform.SetLocalPositionAndRotation(floorCenter, Quaternion.Euler(0, 0, 0));
            }
        }
        else if (color == "green")
        {
            for (int i = 0; i < amount; i++)
            {
                GameObject instance = GameObject.Instantiate(greenSphere);
                instance.transform.SetLocalPositionAndRotation(floorCenter, Quaternion.Euler(0, 0, 0));
            }
        }
    }

    public void SetMood(LightingHelper.Moods mood)
    {
        //LightingHelper.Instance.SetMood(this, mood);
        moodIndex = (int)mood;
        
        if (FloorRenderer != null)
        {
            FloorRenderer.material.SetInt("_MoodIndex", moodIndex);
        }
        if(CeilingRenderer != null)
        {
            CeilingRenderer.material.SetInt("_MoodIndex", moodIndex);
        }
        foreach(Renderer wallRenderer in WallRenderers)
        {
            wallRenderer.material.SetInt("_MoodIndex", moodIndex);
        }
    }

    // this method will help determine axis-aligned bounding box for the room
    // and will be used to place lights and other things
    // It is somewhat complicated b/c geometry has a single origin, same orientation, and scale x100
    // Uses ceiling mesh to determine position, orientation, and scale
    void CalculateLocalBoundingBox()
    {
        if (Ceiling != null)
        {
            Mesh ceilingMesh = Ceiling.GetComponent<MeshFilter>().sharedMesh;

            if (ceilingMesh.isReadable)
            {
                Debug.Log("Got bounds");
                //arbitrarily choose first vertex as origin
                origin = Ceiling.transform.TransformPoint(ceilingMesh.vertices[0]);
                //arbitrarily choose second vertex as x-axis
                Vector3 next = Ceiling.transform.TransformPoint(ceilingMesh.vertices[1]);
                
                xAxis = (next - origin).normalized;
                zAxis = Vector3.Cross(xAxis, Vector3.up).normalized;

                size = Vector2.zero;
                foreach(Vector3 vert in ceilingMesh.vertices)
                {
                    Vector3 globalPoint = Ceiling.transform.TransformPoint(vert);
                    Vector3 localVector = globalPoint - origin;
                    Vector3 xProject = Vector3.Project(localVector, xAxis);
                    size.x = Mathf.Max(size.x, xProject.magnitude);
                    Vector3 zProject = Vector3.Project(localVector, zAxis);
                    size.y = Mathf.Max(size.y, zProject.magnitude);
                }
            }

        }
    }
}


