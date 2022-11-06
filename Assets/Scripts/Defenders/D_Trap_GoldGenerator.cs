using System;
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

    // EVENTS:
    public static event Action OnUnitGG_ConstructedSFX_1;
    public static event Action OnUnitGG_ActivateSFX_1;
    public static event Action OnUnitGG_ActivateSFX_2;

    private void OnEnable()
    {
        animController.Play(animation_BuildName);
    }

    private void Start()
    {
        delayTimeThreshold = gold_DelayTime;
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