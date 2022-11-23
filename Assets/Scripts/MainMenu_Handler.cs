using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu_Handler : MonoBehaviour
{

    [Header("Menu Switches")]
    [SerializeField] bool playMenu = false;
    [SerializeField] bool optionsMenu = false;
    [SerializeField] bool creditsMenu = false;
    
    [Header("Scenes Index")]
    private int levelToLoad;
    [SerializeField] int mainMenuIndex = 1;
    [SerializeField] int shopMenuIndex = 2;
    //
    [SerializeField] string urlAddress;

    [Header("Animations")]
    [SerializeField] Animator menu_UI_AnimController;
    //
    [SerializeField] string play_UI_On;
    [SerializeField] string play_UI_Off;
    //
    [SerializeField] string options_UI_On;
    [SerializeField] string options_UI_Off;
    //
    [SerializeField] string credits_UI_On;
    [SerializeField] string credits_UI_Off;

    [Header("UI Objects")]
    [SerializeField] GameObject play_UI;
    [SerializeField] GameObject options_UI;
    [SerializeField] GameObject credits_UI;
    //
    public static event Action OnUIClick_Menu_SFX;
    public static event Action OnUIClick_Back_SFX;

    public void OpenMainMenu() // When leaving SHOP SCENE;
    {
        MenuClickSFX();
        SceneManager.LoadScene(mainMenuIndex);
    }

    public void OpenShopMenu()
    {
        MenuClickSFX();
        SceneManager.LoadScene(shopMenuIndex);
    }
    //---------------------------------------------------------------------------------------------------------------------------------------------------------------------

    public void OpenPlayMenu()
    {
        playMenu = true;
        play_UI.SetActive(true);
        MenuClickSFX();
        //menu_UI_AnimController.Play(play_UI_On);
    }

    public void OpenOptionsMenu()
    {
        optionsMenu = true;
        options_UI.SetActive(true);
        MenuClickSFX();
        //menu_UI_AnimController.Play(options_UI_On);
    }

    public void OpenCreditsMenu()
    {
        creditsMenu = true;
        credits_UI.SetActive(true);
        MenuClickSFX();
        //menu_UI_AnimController.Play(credits_UI_On);
    }

    public void OpenPrivacyPage()
    {
        MenuClickSFX();
        Application.OpenURL(urlAddress);
    }

    public void ClosePopUpMenus()
    {
        if (playMenu == true)
        {
            //menu_UI_AnimController.Play(play_UI_Off);
            playMenu = false;
            play_UI.SetActive(false);
        }
        else if (optionsMenu == true)
        {
            //menu_UI_AnimController.Play(options_UI_Off);
            optionsMenu = false;
            options_UI.SetActive(false);
        }
        else if (creditsMenu == true)
        {
            //menu_UI_AnimController.Play(credits_UI_Off);
            creditsMenu = false;
            credits_UI.SetActive(false);
        }
        MenuBackSFX();
    }

    //---------------------------------------------------------------------------------------------------------------------------------------------------------------------
    // For SFX:
    private void MenuClickSFX()
    {
        OnUIClick_Menu_SFX?.Invoke();
    }

    private void MenuBackSFX()
    {
        OnUIClick_Back_SFX?.Invoke();
    }

    //---------------------------------------------------------------------------------------------------------------------------------------------------------------------
    // For Animations:
    public void DeactivateAllMenus()
    {
        play_UI.SetActive(false);
        options_UI.SetActive(false);
        credits_UI.SetActive(false);
    }
}