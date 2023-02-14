using System;
using UnityEngine;

public class LayoutVisibility : MonoBehaviour
{

    [SerializeField] GameObject shopPanelGO;

    [SerializeField] GameObject panelVisibility_Btn;
    [SerializeField] GameObject turrets_Btn;
    [SerializeField] GameObject traps_Btn;
    [SerializeField] GameObject turrets_Catalog;
    [SerializeField] GameObject traps_Catalog;
    //
    [SerializeField] Animator shopPanelUI;
    //
    [SerializeField] bool panelIsUnfolded;
    //
    public static event Action OnClick_UI_UnitsButton_Unfold_SFX;
    public static event Action OnClick_UI_UnitsButton_Fold_SFX;
    public static event Action OnUIClick_UnitSelect_SFX;

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
            OnClick_UI_UnitsButton_Unfold_SFX?.Invoke();
            //
            NodeList.isUnitsPanelOpen = true;
        }
        else if (panelIsUnfolded)
        {
            panelIsUnfolded = false;
            shopPanelUI.Play("Anim_FoldPanel");
            OnClick_UI_UnitsButton_Fold_SFX?.Invoke();
            //
            NodeList.isUnitsPanelOpen = false;
        }
    }

    public void OnClickShowTurretsCatalog()
    {
        turrets_Catalog.SetActive(true);
        traps_Catalog.SetActive(false);
        OnUIClick_UnitSelect_SFX?.Invoke();
    }

    public void OnClickShowTrapsCatalog()
    {
        turrets_Catalog.SetActive(false);
        traps_Catalog.SetActive(true);
        OnUIClick_UnitSelect_SFX?.Invoke();
    }
}

/*    private void Awake()
    {
        GameObject forAudioManager = GameObject.Find("Audio_Manager");
        audioManager = forAudioManager.GetComponent<AudioManager>();
    }*/

//audioManager.PlayOneShot("UI_UnitsButton_Unfold");
//audioManager.PlayOneShot("UI_UnitsButton_Fold");
//audioManager.PlayOneShot("UI_TurretSelect");
//audioManager.PlayOneShot("UI_TurretSelect");