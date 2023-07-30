using UnityEngine;
using UnityEngine.UI;

namespace TD_Mania_MainMenu
{
    public class Credits_Handler : MonoBehaviour
    {

        // SHOW/HIDE Credits Contributors based on categories
        [Header("Main Categories Menu")]
        [SerializeField] private GameObject _MainCategoriesMenu;
        [SerializeField] private GameObject _MeText;

        [Header("Sub Categories Menus")]
        [SerializeField] private GameObject _AssetsMenu;
        [SerializeField] private GameObject _SFXMenu;
        [SerializeField] private GameObject _MusicMenu;

        [Header("Buttons")]
        [SerializeField] private Button creditsBack_Btn; // this is a sub category button, will return to the main categories menu of Credits/
        [SerializeField] private Button assets_Btn;
        [SerializeField] private Button sfx_Btn;
        [SerializeField] private Button music_Btn;

        private void OnEnable()
        {
            creditsBack_Btn.onClick.AddListener(() =>
            {
                HideAllSubCategoriesMenus();
                HideCreditsBackButtonGameObject();
                ShowMainCategoriesMenu();
            });

            assets_Btn.onClick.AddListener(() =>
            {
                HideMainCategoriesMenu();
                ShowCreditsBackButtonGameObject();
                ShowAssetsMenu();
            });

            sfx_Btn.onClick.AddListener(() =>
            {
                HideMainCategoriesMenu();
                ShowCreditsBackButtonGameObject();
                ShowSFXMenu();
            });

            music_Btn.onClick.AddListener(() =>
            {
                HideMainCategoriesMenu();
                ShowCreditsBackButtonGameObject();
                ShowMusicMenu();
            });
        }

        private void OnDisable()
        {
            creditsBack_Btn.onClick.RemoveAllListeners();
            assets_Btn.onClick.RemoveAllListeners();
            sfx_Btn.onClick.RemoveAllListeners();
            music_Btn.onClick.RemoveAllListeners();
        }


        private void ShowMainCategoriesMenu()
        {
            _MeText.SetActive(true);
            _MainCategoriesMenu.SetActive(true);
        }
        private void HideMainCategoriesMenu()
        {
            _MeText.SetActive(false);
            _MainCategoriesMenu.SetActive(false);
        }

        private void HideAllSubCategoriesMenus()
        {
            _AssetsMenu.SetActive(false);
            _SFXMenu.SetActive(false);
            _MusicMenu.SetActive(false);
        }

        private void ShowAssetsMenu()
        {
            _AssetsMenu.SetActive(true);
        }

        private void ShowSFXMenu()
        {
            _SFXMenu.SetActive(true);
        }

        private void ShowMusicMenu()
        {
            _MusicMenu.SetActive(true);
        }

        private void HideCreditsBackButtonGameObject()
        {
            creditsBack_Btn.gameObject.SetActive(false);
        }
        private void ShowCreditsBackButtonGameObject()
        {
            creditsBack_Btn.gameObject.SetActive(true);
        }

    }

}
