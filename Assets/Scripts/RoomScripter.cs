using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomScripter : MonoBehaviour
{
    private RoomManager roomManager;
    public Textures textures;
    public Sounds sounds;

    // Start is called before the first frame update
    void Start()
    {
        roomManager = FindObjectOfType<RoomManager>();

    }

}