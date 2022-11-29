using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelection : MonoBehaviour
{
    private int levelToSelect;
    [SerializeField] Animator animator;
    //
    public Button[] lvlButtons;
    //
    public static event Action OnUIClick_Menu_SFX;
    public static event Action OnUIclick_SwapTracks_MenuToBattle;

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
        OnUIClick_Menu_SFX?.Invoke();
    }

    public void OnFadeComplete()
    {
        SceneManager.LoadScene(levelToSelect);
        SwapTracks_MenuToBattle();
    }

    private void SwapTracks_MenuToBattle()
    {
        OnUIclick_SwapTracks_MenuToBattle?.Invoke();
    }

}
