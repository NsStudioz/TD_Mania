using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class D_Trap_AntiShield : MonoBehaviour
{

    [Header("Attributes")]
    [SerializeField] float triggerRadius;
    [SerializeField] float explosionRadius;
    [SerializeField] bool isTriggered;
    [SerializeField] bool hasExploded;

    void Start()
    {
        
    }


    void Update()
    {
        
    }

    private void OnDrawGizmos()
    {

        Gizmos.color = Color.green;
        //Gizmos.DrawWireSphere

        Gizmos.color = Color.red;


    }

}
