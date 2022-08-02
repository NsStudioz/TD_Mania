using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManager : MonoBehaviour
{

    public D_Unit_Blueprint d_Unit_Turret_Standard;
    public D_Unit_Blueprint d_Unit_Turret_MissileLauncher;
    public D_Unit_Blueprint d_Unit_Turret_WideBeamer;
    public D_Unit_Blueprint d_Unit_Turret_LaserBeamer;
    public D_Unit_Blueprint d_Unit_Turret_StandardAuto;
    public D_Unit_Blueprint d_Unit_Turret_AntiShield_Standard;
    public D_Unit_Blueprint d_Unit_Turret_AntiShield_StandardAuto;
    public D_Unit_Blueprint d_Unit_Turret_AntiShield_ShieldDestroyer;
    public D_Unit_Blueprint d_Unit_Turret_Buffer;


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
        Debug.Log("Wide Beamer Selected");
        constructManager.SelectTurretToBuild(d_Unit_Turret_LaserBeamer);
    }

    public void SelectTurretStandardAuto()
    {
        Debug.Log("Wide Beamer Selected");
        constructManager.SelectTurretToBuild(d_Unit_Turret_StandardAuto);
    }

    public void SelectTurretAntiShieldStandard()
    {
        Debug.Log("Wide Beamer Selected");
        constructManager.SelectTurretToBuild(d_Unit_Turret_AntiShield_Standard);
    }

    public void SelectTurretAntiShieldStandardAuto()
    {
        Debug.Log("Wide Beamer Selected");
        constructManager.SelectTurretToBuild(d_Unit_Turret_AntiShield_StandardAuto);
    }

    public void SelectTurretAntiShieldShieldDestroyer()
    {
        Debug.Log("Wide Beamer Selected");
        constructManager.SelectTurretToBuild(d_Unit_Turret_AntiShield_ShieldDestroyer);
    }

    public void SelectTurretBuffer()
    {
        Debug.Log("Wide Beamer Selected");
        constructManager.SelectTurretToBuild(d_Unit_Turret_Buffer);
    }

}
