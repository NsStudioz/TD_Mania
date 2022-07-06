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

    public void SelectTurretToBuild(D_Unit_Blueprint turretBlueprint)
    {
        defUnitToBuild = turretBlueprint;
    }

    public void BuildDefUnitOn(Node node)
    {
        GameObject turret = Instantiate(defUnitToBuild.prefab, node.GetBuildPosition(), Quaternion.identity);
        node.defendingUnit = turret;

        /*        GameObject defUnitToBuild = constructManager.GetDefUnitToBuild();
        defendingUnit = Instantiate(defUnitToBuild, transform.position + unitPositionOffset, transform.rotation);*/
    }


}
