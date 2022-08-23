using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class D_Trap_Binder_BindDisabler : MonoBehaviour
{

    D_Trap_Binder binder;
    [SerializeField] public float bindRadius = 1f;


    void Start()
    {
        binder = GetComponent<D_Trap_Binder>();
    }


    public void TriggerBinding()
    {
        Collider[] enemies = Physics.OverlapSphere(transform.position, bindRadius);
        foreach (Collider enemy in enemies)
        {
            if (enemy.tag == "Attackers")
            {
                binder.InitiateBind(enemy.transform);
            }
        }
    }


}
