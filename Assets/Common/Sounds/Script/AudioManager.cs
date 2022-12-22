using UnityEngine.Audio;
using UnityEngine;
using System;
using System.Web;
using System.Collections.Generic;

public class AudioManager : MonoBehaviour
{

    public Sound[] sounds;
    private AudioSource[] audioSources;
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
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        foreach(Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
        }
        audioSourcesToVolumes = new Dictionary<string, float>();
        audioSources = FindObjectsOfType<AudioSource>();
        foreach(AudioSource audioSource in audioSources)
        {
            audioSourcesToVolumes.Add(audioSource.name, audioSource.volume);
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
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s != null)
        {
            s.source.PlayDelayed(delay);
        }
    }

    public void SetVolume(float volume)
    {
        foreach (Sound s in sounds)
        {
            s.source.volume = volume;
        }
        if (SceneLoader.IsSceneChanged()){
            audioSources = FindObjectsOfType<AudioSource>();
        }
        foreach (AudioSource audioSource in audioSources)
        {
            audioSource.volume = audioSourcesToVolumes[audioSource.name] * volume;
        }
        audioMixer.SetFloat("volume", volume);
        this.generalVolume = volume;
    }

    public float GetFixedVolumeForAudioSource(string audioSourceName)
    {
        return audioSourcesToVolumes[audioSourceName] * generalVolume;
    }
}
