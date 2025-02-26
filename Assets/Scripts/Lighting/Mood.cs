using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Mood")]
public class Mood : ScriptableObject
{
    public Color ambientColor;
    [Tooltip("Units are number of point lights / square meter")]
    [Range(0, 0.5f)]
    public float lightSourceDensity;
}
