using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManager : MonoBehaviour
{

    public D_Unit_Blueprint d_Unit_StandardTurret;
    public D_Unit_Blueprint d_Unit_RocketLauncher;

    ConstructManager constructManager;

    void Start()
    {
        constructManager = ConstructManager.instance;    
    }

    public void SelectStandardTurret()
    {
        Debug.Log("Turrert Selected");
        //constructManager.SetTurretToBuild(constructManager.standardUnitPrefab);
        constructManager.SelectTurretToBuild(d_Unit_StandardTurret);
    }

    public void SelectRocketLauncher()
    {
        Debug.Log("Roccket Launcher Selected");
        //constructManager.SetTurretToBuild(constructManager.RocketLauncherUnitPrefab);
        constructManager.SelectTurretToBuild(d_Unit_RocketLauncher);
    }


}
