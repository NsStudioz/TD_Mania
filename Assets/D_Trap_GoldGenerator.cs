using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class D_Trap_GoldGenerator : MonoBehaviour
{

    [SerializeField] bool isTriggered;
    [SerializeField] float delayTimeThreshold = 10f;
    [SerializeField] int goldToEarn = 10;

    void Update()
    {
        delayTimeThreshold -= Time.deltaTime;

        if (delayTimeThreshold <= 0)
        {
            PlayerStats.Gold += goldToEarn;
            delayTimeThreshold = 10f;
        }

    }
}
