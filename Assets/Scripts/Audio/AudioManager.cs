using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    [SerializeField] Sound[] sounds;

    //public static AudioManager instance;

    private void Awake()
    {
        foreach (Sound sound in sounds)
        {
            sound.source = gameObject.AddComponent<AudioSource>();
            // Attributes:
            sound.source.clip = sound.clip;
            sound.source.volume = sound.volume;
            sound.source.pitch = sound.pitch;
            sound.source.loop = sound.loop;
            sound.source.mute = sound.mute;
            // 3D Sound:
            sound.source.spatialBlend = sound.spatialBlend;
            sound.source.maxDistance = sound.maxDistance;
            sound.source.minDistance = sound.minDistance;
            sound.source.rolloffMode = (AudioRolloffMode)sound.volumeRolloff; // Accessing the dropdown menu using a property.
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

// FOR MUTE\UNMUTE:
/*         Mute_New("Cannon_Fire");
         Mute_New("Missile_Fire");
         Mute_New("Plasma_Fire");
         Mute_New("Auto_Fire");
         Mute_New("LaserBeamer_Fire");
         Mute_New("Buffer_Activate");
         Mute_New("Unit_Built_1");
         Mute_New("Unit_Built_2");
         Mute_New("Plasma_Boom");
         Mute_New("Enemy_Boom");
         Mute_New("Trap_Boom");
         Mute_New("Trap_Beep");
         Mute_New("Bullet_Boom");
         Mute_New("Bullet_Auto_Boom");
         Mute_New("Missile_Boom");
         Mute_New("UI_Back");
         Mute_New("UI_Click_Menu");
         Mute_New("UI_Click_Ingame");
         Mute_New("UI_ClickError");
         Mute_New("UI_Popup");*/

/*    public void Mute_New(string name)
    {
        Sound sound = Array.Find(sounds, sound => sound.name == name);
        if (sound == null)
        {
            Debug.Log("Sound: " + name + " has not been found!");
            return;
        }
        sound.source.mute = true;
    }*/
