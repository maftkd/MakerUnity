using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerSFX : MonoBehaviour
{
    public AudioClip sound_Clip;

    private AudioSource audioSource;
    private GameObject targetRoom;

    void Start()
    {
        // create an AudioSource and assign the loaded clip
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = sound_Clip;
        audioSource.playOnAwake = false;
    }

    private void OnTriggerEnter(Collider other)
    { 
        // Check if the collider belongs to player
        if (other.CompareTag("Player"))
        {
            // play sound effect
            if (audioSource != null && !audioSource.isPlaying)
            {
                audioSource.Play();
            }
            else
            {
                return;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Check if the collider belongs to player
        if (other.CompareTag("Player"))
        {
            // Stop sound effect if it is playing
            if (audioSource != null && audioSource.isPlaying)
            {
                audioSource.Stop();
            }
            else
            {
                return;
            }
        }
    }
}
