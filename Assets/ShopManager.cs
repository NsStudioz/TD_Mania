using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManager : MonoBehaviour
{

    ConstructManager constructManager;

    void Start()
    {
        constructManager = ConstructManager.instance;    
    }

    public void PurchaseStandardTurret()
    {
        Debug.Log("Turrert Selected");
        constructManager.SetTurretToBuild(constructManager.standardUnitPrefab);
    }

    public void PurchaseRocketLauncher()
    {
        Debug.Log("Roccket Launcher Selected");
        constructManager.SetTurretToBuild(constructManager.RocketLauncherUnitPrefab);
    }


}
