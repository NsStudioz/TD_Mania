using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Shop_Category_UI : MonoBehaviour
{
    [SerializeField] GameObject items_TurretCategory;
    [SerializeField] GameObject items_Traps_Category;
    [SerializeField] GameObject items_Arsenal_Category;

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
    }

    public void OnTrapsCategoryClick()
    {
        items_TurretCategory.SetActive(false);
        items_Traps_Category.SetActive(true);
        items_Arsenal_Category.SetActive(false);
    }

    public void OnArsenalCategoryClick()
    {
        items_TurretCategory.SetActive(false);
        items_Traps_Category.SetActive(false);
        items_Arsenal_Category.SetActive(true);
    }

    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene(mainMenuSceneIndex);
    }
}
