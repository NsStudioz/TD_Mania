using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstructManager : MonoBehaviour
{

    public static ConstructManager instance;

    //private GameObject defUnitToBuild;
    private D_Unit_Blueprint defUnitToBuild;

    public GameObject standardUnitPrefab;

    public GameObject RocketLauncherUnitPrefab;

    void Awake()
    {
        if (instance != null)
        {
            Debug.Log("Something went wrong. there are more than 1 buildmanagers in the game!");
            return;
        }

        instance = this;
    }

    private void Start()
    {
        PlayerStats.Gold += 400;
    }

    /*    void Start()
        {
            defUnitToBuild = standardUnitPrefab;
        }*/

    /*    public GameObject GetDefUnitToBuild()
        {
            return defUnitToBuild;
        }*/

    /*    public void SetTurretToBuild(GameObject turret)
        {
            defUnitToBuild = turret;
        }*/

    public bool CanBuild { get { return defUnitToBuild != null; } } // called a property. we only allow it to actually get something from this variable, if its not equal to null, then the state is true and we can build.

    // called a property. we only allow it to actually get something from this variable, if we have enough money, then the state is true and we can build.
    public bool HasGold { get { return PlayerStats.Gold >= defUnitToBuild.cost; } }

    public void SelectTurretToBuild(D_Unit_Blueprint turretBlueprint)
    {
        defUnitToBuild = turretBlueprint;
    }

    public void BuildDefUnitOn(Node node)
    {
        if(PlayerStats.Gold < defUnitToBuild.cost)
        {
            Debug.Log("Not enough gold to build this turret!");
            Debug.Log("Current Gold: " + PlayerStats.Gold);
            return; 
        }

        PlayerStats.Gold -= defUnitToBuild.cost;

        GameObject turret = Instantiate(defUnitToBuild.prefab, node.GetBuildPosition(), Quaternion.identity);

        node.defendingUnit = turret;

        Debug.Log("Turret Build! Gold Left: " + PlayerStats.Gold);

        /*        GameObject defUnitToBuild = constructManager.GetDefUnitToBuild();
        defendingUnit = Instantiate(defUnitToBuild, transform.position + unitPositionOffset, transform.rotation);*/
    }


}
