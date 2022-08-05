using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayoutVisibility : MonoBehaviour
{

    public GameObject shopPanelGO;
    public GameObject turretsCatalogGO_Unfold;
    public GameObject trapsCatalogGO_Unfold;
    public GameObject turretsCatalogGO_Fold;
    public GameObject trapsCatalogGO_Fold;

    public Animator shopPanelUI;

    public bool panelIsUnfolded;
    public bool panelIsUnfolded_Turrets;
    public bool panelIsUnfolded_Traps;

    private void Awake()
    {
        shopPanelUI = GetComponent<Animator>();

/*        panelIsUnfolded_Turrets = false;
        panelIsUnfolded_Traps = false;
        panelIsUnfolded = false;*/

    }


    void Start()
    {
        shopPanelUI.StopPlayback();
        trapsCatalogGO_Fold.SetActive(false);
        turretsCatalogGO_Fold.SetActive(false);
    }

    public void OnClickTurretsCatalogBtn()
    {

        shopPanelUI.Play("Anim_UnfoldPanel");
        trapsCatalogGO_Fold.SetActive(true);
        turretsCatalogGO_Fold.SetActive(true);
        turretsCatalogGO_Unfold.SetActive(false);
        trapsCatalogGO_Unfold.SetActive(false);

        // show turret items
        // hide trap items
    }

    public void OnClickTrapsCatalogBtn()
    {
        shopPanelUI.Play("Anim_UnfoldPanel");
        trapsCatalogGO_Fold.SetActive(true);
        turretsCatalogGO_Fold.SetActive(true);
        turretsCatalogGO_Unfold.SetActive(false);
        trapsCatalogGO_Unfold.SetActive(false);
        // show trap items
        // hide turret items

    }

    public void OnClickRetractPanel()
    {
        shopPanelUI.Play("Anim_FoldPanel");
        trapsCatalogGO_Fold.SetActive(false);
        turretsCatalogGO_Fold.SetActive(false);
        turretsCatalogGO_Unfold.SetActive(true);
        trapsCatalogGO_Unfold.SetActive(true);
    }


}
