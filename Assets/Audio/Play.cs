using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Play : MonoBehaviour
{
    public AudioSource audioSource;

    private void OnParticleCollision(GameObject other)
    {
        if (!audioSource.isPlaying) // Prevent multiple overlaps
        {
            audioSource.Play();
        }
    }
}
