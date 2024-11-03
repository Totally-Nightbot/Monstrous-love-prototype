using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAudioOnLoadSCRN : MonoBehaviour
{
    public GameObject bgin; // Load screen
    public AudioClip audioClip;

    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>(); // Use the existing AudioSource component
        audioSource.clip = audioClip;
    }

    void Update()
    {
        if (bgin.activeSelf && !audioSource.isPlaying) // Check bgin is active and audio is not already playing
        {
            audioSource.Play();
        }
    }
}