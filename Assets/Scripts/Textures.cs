using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Textures : MonoBehaviour
{
    public Texture grass;
    public Texture asphalt;
    public Texture wood;
    public Texture bones;
    public Texture cobblestone;
    public Texture brick;
    public Texture forest;
    public Texture ice;
    public Texture lava;
    public Texture sand;
    public Texture water;

    private void Awake()
    {
        LoadTextures();
    }

    private void LoadTextures()
    {
        grass = Resources.Load<Texture>("Textures/grass");
        asphalt = Resources.Load<Texture>("Textures/asphalt");
        wood = Resources.Load<Texture>("Textures/wood");
        bones = Resources.Load<Texture>("Textures/bones");
        cobblestone = Resources.Load<Texture>("Textures/cobblestone");
        brick = Resources.Load<Texture>("Textures/brick");
        forest = Resources.Load<Texture>("Textures/forest");
        ice = Resources.Load<Texture>("Textures/ice");
        lava = Resources.Load<Texture>("Textures/lava");
        sand = Resources.Load<Texture>("Textures/sand");
        water = Resources.Load<Texture>("Textures/water");
    }
}