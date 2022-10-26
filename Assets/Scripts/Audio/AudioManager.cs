using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    [SerializeField] Sound[] sounds;

    public static AudioManager instance;

    private void Awake()
    {
        foreach (Sound sound in sounds)
        {
            sound.source = gameObject.AddComponent<AudioSource>();
            sound.source.clip = sound.clip;
            //
            sound.source.volume = sound.volume;
            sound.source.pitch = sound.pitch;
            sound.source.loop = sound.loop;
            sound.source.mute = sound.mute;
            sound.source.spatialBlend = sound.spatialBlend;
            sound.source.maxDistance = sound.maxDistance;
            sound.source.minDistance = sound.minDistance;
            sound.source.rolloffMode = (AudioRolloffMode)sound.volumeRolloff; // Accessing the dropdown menu using a property.
            //sound.source.PlayOneShot = sound.
        }
    }

    void Start()
    {
        SetSoundMuteSettings();
    }

    public void Play(string name)
    {
        Sound sound = Array.Find(sounds, sound => sound.name == name);
        if (sound == null)
        {
            Debug.Log("Sound: " + name + " has not been found!");
            return;
        }
        sound.source.Play();
    }

    public void PlayOneShot(string name)
    {
        Sound sound = Array.Find(sounds, sound => sound.name == name);
        if (sound == null)
        {
            Debug.Log("Sound: " + name + " has not been found!");
            return;
        }
        sound.source.PlayOneShot(sound.clip);
    }

    public void Mute()
    {
        foreach (Sound sound in sounds)
        {
            sound.source.mute = true;
        }
    }

    public void UnMute()
    {
        foreach (Sound sound in sounds)
        {
            sound.source.mute = false;
        }
    }

    public void Stop(string name)
    {
        Sound sound = Array.Find(sounds, sound => sound.name == name);
        if (sound == null)
        {
            Debug.Log("Sound: " + name + " has not been found!");
            return;
        }
        sound.source.Stop();
    }

    public void StopAllSound()
    {
        foreach (Sound sound in sounds)
        {
            sound.source.Stop();
        }
    }

    private void CheckForClipNamesInSoundArray(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.Log("Sound: " + name + " has not been found!");
            return;
        }
    }

    public void SetSoundMuteSettings()
    {
        if(PlayerPrefs.GetInt("S_Muted") == 1)
        {
            Mute();
        }
        else if(PlayerPrefs.GetInt("S_Muted") == 0)
        {
            UnMute();
        }
    }
}
