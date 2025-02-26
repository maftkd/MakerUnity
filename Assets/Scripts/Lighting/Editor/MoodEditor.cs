using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Mood))]
public class MoodEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        Mood mood = (Mood)target;

        if (Application.isPlaying && GUI.changed)
        {
            LightingHelper.Instance.UpdateLightingData();
        }
    }
}
