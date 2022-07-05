using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{

    // node color:
    private Color startColor;
    public Color hovercolor;
    private Renderer rend;

    // On unit Spawn:
    private GameObject defendingUnit;
    public Vector3 unitPositionOffset;

    //
    ConstructManager constructManager;


    void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;

        constructManager = ConstructManager.instance;
    }

    void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject()) // if the mouse hovers a gameobject while on a UI Element (Panel in this case)
        {
            return;
        }

        if (constructManager.GetDefUnitToBuild() == null) // During this method it makes sure that we will only highlight the different nodes when we hover over them,
                                                          // we will only do the hover animation when we actually have a turret to build.
        {
            return;
        }

        rend.material.color = hovercolor;
    }

    void OnMouseExit()
    {
        rend.material.color = startColor;
    }

    void OnMouseDown()
    {
        if(constructManager.GetDefUnitToBuild() == null)
        {
            return;
        }

        if(defendingUnit != null)
        {
            Debug.Log("Can't build another unit here!");
            return;
        }

        GameObject defUnitToBuild = constructManager.GetDefUnitToBuild();
        defendingUnit = Instantiate(defUnitToBuild, transform.position + unitPositionOffset, transform.rotation);

    }

}
