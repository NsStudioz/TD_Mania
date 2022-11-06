using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class Node : MonoBehaviour
{
    // node color:
    [SerializeField] Color startColor;
    [SerializeField] Color hovercolor;
    [SerializeField] Color notEnoughGoldColor;
    private Renderer rend;

    [HideInInspector]
    [SerializeField] GameObject defendingUnit;
    [HideInInspector]
    public D_Unit_Blueprint d_Unit_Blueprint;
    [HideInInspector]
    public bool isDefUnitUpgraded = false;
    // On unit Spawn:
    [SerializeField] Vector3 unitPositionOffset;
    // Instance:
    ConstructManager constructManager;

    void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;

        constructManager = ConstructManager.instance;
    }

    public Vector3 GetBuildPosition()
    {
        return transform.position + unitPositionOffset;
    }

    // During this method it makes sure that we will only highlight the different nodes when we hover over them,
    // we will only do the hover animation when we actually have a turret to build.
    void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject()) // if the mouse hovers a gameobject while on a UI Element (Panel in this case)
        {
            return;
        }

        if (!constructManager.CanBuild)
        {
            return;
        }

        if (constructManager.HasGold)
        {
            rend.material.color = hovercolor;
        }
        else
        {
            rend.material.color = notEnoughGoldColor;
        }
    }

    void OnMouseExit()
    {
        rend.material.color = startColor;
    }

    void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject()) // if the mouse hovers a gameobject while on a UI Element (Panel in this case)
        {
            return;
        }

        if (defendingUnit != null)
        {
            constructManager.Turret_SelectNode(this); // pass in the selected node.
            return;
        }

        if (!constructManager.CanBuild)
        {
            return;
        }

        //constructManager.BuildDefUnitOn(this); // this = we pass in this node.
        BuildTurret(constructManager.GetDefUnitToBuild());
    }

    void BuildTurret(D_Unit_Blueprint blueprint)
    {
        if (PlayerStats.Gold < blueprint.cost)
        {
            Debug.Log("Not enough gold to build this turret!");
            return;
        }

        PlayerStats.Gold -= blueprint.cost;

        GameObject turret = Instantiate(blueprint.prefab, GetBuildPosition(), Quaternion.identity);
        defendingUnit = turret;

        d_Unit_Blueprint = blueprint; // set the turret blueprint equal to the turret that was passed in.

        //Debug.Log("Turret Build!");
    }

/*    public void UpgradeTurretOrDefUnit()
    {
        if (PlayerStats.Gold < d_Unit_Blueprint.upgradeCost)
        {
            Debug.Log("Not enough gold to upgrade that turret!");
            return;
        }

        PlayerStats.Gold -= d_Unit_Blueprint.upgradeCost;

        // destroy old turret:
        Destroy(defendingUnit);

        // build new upgraded turret:
        GameObject turret = Instantiate(d_Unit_Blueprint.upgradedPrefab, GetBuildPosition(), Quaternion.identity);
        defendingUnit = turret;

        // set in a temporary gameobject, so we can rid of it later on ingame.
        GameObject buildEFX = Instantiate(constructManager.buildEffects, GetBuildPosition(), Quaternion.identity);
        Destroy(buildEFX, 5f);

        isDefUnitUpgraded = true;

        Debug.Log("Turret Upgraded!");
    }*/

    public void TemporarilyActivateTurretLOS()
    {       
        if(defendingUnit.GetComponent<Units_LineOfSight>() != null)
        {
            Units_LineOfSight _LOS = defendingUnit.GetComponent<Units_LineOfSight>();
            _LOS.EnableLOS();
        }
        else if (defendingUnit.GetComponent<Units_Traps_LineOfSight>() != null)
        {
            Units_Traps_LineOfSight _LOS_Traps = defendingUnit.GetComponent<Units_Traps_LineOfSight>();
            _LOS_Traps.EnableLOS();
        }
    }

    public void SellDefUnit()
    {
        PlayerStats.Gold += d_Unit_Blueprint.GetSellAmount();

        Destroy(defendingUnit);
        d_Unit_Blueprint = null;
    }
}
