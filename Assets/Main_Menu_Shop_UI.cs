using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Main_Menu_Shop_UI : MonoBehaviour
{
    // ITEMS PANEL LIST (UP TO 9):
    public Button buttonItem1; // top left
    public Button buttonItem2; // top Center
    public Button buttonItem3; // top right
    public Button buttonItem4; // middle left
    public Button buttonItem5; // middle Center
    public Button buttonItem6; // middle right
    public Button buttonItem7; // bottom left
    public Button buttonItem8; // bottom Center
    public Button buttonItem9; // bottom right

    public void OnTurretsCategoryClick()
    {
        //Buttons Visibility:
        buttonItem1.enabled = true;
        buttonItem2.enabled = true;
        buttonItem3.enabled = true;
        buttonItem4.enabled = true;
        buttonItem5.enabled = true;
        buttonItem6.enabled = true;
        buttonItem7.enabled = true;
        buttonItem8.enabled = true;
        buttonItem9.enabled = true;
    }

    public void OnTrapsCategoryClick()
    {
        //Buttons Visibility:
        buttonItem1.enabled = true;
        buttonItem2.enabled = true;
        buttonItem3.enabled = true;
        buttonItem4.enabled = true;
        buttonItem5.enabled = true;
        buttonItem6.enabled = true;
        buttonItem7.enabled = false;
        buttonItem8.enabled = false;
        buttonItem9.enabled = false;
    }

    public void OnPowerUpsCategoryClick()
    {
        //Buttons Visibility:
        buttonItem1.enabled = true;
        buttonItem2.enabled = true;
        buttonItem3.enabled = true;
        buttonItem4.enabled = true;
        buttonItem5.enabled = true;
        buttonItem6.enabled = false;
        buttonItem7.enabled = false;
        buttonItem8.enabled = false;
        buttonItem9.enabled = false;
    }

    public void OnArsenalCategoryClick()
    {
        //Buttons Visibility:
        buttonItem1.enabled = true;
        buttonItem2.enabled = true;
        buttonItem3.enabled = true;
        buttonItem4.enabled = true;
        buttonItem5.enabled = false;
        buttonItem6.enabled = false;
        buttonItem7.enabled = false;
        buttonItem8.enabled = false;
        buttonItem9.enabled = false;
    }

    public void OnDurabilityCategoryClick()
    {
        //Buttons Visibility:
        buttonItem1.enabled = true;
        buttonItem2.enabled = true;
        buttonItem3.enabled = false;
        buttonItem4.enabled = false;
        buttonItem5.enabled = false;
        buttonItem6.enabled = false;
        buttonItem7.enabled = false;
        buttonItem8.enabled = false;
        buttonItem9.enabled = false;
    }

}
