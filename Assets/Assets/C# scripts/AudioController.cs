using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    

    private AudioSource source;
    // Start is called before the first frame update


    private void Start()
    {
        source = GetComponent<AudioSource>();
        source.volume = 0f;
        StartCoroutine(fade(true, source, 2f, 1f));
        StartCoroutine(fade(false, source, 2f, 1f));
    }

    private void Update()
    {
        if (!source.isPlaying)
        {
            source.Play();
            StartCoroutine(fade(true, source, 2f, 1f));
            StartCoroutine(fade(false, source, 2f, 1f));

        }
        

    

    }


    // fade in instantly, then when the duration is up, fade out
    public IEnumerator fade(bool fadein, AudioSource source, float duration, float targetVolume)

    {
        if (!fadein)
        {
            double lengthOfSource = (double)source.clip.samples / source.clip.frequency;
            yield return new WaitForSecondsRealtime((float)(lengthOfSource - duration));


        }
        float time = 0f;
        float startVol = source.volume;
        while (time < duration)
        {
            string fadeSituation = fadein ? "fadein" : "fadeout";
            time += Time.deltaTime;
            source.volume = Mathf.Lerp(startVol, targetVolume, time / duration);
            yield return null;

        }

        
        yield break;
    }

   
}
