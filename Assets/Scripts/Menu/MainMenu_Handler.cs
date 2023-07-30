using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace TD_Mania_MainMenu
{
    public class MainMenu_Handler : MonoBehaviour
    {

        public static event Action OnUIClick_PlayMenuSFX;
        public static event Action OnUIClick_PlayBackSFX;
        private readonly int shopMenuIndex = 2;

        [Header("Menu Switches")]
        [SerializeField] private bool isPlayUI_On = false;
        [SerializeField] private bool isOptionsUI_On = false;
        [SerializeField] private bool isCreditsUI_On = false;

        [Header("Privacy Web Address")]
        [SerializeField] private string urlAddress;

        [Header("UI Objects")]
        [SerializeField] private GameObject play_UI;
        [SerializeField] private GameObject options_UI;
        [SerializeField] private GameObject credits_UI;

        [Header("Buttons")]
        [SerializeField] private Button play_Btn;
        [SerializeField] private Button options_Btn;
        [SerializeField] private Button credits_Btn;
        [SerializeField] private Button privacy_Btn;
        [SerializeField] private Button shop_Btn;
        [SerializeField] private Button[] back_Btns;


        private void OnEnable()
        {
            ButtonsAddListeners();
            BackButtonsArrayAddListeners();
        }
        private void OnDisable()
        {
            ButtonsRemoveListeners();
            BackButtonsArrayRemoveListeners();
        }


        #region Button_OnClick_Initialize/Deactivate:

        private void ButtonsAddListeners()
        {
            play_Btn.onClick.AddListener(() =>
            {
                Event_OnUIClick_PlayMenuSFX();
                ShowPlayUI();
            });
            options_Btn.onClick.AddListener(() =>
            {
                Event_OnUIClick_PlayMenuSFX();
                ShowOptionsUI();
            });
            credits_Btn.onClick.AddListener(() =>
            {
                Event_OnUIClick_PlayMenuSFX();
                ShowCreditsUI();
            });
            privacy_Btn.onClick.AddListener(() =>
            {
                Event_OnUIClick_PlayMenuSFX();
                OpenPrivacyURLPage();
            });
            shop_Btn.onClick.AddListener(() =>
            {
                Event_OnUIClick_PlayMenuSFX();
                GoToShopScene();
            });
        }
        private void ButtonsRemoveListeners()
        {
            play_Btn.onClick.RemoveAllListeners();
            shop_Btn.onClick.RemoveAllListeners();
            options_Btn.onClick.RemoveAllListeners();
            credits_Btn.onClick.RemoveAllListeners();
            privacy_Btn.onClick.RemoveAllListeners();
        }

        private void BackButtonsArrayAddListeners()
        {
            foreach (var btn in back_Btns)
                btn.onClick.AddListener(() =>
                {
                    Event_OnUIClick_PlayBackSFX();
                    HideMainMenuWindowedUIs();
                });
        }

        private void BackButtonsArrayRemoveListeners()
        {
            foreach (var btn in back_Btns)
                btn.onClick.RemoveAllListeners();
        }

        #endregion


        #region Button_OnClick_Functions:

        private void GoToShopScene()
        {
            SceneManager.LoadScene(shopMenuIndex);
        }

        private void ShowPlayUI()
        {
            isPlayUI_On = true;
            play_UI.SetActive(true);
        }

        private void ShowOptionsUI()
        {
            isOptionsUI_On = true;
            options_UI.SetActive(true);
        }

        private void ShowCreditsUI()
        {
            isCreditsUI_On = true;
            credits_UI.SetActive(true);
        }

        private void OpenPrivacyURLPage()
        {
            Application.OpenURL(urlAddress);
        }

        // Back button function. Close: PlayUI, OptionsUI, CreditsUI.
        private void HideMainMenuWindowedUIs()
        {
            if (isPlayUI_On == true)
            {
                isPlayUI_On = false;
                play_UI.SetActive(false);
            }
            else if (isOptionsUI_On == true)
            {
                isOptionsUI_On = false;
                options_UI.SetActive(false);
            }
            else if (isCreditsUI_On == true)
            {
                isCreditsUI_On = false;
                credits_UI.SetActive(false);
            }
        }

        #endregion


        #region Events:

        private void Event_OnUIClick_PlayMenuSFX()
        {
            OnUIClick_PlayMenuSFX?.Invoke();
        }

        private void Event_OnUIClick_PlayBackSFX()
        {
            OnUIClick_PlayBackSFX?.Invoke();
        }

        #endregion
    }
}
