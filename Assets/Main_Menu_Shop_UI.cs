using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Main_Menu_Shop_UI : MonoBehaviour
{
    // ITEMS PANEL LIST (UP TO 9):
    public GameObject buttonItem1; // top left
    public GameObject buttonItem2; // top Center
    public GameObject buttonItem3; // top right
    public GameObject buttonItem4; // middle left
    public GameObject buttonItem5; // middle Center
    public GameObject buttonItem6; // middle right
    public GameObject buttonItem7; // bottom left
    public GameObject buttonItem8; // bottom Center
    public GameObject buttonItem9; // bottom right

/*    public Button item1;

    private void Start()
    {
        item1.interactable = !item1.interactable;
        item1.interactable = false;
        item1.interactable = true;
        
    }*/



    public void OnTurretsCategoryClick()
    {
        //Buttons Visibility:
        buttonItem1.SetActive(true);
        buttonItem2.SetActive(true);
        buttonItem3.SetActive(true);
        buttonItem4.SetActive(true);
        buttonItem5.SetActive(true);
        buttonItem6.SetActive(true);
        buttonItem7.SetActive(true);
        buttonItem8.SetActive(true);
        buttonItem9.SetActive(true);
    }

    public void OnTrapsCategoryClick()
    {
        //Buttons Visibility:
        buttonItem1.SetActive(true);
        buttonItem2.SetActive(true);
        buttonItem3.SetActive(true);
        buttonItem4.SetActive(true);
        buttonItem5.SetActive(true);
        buttonItem6.SetActive(true);
        buttonItem7.SetActive(false);
        buttonItem8.SetActive(false);
        buttonItem9.SetActive(false);
    }

    public void OnPowerUpsCategoryClick()
    {
        //Buttons Visibility:
        buttonItem1.SetActive(true);
        buttonItem2.SetActive(true);
        buttonItem3.SetActive(true);
        buttonItem4.SetActive(true);
        buttonItem5.SetActive(true);
        buttonItem6.SetActive(false);
        buttonItem7.SetActive(false);
        buttonItem8.SetActive(false);
        buttonItem9.SetActive(false);
    }

    public void OnArsenalCategoryClick()
    {
        //Buttons Visibility:
        buttonItem1.SetActive(true);
        buttonItem2.SetActive(true);
        buttonItem3.SetActive(true);
        buttonItem4.SetActive(true);
        buttonItem5.SetActive(false);
        buttonItem6.SetActive(false);
        buttonItem7.SetActive(false);
        buttonItem8.SetActive(false);
        buttonItem9.SetActive(false);
    }

    public void OnDurabilityCategoryClick()
    {
        //Buttons Visibility:
        buttonItem1.SetActive(true);
        buttonItem2.SetActive(true);
        buttonItem3.SetActive(false);
        buttonItem4.SetActive(false);
        buttonItem5.SetActive(false);
        buttonItem6.SetActive(false);
        buttonItem7.SetActive(false);
        buttonItem8.SetActive(false);
        buttonItem9.SetActive(false);
    }

}
