using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScarySoundStarter : MonoBehaviour
{

    public AudioClip[] audioClips;
    public int probability;

    private bool isPlaying = false;
    
    IEnumerator OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (!isPlaying)
            {
                isPlaying = true;
                yield return PlaySound(chooseRandomAudioClip());
                isPlaying = false;
            }
        }

        yield return new WaitForSeconds(0);
    }

    IEnumerator PlaySound(AudioClip audioClip)
    {
        if (audioClip != null)
        {
            AudioSource audioSource = GetComponent<AudioSource>();
            audioSource.clip = audioClip;
            audioSource.Play();

            yield return new WaitForSeconds(audioSource.clip.length);
        }
    }

    AudioClip chooseRandomAudioClip()
    {
        bool shouldPlay = Random.Range(0, probability) == probability / 2;

        if (shouldPlay)
        {
            int randomIndex = Random.Range(0, audioClips.Length);
            return audioClips[randomIndex];
        }

        return null;
    }
}
