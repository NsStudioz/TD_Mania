using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{

    // node color:
    private Color startColor;
    public Color hovercolor;
    private Renderer rend;

    // On unit Spawn:
    private GameObject defendingUnit;
    public Vector3 unitPositionOffset;


    void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
    }

    void OnMouseEnter()
    {
        rend.material.color = hovercolor;
    }

    void OnMouseExit()
    {
        rend.material.color = startColor;
    }

    void OnMouseDown()
    {
        if(defendingUnit != null)
        {
            Debug.Log("Can't build another unit here!");
            return;
        }

        GameObject defUnitToBuild = ConstructManager.instance.GetDefUnitToBuild();
        defendingUnit = Instantiate(defUnitToBuild, transform.position + unitPositionOffset, transform.rotation);

    }

}
