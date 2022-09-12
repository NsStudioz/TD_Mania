using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffAction : MonoBehaviour
{

    public bool isBuffed = false;
    [SerializeField] float turretRadius = 2f; // radius of actual turret, not tracking range.

    D_Unit_Turret defUnit;

    void Start()
    {
        defUnit = GetComponent<D_Unit_Turret>();
    }
    void Update()
    {
        if (isBuffed == true)
        {
            defUnit.range = defUnit.range + 1f;
        }
        else
        {
            defUnit.range = 2f;
        }
    }

/*    private void CheckCollisionWithTurretBuffer()
    {

        Collider[] colliders = Physics.OverlapSphere(transform.position, turretRadius);
        foreach (Collider collider in colliders)
        {
            if (collider.CompareTag("Buffer"))
            {
                isBuffed = true;
            }
            else
            {
                isBuffed = false;
            }
        }

    }*/

    private void BuffTurret()
    {
        if (isBuffed)
        {
            defUnit.range = defUnit.range + 5f;
        }
    }


    private void OnTriggerEnter(Collider buffer)
    {
        if (buffer.CompareTag("Buffer"))
        {
            isBuffed = true;
            //defUnit.range = defUnit.range + 2f;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, turretRadius);
    }
}
