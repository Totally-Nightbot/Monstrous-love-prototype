using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkingTextApplierNonDressUp : MonoBehaviour
{
    public AudioSource AudioNeeded; // Reference to the AudioSource component
    private bool playerInTrigger = false; // To track if the player is in the trigger area

    private void Update()
    {
        if (playerInTrigger && (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return) || Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.E)))
        {
            float randomDuration = Random.Range(2f, 4f); // Get a random duration between 2 and 4 seconds
            StartCoroutine(PlayRandomSegment(randomDuration));
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger entered by: " + other.gameObject.name); // Debug log
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player entered trigger"); // Debug log
            playerInTrigger = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Trigger exited by: " + other.gameObject.name); // Debug log
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player exited trigger"); // Debug log
            playerInTrigger = false;
            AudioNeeded.Stop(); // Ensure the audio stops when the player exits
        }
    }

    private IEnumerator PlayRandomSegment(float duration)
    {
        float clipLength = AudioNeeded.clip.length;
        float randomStartTime = Random.Range(0, clipLength - duration); // Calculate a random start time
        AudioNeeded.time = randomStartTime; // Set the start time
        AudioNeeded.Play();
        yield return new WaitForSeconds(duration);
        AudioNeeded.Stop();
    }
}