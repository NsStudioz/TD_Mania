using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu_Handler : MonoBehaviour
{

    [Header("Menu Switches")]
    //[SerializeField] bool isMainMenuOpened;
    //[SerializeField] bool shopMenu = false;
    [SerializeField] bool playMenu = false;
    [SerializeField] bool optionsMenu = false;
    [SerializeField] bool creditsMenu = false;
    
    [Header("Scenes Index")]
    [SerializeField] int mainMenuIndex = 0;
    [SerializeField] int shopMenuIndex = 1;
    //[SerializeField] int currentSceneIndex = 0;

    [SerializeField] string urlAddress;

    public void OpenMainMenu() // When leaving SHOP SCENE;
    {
        SceneManager.LoadScene(mainMenuIndex);
    }

    public void OpenShopMenu()
    {
        SceneManager.LoadScene(shopMenuIndex);
    }

    public void OpenPlayMenu()
    {
        playMenu = true;
    }

    public void OpenOptionsMenu()
    {
        optionsMenu = true;
    }

    public void OpenCreditsMenu()
    {
        creditsMenu = true;
    }

    public void OpenPrivacyPage()
    {
        Application.OpenURL(urlAddress);
    }

    public void ClosePopUpMenus()
    {
        playMenu = false;
        optionsMenu = false;
        creditsMenu = false;
    }
}
