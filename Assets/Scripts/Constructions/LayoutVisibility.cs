using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayoutVisibility : MonoBehaviour
{

    [SerializeField] GameObject shopPanelGO;

    [SerializeField] GameObject panelVisibility_Btn;
    [SerializeField] GameObject turrets_Btn;
    [SerializeField] GameObject traps_Btn;
    [SerializeField] GameObject turrets_Catalog;
    [SerializeField] GameObject traps_Catalog;


    [SerializeField] Animator shopPanelUI;

    [SerializeField] bool panelIsUnfolded;


    void Start()
    {
        shopPanelUI = GetComponent<Animator>();
        shopPanelUI.StopPlayback();
        traps_Catalog.SetActive(false);

    }


    public void OnClickShowOrHidePanel()
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
