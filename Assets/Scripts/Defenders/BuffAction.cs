using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffAction : MonoBehaviour
{

    public bool isBuffed = false;

    D_Unit_Turret defUnit;

    void Start()
    {
        defUnit = GetComponent<D_Unit_Turret>();
    }

    private void BuffTurret()
    {
        if (isBuffed)
        {
            defUnit.range++;
        }
    }
    private void UnBuffTurret()
    {
        if (!isBuffed)
        {
            defUnit.range--;
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
