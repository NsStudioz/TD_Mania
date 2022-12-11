using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Commands_Tester : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.T))
        {
            PlayerStats.Gold += 100000;
        }
    }
}
