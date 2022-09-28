using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class D_Trap_GoldGenerator : MonoBehaviour
{

    [SerializeField] float delayTimeThreshold;

    [SerializeField] float upgradeable_DelayTime = 5f; // can be upgraded.
    [SerializeField] int goldToEarn = 10;              // can be upgraded.

    [Header("Animations")]
    [SerializeField] Animator animController = null;
    [SerializeField] string animation_IdleName;
    [SerializeField] string animation_ActivateName;
    [SerializeField] string animation_BuildName;
    [SerializeField] string animation_RemoveName;
    [SerializeField] bool turretReady = false;

    private void OnEnable()
    {
        animController.Play(animation_BuildName);
    }

    private void Start()
    {
        delayTimeThreshold = upgradeable_DelayTime;
    }

    void Update()
    {
        if (turretReady)
        {
            animController.Play(animation_ActivateName);
        }

        delayTimeThreshold -= Time.deltaTime;

        if (delayTimeThreshold <= 0)
        {
            PlayerStats.Gold += goldToEarn;
            delayTimeThreshold = upgradeable_DelayTime;
        }
    }

    public void EnableTurret()
    {
        turretReady = true;
    }
}
