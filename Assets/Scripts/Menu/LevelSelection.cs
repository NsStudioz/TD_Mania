using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace TD_Mania_MainMenu
{
    public class LevelSelection : MonoBehaviour
    {

        [SerializeField] Animator animator;
        [SerializeField] private Button[] lvlButtons;
        //
        private int levelToSelect;
        private readonly int LevelSelectSceneIndexOffset = 3;
        //
        public static event Action OnUIClick_Menu_SFX;
        public static event Action OnUIclick_SwapTracks_MenuToBattle;

        void Start()
        {
            InitializeButtonInteractability();
            InitializeButtonToLevelSelectIndex(); // first level => level_0 = index 3; So LevelSelectSceneIndexOffset = 3;
        }

        private void InitializeButtonInteractability()
        {
            int levelAt = PlayerPrefs.GetInt("Level_At", LevelSelectSceneIndexOffset);

            for (int i = 0; i < lvlButtons.Length; i++)
                if (i + LevelSelectSceneIndexOffset > levelAt)
                    lvlButtons[i].interactable = false;
        }

        private void InitializeButtonToLevelSelectIndex()
        {
            for (int n = 0; n < lvlButtons.Length; n++)
                if (lvlButtons[n].interactable)
                {
                    int currentSceneIndex = n + LevelSelectSceneIndexOffset;
                    lvlButtons[n].onClick.AddListener(() => { GoToLevel(currentSceneIndex); });
                }
        }

        private void GoToLevel(int currentSceneIndex)
        {
            levelToSelect = currentSceneIndex;
            animator.SetTrigger("FadeScene");
            Event_OnUIClick_Menu_SFX();
        }

        // Animation event function:
        public void OnFadeComplete()
        {
            SceneManager.LoadScene(levelToSelect);
            Event_OnUIclick_SwapTracks_MenuToBattle();
        }

        private void Event_OnUIClick_Menu_SFX()
        {
            OnUIClick_Menu_SFX?.Invoke();
        }

        private void Event_OnUIclick_SwapTracks_MenuToBattle()
        {
            OnUIclick_SwapTracks_MenuToBattle?.Invoke();
        }

    }
}

