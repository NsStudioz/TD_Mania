using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour
{
    [SerializeField] Sound[] musicList;

    [SerializeField] int currentSceneIndex = 0;

    private const float setMusicVolumeToZero = 0f;

    [Header("Music Swap Attributes")]
    [SerializeField] bool playNextTrack = false;
    [SerializeField] bool stopLastTrack = false;
    [SerializeField] bool startDelayTime = false;
    [SerializeField] bool stateSwitch = false;
    // Timers
    [SerializeField] float timeElapsed = 0f;
    [SerializeField] const float timeElapsedDefaultValue = 0f;
    [SerializeField] float timeToFade = 1f;
    [SerializeField] float timerThreshold = 1f; // delay time for function: DelayTimeToSwitchBools()
    // Lerp Vars:
    private const float lerpMaxValue = 1f;
    private const float lerpMinValue = 0f;

    private void Awake()
    {
        foreach(Sound music in musicList)
        {
            music.source = gameObject.AddComponent<AudioSource>();
            music.source.clip = music.clip;
            //
            music.source.volume = music.volume;
            music.source.pitch = music.pitch;
            music.source.loop = music.loop;
            music.source.mute = music.mute;
        }
    }

    void Start()
    {
        SetMusicMuteSettings();

        SetMusicVolumeToZero();

        StartCoroutine(DelayTimeToPlayMainMenuTheme());

        foreach(Sound m in musicList) // 'm' - means music;
        {
            m.source.loop = true;
        }
    }

    void Update()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
    }
    //------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    // Music Functions (also applicable to buttons):
    public void Play(string name)
    {
        Sound m = Array.Find(musicList, music => music.name == name);
        if (m == null)
        {
            Debug.Log("Sound: " + name + " has not been found!");
            return;
        }
        m.source.Play();
    }

    public void Stop(string name)
    {
        Sound m = Array.Find(musicList, music => music.name == name);
        if(m == null)
        {
            Debug.Log("Sound: " + name + " has not been found!");
            return;
        }
        m.source.Stop();
    }

    public void StopAllMusic() // 'm' - means music;
    {
        foreach (Sound m in musicList)
        {
            m.source.Stop();
        }
    }

    private void MusicMute() // 'm' - means music;
    {
        foreach (Sound m in musicList)
        {
            m.source.mute = true;
        }
    }

    private void MusicUnmute() // 'm' - means music;
    {
        foreach(Sound m in musicList)
        {
            m.source.mute = false;
        }
    }

    private void SetMusicVolumeToZero() // 'm' - means music;
    {
        foreach (Sound m in musicList)
        {
            m.source.volume = setMusicVolumeToZero;
        }
    }

    //------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    // Music Settings:
    public void SetMusicMuteSettings()
    {
        if (PlayerPrefs.GetInt("M_Muted") == 1)
        {
            MusicMute();
        }
        else if (PlayerPrefs.GetInt("M_Muted") == 0)
        {
            MusicUnmute();
        }
    }

    //------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    // Music Swap Process:
    private IEnumerator FadeInTrack(string name)
    {
        Sound m = Array.Find(musicList, music => music.name == name);

        if(m == null)
        {
            Debug.Log("Sound: " + name + " has not been found");
        }

        timeElapsed = 0f;

        if (playNextTrack)
        {
            m.source.Play();

            while(timeElapsed < timeToFade)
            {
                m.source.volume = Mathf.Lerp(lerpMinValue, lerpMaxValue, timeElapsed / timeToFade);
                timeElapsed += Time.deltaTime;
                yield return null;
            }
        }
    }
    private IEnumerator FadeOutTrack(string name)
    {
        Sound m = Array.Find(musicList, music => music.name == name);

        if (m == null)
        {
            Debug.Log("Sound: " + name + " has not been found");
        }

        timeElapsed = 0f;

        if (stopLastTrack)
        {
            while(timeElapsed < timeToFade)
            {
                m.source.volume = Mathf.Lerp(lerpMaxValue, lerpMinValue, timeElapsed / timeToFade);
                timeElapsed += Time.deltaTime;
                yield return null;
            }
            m.source.Stop();
        }
    }

    private IEnumerator ResetBools() // reset all bool states back to 0 \ false.
    {
        //startDelayTime = true;

        yield return new WaitForSecondsRealtime(timerThreshold);

        //startDelayTime = false;
        playNextTrack = false;
        stopLastTrack = false;
    }

    public void SwapTracks(string oldTrack, string newTrack)
    {
        StartCoroutine(FadeOutTrack(oldTrack)); // stop last track, do a fade-out.
        StartCoroutine(FadeInTrack(newTrack));  // start new track, do a fade-in.

        StartCoroutine(ResetBools()); // switch all bools to false after a set amount of time to reset the swap track process.
    }

    private IEnumerator DelayTimeToPlayMainMenuTheme() // after splash screen
    {
        StartCoroutine(FadeInTrack("")); // FILL IN ONCE HAVE FILE!!!!

        yield return new WaitForSecondsRealtime(timerThreshold);

        playNextTrack = false;
        stopLastTrack = false;
    }




}
