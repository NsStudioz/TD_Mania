using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class D_Trap_GoldGenerator : MonoBehaviour
{

    [SerializeField] float delayTimeThreshold;

    [SerializeField] public float gold_DelayTime = 5f; // can be upgraded.
    [SerializeField] public int goldToEarn = 10;       // can be upgraded.

    [Header("Animations")]
    [SerializeField] Animator animController = null;
    [SerializeField] string animation_IdleName;
    [SerializeField] string animation_ActivateName;
    [SerializeField] string animation_BuildName;
    [SerializeField] string animation_RemoveName;
    [SerializeField] bool turretReady = false;

    AudioManager audioManager;

    private void OnEnable()
    {
        animController.Play(animation_BuildName);
    }

    private void Start()
    {
        delayTimeThreshold = gold_DelayTime;

        GameObject audioHubInstance = GameObject.Find("Audio_Manager");
        audioManager = audioHubInstance.GetComponent<AudioManager>();
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
            delayTimeThreshold = gold_DelayTime;
        }
    }

    public void EnableTurret()
    {
        turretReady = true;
    }

    public void PlayGoldGeneratorActivateSFX()
    {
        //audioManager.PlayOneShot("");
    }

    public void PlayTurretConstructionSFX_1()
    {
        audioManager.PlayOneShot("Unit_Built_1");
    }

}
