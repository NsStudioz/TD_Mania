using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{

    // node color:
    private Color startColor;
    public Color hovercolor;
    public Color notEnoughGoldColor;
    private Renderer rend;

    [Header("Optional")]
    public GameObject defendingUnit;

    // On unit Spawn:
    public Vector3 unitPositionOffset;

    //
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

    void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject()) // if the mouse hovers a gameobject while on a UI Element (Panel in this case)
        {
            return;
        }

        if (!constructManager.CanBuild) // During this method it makes sure that we will only highlight the different nodes when we hover over them,
                                        // we will only do the hover animation when we actually have a turret to build.
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
        if(!constructManager.CanBuild)
        {
            return;
        }

        if(defendingUnit != null)
        {
            Debug.Log("Can't build another unit here!");
            return;
        }

        constructManager.BuildDefUnitOn(this); // this = we pass in this node.

    }

}
