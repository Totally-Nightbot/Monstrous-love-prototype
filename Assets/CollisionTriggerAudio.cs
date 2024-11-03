using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionTriggerAudio : MonoBehaviour
{
    public AudioSource AudioNeeded; // Reference to AudioSource component

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger entered by: " + other.gameObject.name); 
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player entered trigger"); 
            AudioNeeded.Play();
        }



    }
    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Trigger exited by: " + other.gameObject.name); 
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player exited trigger"); 
            AudioNeeded.Stop();
        }
    }
}