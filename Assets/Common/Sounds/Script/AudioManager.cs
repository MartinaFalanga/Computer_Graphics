using UnityEngine.Audio;
using UnityEngine;
using System;
using System.Web;
using System.Collections.Generic;

public class AudioManager : MonoBehaviour
{

    private Sound[] sounds;
    public List<AudioSource> audioSources = new List<AudioSource>();
    public Dictionary<string, float> audioSourcesToVolumes;
    public AudioMixer audioMixer;

    public static AudioManager instance;

    private float generalVolume;

    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        } else
        {
            UpdateValues();
            //Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);
        UpdateValues();
    }

    public void UpdateValues()
    {
        audioSourcesToVolumes = new Dictionary<string, float>();
        audioSources.Clear();
        audioSources = new List<AudioSource>(FindObjectsOfType<AudioSource>(true));
        if (audioSources != null && audioSources.Count != 0)
        {
            foreach (AudioSource audioSource in audioSources)
            {
                audioSourcesToVolumes.Add(audioSource.name, audioSource.volume);
            }
        }
    }

    public float GetGeneralVolume()
    {
        return generalVolume;
    }

    public void Play(string name)
    {
        PlayDelayed(name, 0f);
    }

    public void PlayDelayed(string name, float delay)
    {
        AudioSource s = null;
        foreach(AudioSource asource in audioSources){
            if(asource.name == name)
            {
                s = asource;
                break;
            }
        }
        if (s != null)
        {
            s.PlayDelayed(delay);
        }
    }

    public void SetVolume(float volume)
    {
        audioSources.Clear();
        audioSources = new List<AudioSource>(FindObjectsOfType<AudioSource>(true));
        if (audioSources != null && audioSources.Count != 0)
        {
            foreach (AudioSource audioSource in audioSources)
            {
                audioSource.volume = audioSourcesToVolumes[audioSource.name] * volume;
            }
            audioMixer.SetFloat("volume", volume);
            this.generalVolume = volume;
        }
    }

    public float GetFixedVolumeForAudioSource(string audioSourceName)
    {
        return audioSourcesToVolumes[audioSourceName] * generalVolume;
    }
}
