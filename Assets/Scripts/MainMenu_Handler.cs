using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu_Handler : MonoBehaviour
{

    [Header("Menu Switches")]
    [SerializeField] bool playMenu = false;
    [SerializeField] bool optionsMenu = false;
    [SerializeField] bool creditsMenu = false;
    
    [Header("Scenes Index")]
    [SerializeField] int mainMenuIndex = 0;
    [SerializeField] int shopMenuIndex = 1;
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

    public void OpenMainMenu() // When leaving SHOP SCENE;
    {
        SceneManager.LoadScene(mainMenuIndex);
    }

    public void OpenShopMenu()
    {
        SceneManager.LoadScene(shopMenuIndex);
    }

    //---------------------------------------------------------------------------------------------------------------------------------------------------------------------

    public void OpenPlayMenu()
    {
        playMenu = true;
        //menu_UI_AnimController.Play(play_UI_On);
    }

    public void OpenOptionsMenu()
    {
        optionsMenu = true;
        //menu_UI_AnimController.Play(options_UI_On);
    }

    public void OpenCreditsMenu()
    {
        creditsMenu = true;
        //menu_UI_AnimController.Play(credits_UI_On);
    }

    public void OpenPrivacyPage()
    {
        Application.OpenURL(urlAddress);
    }

    public void ClosePopUpMenus()
    {
        if (playMenu == true)
        {
            //menu_UI_AnimController.Play(play_UI_Off);
            playMenu = false;
        }
        else if (optionsMenu == true)
        {
            //menu_UI_AnimController.Play(options_UI_Off);
            optionsMenu = false;
        }
        else if (creditsMenu == true)
        {
            //menu_UI_AnimController.Play(credits_UI_Off);
            creditsMenu = false;
        }   
    }

    //---------------------------------------------------------------------------------------------------------------------------------------------------------------------

    public void ExitPlayMenu()
    {
        menu_UI_AnimController.Play(play_UI_Off);
        playMenu = false;
    }

    public void ExitOptionsMenu()
    {
        menu_UI_AnimController.Play(options_UI_Off);
        optionsMenu = false;
    }

    public void ExitCreditsMenu()
    {
        menu_UI_AnimController.Play(credits_UI_Off);
        creditsMenu = false;
    }
}
