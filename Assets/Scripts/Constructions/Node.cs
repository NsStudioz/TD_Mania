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

/*    private Renderer rend;
    [SerializeField] Color startColor;
    [SerializeField] Color hovercolor;
    [SerializeField] Color notEnoughGoldColor;*/

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
        //rend = GetComponent<Renderer>();
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

    /*    public GameObject GetNodeAvailability()
        {
            return defendingUnit;
        }*/

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

/*        if (constructManager.HasGold)
        {
            rend.material.color = hovercolor;
        }
        else
        {
            rend.material.color = notEnoughGoldColor;
        }*/
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

/*    void OnMouseExit()
    {
        rend.material.color = startColor;    
    }*/

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


//--OLD CODE--//

#region Trash Code
// Material Values
//private static Material material;
//private static Color greenColor = new Color32(7, 185, 0 , 255);
//private static Color redColor = new Color32(192, 23, 0 , 255);
// node color:
/*    [SerializeField] Color startColor;
    [SerializeField] Color hovercolor;
    [SerializeField] Color notEnoughGoldColor;*/

//material.SetFloat("_NodeStartEFX", 0f);
//Shader.SetGlobalColor("_NodeColor_Global", greenColor);

//material = GetComponent<MeshRenderer>().material;
//startColor = rend.material.color;

// Mouse hover functions:
/*    void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject()) // if the mouse hovers a gameobject while on a UI Element (Panel in this case)
        {
            return;
        }

        if (!constructManager.CanBuild)
        {
            return;
        }
    }*/

/*    public void OnGoldAmount_SetNodeColorAndEffect()
    {
        if (PlayerStats.Gold >= PlayerStats.notEnoughGoldThreshold) 
        {
            nodeAnimator.Play(nodeAvailable);
        }

        else if (PlayerStats.Gold < PlayerStats.notEnoughGoldThreshold)
        {
            //OnTurretUnchoice_DisableNodeEffect_New();
            nodeAnimator.Play(nodeUnavailable);
        }
    }*/

// OLD:
/*    public static void OnTurretChoice_EnableNodeEffect()
    {
        //material.SetFloat("_NodeStartEFX", 1f);
        Shader.SetGlobalFloat("_NodeStartEFX", 1f);
    }
    public static void OnTurretUnchoice_DisableNodeEffect()
    {
        //material.SetFloat("_NodeStartEFX", 0f);
        Shader.SetGlobalFloat("_NodeStartEFX", 0f);
    }
    private void OnGoldAmount_SetNodeColorAndEffect()
    {
        if (PlayerStats.Gold >= PlayerStats.notEnoughGoldThreshold) { Shader.SetGlobalColor("_NodeColor_Global", greenColor); }

        else if (PlayerStats.Gold < PlayerStats.notEnoughGoldThreshold)
        {
            //material.SetColor("_NodeColor", redColor);
            //Shader.SetGlobalColor("_NodeColor_Global", redColor);
            OnTurretUnchoice_DisableNodeEffect();
        }
    }*/

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

/*    // Change Color:
    public static void OnTurretChoice_ChangeNodeColor_Green() // Enough Gold
    {
        material.SetColor("_Color", greenColor);
    }

    public static void OnTurretChoice_ChangeNodeColor_Red() //Not Enough Gold
    {
        material.SetColor("_Color", redColor);
    }*/

//Destroy(defendingUnit);

#endregion

#region Old Mouse Input
// During this method it makes sure that we will only highlight the different nodes when we hover over them,
// we will only do the hover animation when we actually have a turret to build.
/*void OnMouseEnter()
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
}*/

/*    void OnMouseExit()
    {
        rend.material.color = startColor;
    }*/

#endregion