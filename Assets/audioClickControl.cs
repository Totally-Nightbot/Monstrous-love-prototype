using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class audioClickControl : MonoBehaviour
{
    private AudioSource audioSource;

    public AudioClip audioClip; // Assign in Editor

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        if (audioClip != null)
        {
            audioSource.clip = audioClip;
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) //left mouse click
        {
            if (audioSource.clip != null)
            {
                audioSource.Play(); 
            }
        }
    }
}