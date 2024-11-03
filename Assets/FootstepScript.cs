using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootstepScript : MonoBehaviour
{
    public AudioSource footstepAudio; 
    private bool isPlaying = false; // To track if the audio is currently playing
    private bool hasMoved = false;

    void start()
    {
        hasMoved = false;
        StopFootsteps();
    }

    void PlayFootsteps()
    {
        if (!isPlaying)
        {
            footstepAudio.Play();
            isPlaying = true;
        }
    }

    void StopFootsteps()
    {
        if (isPlaying)
        {
            footstepAudio.Stop();
            isPlaying = false;
        }
    }

    void Update()
    {
        if (Input.GetKey("w") || Input.GetKey("a") || Input.GetKey("s") || Input.GetKey("d"))
        {
            if (!hasMoved)
            {
                hasMoved = true;
            }
            PlayFootsteps();
        }
        else if (hasMoved)
        {
            StopFootsteps();
        }
    }
    }