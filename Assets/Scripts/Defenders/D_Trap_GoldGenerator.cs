using System;
using UnityEngine;

public class D_Trap_GoldGenerator : Anims_Template
{

    [Header("Attributes")]
    [SerializeField] float delayTimeThreshold;
    //
    [SerializeField] public float gold_DelayTime = 5f; // can be upgraded.
    [SerializeField] public int goldToEarn = 10;       // can be upgraded.

    // EVENTS:
    public static event Action OnUnitGG_ConstructedSFX_1;
    public static event Action OnUnitGG_ActivateSFX_1;
    public static event Action OnUnitGG_ActivateSFX_2;

    private void OnEnable()
    {
        _animController.Play(anim_BuildName);
    }

    private void Start()
    {
        delayTimeThreshold = gold_DelayTime;
    }

    void Update()
    {
        if (GamePlay_Manager.GetGameOver() || GamePlay_Manager.GetGameWon())
        {
            return;
        }
        //
        if (isDefUnitReady)
        {
            _animController.Play(anim_FireName);
        }

        delayTimeThreshold -= Time.deltaTime;

        if (delayTimeThreshold <= 0)
        {
            PlayerStats.Gold += goldToEarn;
            delayTimeThreshold = gold_DelayTime;
        }
    }

    public void PlayGoldGeneratorActivateSFX_1()
    {
        OnUnitGG_ActivateSFX_1?.Invoke();
    }

    public void PlayGoldGeneratorActivateSFX_2()
    {
        OnUnitGG_ActivateSFX_2?.Invoke();
    }

    public void PlayTurretConstructionSFX_1()
    {
        OnUnitGG_ConstructedSFX_1?.Invoke();
    }

}

//AudioManager audioManager;
/*        GameObject audioHubInstance = GameObject.Find("Audio_Manager");
        audioManager = audioHubInstance.GetComponent<AudioManager>();*/
//audioManager.PlayOneShot("GoldGenerator_Activate");
//audioManager.PlayOneShot("GoldGenerator_Retract");
//audioManager.PlayOneShot("Unit_Built_1");

/*    public void EnableTurret()
    {
        turretReady = true;
    }*/

//animController.Play(animation_BuildName);
//animController.Play(animation_ActivateName);

/*    [Header("Animations")]
    [SerializeField] Animator animController = null;
    [SerializeField] string animation_IdleName;
    [SerializeField] string animation_ActivateName;
    [SerializeField] string animation_BuildName;
    [SerializeField] string animation_RemoveName;
    [SerializeField] bool turretReady = false;*/