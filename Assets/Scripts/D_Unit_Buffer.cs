using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class D_Unit_Buffer : MonoBehaviour
{

    [Header("Attributes")]
    //public List<GameObject> defUnitsInRange = new List<GameObject>();
    [SerializeField] string defendingUnitTag = "Defenders";
    [SerializeField] float rangeRadius = 1f;


    void Start()
    {
        
    }

    void Update()
    {

    }

    private void CheckRangeRadius()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, rangeRadius);
        foreach (Collider collider in colliders)
        {
            if (collider.tag == "Defensers")
            {
                //Buff(collider);
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, rangeRadius);
    }

}
