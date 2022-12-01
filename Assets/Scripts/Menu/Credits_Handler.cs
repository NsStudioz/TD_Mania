using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Credits_Handler : MonoBehaviour
{

    // SHOW/HIDE Credits Contributors based on categories
    [SerializeField] GameObject _CategoriesMenu;
    [SerializeField] GameObject _MyText;
    [SerializeField] GameObject _AssetsMenu;
    [SerializeField] GameObject _SFXMenu;
    [SerializeField] GameObject _MusicMenu;
    [SerializeField] GameObject _BackButton;

    void Start()
    {
        CloseAllSubCategories();
    }

    public void ShowAssetsMenu()
    {
        CloseMainCategories();
        //
        _BackButton.SetActive(true);
        _AssetsMenu.SetActive(true);
    }

    public void ShowSFXMenu()
    {
        CloseMainCategories();
        //
        _BackButton.SetActive(true);
        _SFXMenu.SetActive(true);
    }

    public void ShowMusicMenu()
    {
        CloseMainCategories();
        //
        _BackButton.SetActive(true);
        _MusicMenu.SetActive(true);
    }

    public void BackBTN_ToCategoriesList()
    {
        _MyText.SetActive(true);
        _CategoriesMenu.SetActive(true);
        //
        CloseAllSubCategories();
    }

    private void CloseAllSubCategories()
    {
        _BackButton.SetActive(false);
        _AssetsMenu.SetActive(false);
        _SFXMenu.SetActive(false);
        _MusicMenu.SetActive(false);
    }

    private void CloseMainCategories()
    {
        _MyText.SetActive(false);
        _CategoriesMenu.SetActive(false);
    }
}
