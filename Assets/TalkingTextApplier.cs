using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkingTextApplier : MonoBehaviour
{
    public AudioSource AudioNeeded; 
    private bool playerInTrigger = false; 

    private void Update()
    {
        if (playerInTrigger && (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return)))
        {
            //below is to randomise where in the audio it starts from and for how long it lasts
            float randomDuration = Random.Range(2f, 4f); 
            StartCoroutine(PlayRandomSegment(randomDuration));
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger entered by: " + other.gameObject.name);
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player entered trigger"); 
            playerInTrigger = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Trigger exited by: " + other.gameObject.name); 
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player exited trigger"); 
            playerInTrigger = false;
            AudioNeeded.Stop(); 
        }
    }

    private IEnumerator PlayRandomSegment(float duration)
    {
        float clipLength = AudioNeeded.clip.length;
        float randomStartTime = Random.Range(0, clipLength - duration); 
        AudioNeeded.time = randomStartTime; 
        AudioNeeded.Play();
        yield return new WaitForSeconds(duration);
        AudioNeeded.Stop();
    }
}
