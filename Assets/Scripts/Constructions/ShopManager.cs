using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    // Turrets:
    [SerializeField] D_Unit_Blueprint d_Unit_Turret_Standard;
    [SerializeField] D_Unit_Blueprint d_Unit_Turret_MissileLauncher;
    [SerializeField] D_Unit_Blueprint d_Unit_Turret_WideBeamer;
    [SerializeField] D_Unit_Blueprint d_Unit_Turret_LaserBeamer;
    [SerializeField] D_Unit_Blueprint d_Unit_Turret_StandardAuto;
    [SerializeField] D_Unit_Blueprint d_Unit_Turret_AntiShield_Standard;
    [SerializeField] D_Unit_Blueprint d_Unit_Turret_AntiShield_StandardAuto;
    [SerializeField] D_Unit_Blueprint d_Unit_Turret_AntiShield_ShieldDestroyer;
    [SerializeField] D_Unit_Blueprint d_Unit_Turret_Buffer;
    // Traps:
    [SerializeField] D_Unit_Blueprint d_Unit_Trap_Mine;
    [SerializeField] D_Unit_Blueprint d_Unit_Trap_Binder;
    [SerializeField] D_Unit_Blueprint d_Unit_Trap_GoldGenerator;
    [SerializeField] D_Unit_Blueprint d_Unit_Trap_AntiShieldMine;

    ConstructManager constructManager;

    public delegate void UnitSelected(D_Unit_Blueprint blueprint);
    public static UnitSelected OnUnitSelected;

    public static event Action<D_Unit_Blueprint> OnTurretSelectedToBuild;

    [SerializeField] private Button[] turretButtons;
    [SerializeField] private D_Unit_Blueprint[] defendingTurretUnits;

    void Start()
    {
        constructManager = ConstructManager.instance; 
    }

    private void OnEnable()
    {
        InitArray();
    }

    private void InitArray()
    {
        for (int n = 0; n < turretButtons.Length; n++)
        {
            turretButtons[n].onClick.AddListener(() =>
            {
                int currentIndex = n;
                Debug.Log("Success: " + turretButtons[currentIndex]);
                Debug.Log("Success: " + defendingTurretUnits[currentIndex]);
                //Test(n);
                //Event_OnTurretSelectedToBuild(n);
            });
        }
    }

    private void Test(int index)
    {
        Debug.Log("Success: " + defendingTurretUnits[index]);
    }

    private void Event_OnTurretSelectedToBuild(int index)
    {
        OnTurretSelectedToBuild?.Invoke(defendingTurretUnits[index]);
    }


    /*buttons[n].onClick.AddListener(() => { TriggerTest(n); });*/

    /*    private void Event_OnTurretSelectedToBuild(int index)
        {
            Debug.Log(defendingUnits[index]);
            OnTurretSelectedToBuild?.Invoke(defendingUnits[index]);
        }*/


    /*    private void InitializeButtons()
    {
        for (int n = 0; n < unitSelectButtons.Length; n++)
        {
            unitSelectButtons[n].onClick.AddListener(() => 
            {
                int currentSceneIndex = n;
                Debug.Log("Button: " + unitSelectButtons[n]);
                //Debug.Log("defendingUnits: picked unit = " + unitsList[currentSceneIndex]);
                //Event_OnTurretSelectedToBuild(currentSceneIndex);
            });
        }
    }*/

    /*    private void OnDisable()
        {
            foreach (Button btn in unitSelectButtons)
                btn.onClick.RemoveAllListeners();
        }*/

    public void SelectTurretStandard()
    {
        constructManager.SelectTurretToBuild(d_Unit_Turret_Standard);
        OnTurretSelectedToBuild?.Invoke(d_Unit_Turret_Standard);
    }

    public void SelectTurretMissileLauncher()
    {
        constructManager.SelectTurretToBuild(d_Unit_Turret_MissileLauncher);
    }

    public void SelectTurretWideBeamer()
    {
        constructManager.SelectTurretToBuild(d_Unit_Turret_WideBeamer);
    }
    public void SelectTurretLaserBeamer()
    {
        constructManager.SelectTurretToBuild(d_Unit_Turret_LaserBeamer);
    }
    public void SelectTurretStandardAuto()
    {
        constructManager.SelectTurretToBuild(d_Unit_Turret_StandardAuto);
    }
    public void SelectTurretAntiShieldStandard()
    {
        constructManager.SelectTurretToBuild(d_Unit_Turret_AntiShield_Standard);
    }
    public void SelectTurretAntiShieldStandardAuto()
    {
        constructManager.SelectTurretToBuild(d_Unit_Turret_AntiShield_StandardAuto);
    }
    public void SelectTurretAntiShieldShieldDestroyer()
    {
        constructManager.SelectTurretToBuild(d_Unit_Turret_AntiShield_ShieldDestroyer);
    }
    public void SelectTurretBuffer()
    {
        constructManager.SelectTurretToBuild(d_Unit_Turret_Buffer);
    }
    public void SelectTrapMine()
    {
        constructManager.SelectTurretToBuild(d_Unit_Trap_Mine);
    }
    public void SelectTrapBinder()
    {
        constructManager.SelectTurretToBuild(d_Unit_Trap_Binder);
    }
    public void SelectTrapGoldGenerator()
    {
        constructManager.SelectTurretToBuild(d_Unit_Trap_GoldGenerator);
    }
    public void SelectTrapAntiShieldMine()
    {
        constructManager.SelectTurretToBuild(d_Unit_Trap_AntiShieldMine);
    }

}
