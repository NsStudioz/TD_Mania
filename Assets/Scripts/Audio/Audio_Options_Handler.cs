using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio_Options_Handler : MonoBehaviour
{
    [SerializeField] GameObject sfx_Mute_Sign;
    [SerializeField] GameObject music_Mute_Sign;
    [SerializeField] AudioManager audioManager;
    [SerializeField] MusicManager musicManager;
    //private MainMenu_Handler menuHandler;

    [SerializeField] bool sfx_Muted;
    [SerializeField] bool music_Muted;

    private void Awake()
    {
        GameObject forAudioManager = GameObject.Find("Audio_Manager");
        audioManager = forAudioManager.GetComponent<AudioManager>();
        GameObject forMusicManager = GameObject.Find("Music_Manager");
        musicManager = forMusicManager.GetComponent<MusicManager>();
    }


    void Start()
    {
        CheckSoundSettings();
        CheckMusicSettings();
    }

    private void CheckSoundSettings()
    {
        if (!PlayerPrefs.HasKey("S_Muted"))
        {
            PlayerPrefs.SetInt("S_Muted", 0);
            LoadSoundSettings();
        }
        else
        {
            LoadSoundSettings();
        }
        UpdateSoundButtonIcons();
    }

    private void CheckMusicSettings()
    {
        if (!PlayerPrefs.HasKey("M_Muted"))
        {
            PlayerPrefs.SetInt("M_Muted", 0);
            LoadMusicSettings();
        }
        else
        {
            LoadMusicSettings();
        }
        UpdateMusicButtonIcons();
    }

    private void LoadSoundSettings()
    {
        sfx_Muted = PlayerPrefs.GetInt("S_Muted") == 1;
    }

    private void LoadMusicSettings()
    {
        music_Muted = PlayerPrefs.GetInt("M_Muted") == 1;
    }

    private void SaveSoundSettings()
    {
        PlayerPrefs.SetInt("S_Muted", sfx_Muted ? 1 : 0);
    }

    private void SaveMusicSettings()
    {
        PlayerPrefs.SetInt("M_Muted", music_Muted ? 1 : 0);
    }


    public void SoundMuteCheck()
    {
        if (sfx_Muted) { sfx_Muted = false; }
        else { sfx_Muted = true; }
        //
        UpdateSoundButtonIcons();
        SaveSoundSettings();
        //
        audioManager.PlayOneShot("UI_Click_Menu");
        audioManager.SetSoundMuteSettings();
    }

    public void MusicMuteCheck()
    {
        if (music_Muted) { music_Muted = false; }
        else { music_Muted = true; }
        //
        UpdateMusicButtonIcons();
        SaveMusicSettings();
        //
        audioManager.PlayOneShot("UI_Click_Menu");
        musicManager.SetMusicMuteSettings();
    }

    private void UpdateSoundButtonIcons()
    {
        if (sfx_Muted) { sfx_Mute_Sign.SetActive(true); }
        else { sfx_Mute_Sign.SetActive(false); }
    }

    private void UpdateMusicButtonIcons()
    {
        if (music_Muted) { music_Mute_Sign.SetActive(true); }
        else { music_Mute_Sign.SetActive(false); }
    }
}

/*public void SoundMuteOn()
{
    sfx_Muted = true;
    UpdateSoundButtonIcons();
    SaveSoundSettings();
}

public void SoundMuteOff()
{
    sfx_Muted = false;
    UpdateSoundButtonIcons();
    SaveSoundSettings();
}


public void MusicMuteOn()
{
    music_Muted = true;
    UpdateMusicButtonIcons();
    SaveMusicSettings();
}

public void MusicMuteOff()
{
    music_Muted = false;
    UpdateMusicButtonIcons();
    SaveMusicSettings();
}*/
