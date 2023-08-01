using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.EventSystems;


public class Node : MonoBehaviour
{
    //Animations:
    [SerializeField] private Animator nodeAnimator;
    [SerializeField] private string nodeAvailable;
    [SerializeField] private string nodeUnavailable;
    [SerializeField] private string nodeStartEffect;

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
    [SerializeField] private bool isUnitInstalled = false;

    void Start()
    {
        nodeAnimator = GetComponent<Animator>();
        constructManager = ConstructManager.instance;
    }

    private void OnDestroy()
    {
        nodeAnimator.StopPlayback();
    }

    public Vector3 GetBuildPosition()
    {
        return transform.position + unitPositionOffset;
    }
    public bool GetNodeAvailability()
    {
        return isUnitInstalled;
    }


    // MouseDown/Touch Input:
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

        BuildTurret(constructManager.GetDefUnitToBuild());
    }

    void BuildTurret(D_Unit_Blueprint blueprint)
    {
        if (PlayerStats.Gold < blueprint.cost)
        {
            GamePlay_Manager.Get_NotEnoughGoldText();

            return;
        }

        PlayerStats.Gold -= blueprint.cost;

        GameObject turret = Instantiate(blueprint.prefab, GetBuildPosition(), Quaternion.identity);
        defendingUnit = turret;

        d_Unit_Blueprint = blueprint; // set the turret blueprint equal to the turret that was passed in.
        isUnitInstalled = true;
    }

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

        if (defendingUnit.GetComponent<Anims_Template>() != null)
        {
            Anims_Template anims = defendingUnit.GetComponent<Anims_Template>();
            anims.DisableDefendingUnit();
            anims.RemoveDefendingUnit();
        }
        else { Destroy(defendingUnit); }

        d_Unit_Blueprint = null;
        isUnitInstalled = false;
    }

    #region Shader Effects
    public void OnTurretChoice_EnableNodeEffect()
    {
        nodeAnimator.Play(nodeStartEffect);
    }

    public void OnTurretUnchoice_DisableNodeEffect()
    {
        nodeAnimator.Play(nodeAvailable);
    }

    public void NodesUnavailable()
    {
        nodeAnimator.Play(nodeUnavailable);
    }
    #endregion
}