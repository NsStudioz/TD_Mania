using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelection : MonoBehaviour
{
    private int levelToSelect;
    [SerializeField] Animator animator;
    //
    public Button[] lvlButtons;

    AudioManager audioManager;

    private void Awake()
    {
        GameObject forAudioManager = GameObject.Find("Audio_Manager");
        audioManager = forAudioManager.GetComponent<AudioManager>();
    }

    void Start()
    {
        int levelAt = PlayerPrefs.GetInt("Level_At", 3);

        for (int i = 0; i < lvlButtons.Length; i++)
        {
            if (i + 3 > levelAt)
            {
                lvlButtons[i].interactable = false;
            }
        }
    }

    public void FadeLevel(int currentSceneIndex)
    {
        levelToSelect = currentSceneIndex;
        animator.SetTrigger("FadeScene");
        audioManager.PlayOneShot("UI_Click_Menu");
    }

    public void OnFadeComplete()
    {
        SceneManager.LoadScene(levelToSelect);
    }

}


