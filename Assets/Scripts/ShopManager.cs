using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManager : MonoBehaviour
{

    public D_Unit_Blueprint d_Unit_Turret_Standard;
    public D_Unit_Blueprint d_Unit_Turret_MissileLauncher;
    public D_Unit_Blueprint d_Unit_Turret_WideBeamer;

    // ConstructManager constructManager;

    void Start()
    {
        // constructManager = ConstructManager.instance;
    }

    public void SelectTurretStandard()
    {
        Debug.Log("Standard Turret Selected");
        // constructManager.SelectTurretToBuild(d_Unit_Turret_Standard);
    }

    public void SelectTurretMissileLauncher()
    {
        Debug.Log("Missile Launcher Selected");
        // constructManager.SelectTurretToBuild(d_Unit_Turret_MissileLauncher);
    }

    public void SelectTurretWideBeamer()
    {
        Debug.Log("Wide Beamer Selected");
        // constructManager.SelectTurretToBuild(d_Unit_Turret_WideBeamer);
    }


}
