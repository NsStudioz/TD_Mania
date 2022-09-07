using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class D_Trap_GoldGenerator : MonoBehaviour
{

    [SerializeField] float delayTimeThreshold;

    [SerializeField] float upgradeable_DelayTime = 5f; // can be upgraded.
    [SerializeField] int goldToEarn = 10;              // can be upgraded.

    private void Start()
    {
        delayTimeThreshold = upgradeable_DelayTime;
    }

    void Update()
    {
        delayTimeThreshold -= Time.deltaTime;

        if (delayTimeThreshold <= 0)
        {
            PlayerStats.Gold += goldToEarn;
            delayTimeThreshold = upgradeable_DelayTime;
        }

    }
}
