using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstructManager : MonoBehaviour
{

    public static ConstructManager instance;

    private GameObject defUnitToBuild;

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

    public GameObject GetDefUnitToBuild()
    {
        return defUnitToBuild;
    }

    public void SetTurretToBuild(GameObject turret)
    {
        defUnitToBuild = turret;
    }
}
