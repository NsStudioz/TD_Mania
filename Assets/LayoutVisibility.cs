using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayoutVisibility : MonoBehaviour
{

    public GameObject shopPanelGO;

    public GameObject panelVisibility_Btn;
    public GameObject turrets_Btn;
    public GameObject traps_Btn;
    public GameObject turrets_Catalog;
    public GameObject traps_Catalog;


    public Animator shopPanelUI;

    public bool panelIsUnfolded;


    void Start()
    {
        shopPanelUI = GetComponent<Animator>();
        shopPanelUI.StopPlayback();
        traps_Catalog.SetActive(false);

    }


    public void OnClickUnfoldPanel()
    {
        if (!panelIsUnfolded)
        {
            panelIsUnfolded = true;
            shopPanelUI.Play("Anim_UnfoldPanel");
        }
        else if (panelIsUnfolded)
        {
            panelIsUnfolded = false;
            shopPanelUI.Play("Anim_FoldPanel");
        }
    }

    public void OnClickShowTurretsCatalog()
    {
        turrets_Catalog.SetActive(true);
        traps_Catalog.SetActive(false);
    }

    public void OnClickShowTrapsCatalog()
    {
        turrets_Catalog.SetActive(false);
        traps_Catalog.SetActive(true);
    }


}
