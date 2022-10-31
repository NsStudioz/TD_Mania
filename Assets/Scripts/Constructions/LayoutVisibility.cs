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

    AudioManager audioManager;

    [SerializeField] Animator shopPanelUI;

    [SerializeField] bool panelIsUnfolded;

    private void Awake()
    {
        GameObject forAudioManager = GameObject.Find("Audio_Manager");
        audioManager = forAudioManager.GetComponent<AudioManager>();
    }

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
            audioManager.PlayOneShot("UI_UnitsButton_Unfold");
        }
        else if (panelIsUnfolded)
        {
            panelIsUnfolded = false;
            shopPanelUI.Play("Anim_FoldPanel");
            audioManager.PlayOneShot("UI_UnitsButton_Fold");
        }
    }

    public void OnClickShowTurretsCatalog()
    {
        turrets_Catalog.SetActive(true);
        traps_Catalog.SetActive(false);
        audioManager.PlayOneShot("UI_TurretSelect");
    }

    public void OnClickShowTrapsCatalog()
    {
        turrets_Catalog.SetActive(false);
        traps_Catalog.SetActive(true);
        audioManager.PlayOneShot("UI_TurretSelect");
    }


}
