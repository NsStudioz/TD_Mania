using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    void Start()
    {
        constructManager = ConstructManager.instance;
    }

    public void SelectTurretStandard()
    {
        Debug.Log("Standard Turret Selected");
        constructManager.SelectTurretToBuild(d_Unit_Turret_Standard);
    }

    public void SelectTurretMissileLauncher()
    {
        Debug.Log("Missile Launcher Selected");
        constructManager.SelectTurretToBuild(d_Unit_Turret_MissileLauncher);
    }

    public void SelectTurretWideBeamer()
    {
        Debug.Log("Wide Beamer Selected");
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
