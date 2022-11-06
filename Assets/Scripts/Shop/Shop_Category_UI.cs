using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Shop_Category_UI : MonoBehaviour
{
    [SerializeField] GameObject items_TurretCategory;
    [SerializeField] GameObject items_Traps_Category;
    [SerializeField] GameObject items_Arsenal_Category;

    public static event Action OnUIClick_Ingame_SFX;
    public static event Action OnUIClick_Back_SFX;

    private int mainMenuSceneIndex = 0;

    private void Start()
    {
        items_TurretCategory.SetActive(true);
        items_Traps_Category.SetActive(false);
        items_Arsenal_Category.SetActive(false);
    }

    public void OnTurretsCategoryClick()
    {
        items_TurretCategory.SetActive(true);
        items_Traps_Category.SetActive(false);
        items_Arsenal_Category.SetActive(false);
        PlayCategorySFX();
    }

    public void OnTrapsCategoryClick()
    {
        items_TurretCategory.SetActive(false);
        items_Traps_Category.SetActive(true);
        items_Arsenal_Category.SetActive(false);
        PlayCategorySFX();
    }

    public void OnArsenalCategoryClick()
    {
        items_TurretCategory.SetActive(false);
        items_Traps_Category.SetActive(false);
        items_Arsenal_Category.SetActive(true);
        PlayCategorySFX();
    }

    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene(mainMenuSceneIndex);
        OnUIClick_Back_SFX?.Invoke();
    }

    private void PlayCategorySFX()
    {
        OnUIClick_Ingame_SFX?.Invoke();
    }
}

/*    AudioManager audioManager;
    private void Awake()
    {
        GameObject forAudioManager = GameObject.Find("Audio_Manager");
        audioManager = forAudioManager.GetComponent<AudioManager>();
    }*/
//audioManager.PlayOneShot("UI_Back");
//audioManager.PlayOneShot("UI_Click_Ingame");