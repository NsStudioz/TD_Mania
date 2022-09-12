using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffActionLaser : MonoBehaviour
{

    public bool isBuffed = false;

    D_Unit_Turret_LaserBeamer defUnit_LaserBeamer;

    void Start()
    {
        defUnit_LaserBeamer = GetComponent<D_Unit_Turret_LaserBeamer>();
    }

    private void BuffTurret()
    {
        if (isBuffed)
        {
            defUnit_LaserBeamer.range++;
        }
    }
    private void UnBuffTurret()
    {
        if (!isBuffed)
        {
            defUnit_LaserBeamer.range--;
        }
    }


    private void OnTriggerEnter(Collider buffer)
    {
        if (buffer.CompareTag("Buffer"))
        {
            isBuffed = true;
            BuffTurret();
        }
    }

    private void OnTriggerExit(Collider buffer)
    {
        if (buffer.CompareTag("Buffer"))
        {
            isBuffed = false;
            UnBuffTurret();
        }
    }
}
