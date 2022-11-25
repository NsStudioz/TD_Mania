using System;
using UnityEngine;

public class D_Trap_AntiShield : Anims_Template
{

    [Header("Attributes")]
    [SerializeField] public float triggerRadius;
    [SerializeField] public float explosionRadius;
    [SerializeField] public float explosionDamage = 100f;
    [SerializeField] bool isTriggered;

    [HideInInspector]
    public GameObject TGR_Quad;
    public GameObject EXP_Quad;

    // EVENTS:
    public static event Action OnAntiShieldMineExplode;
    public static event Action OnUnitTrap_ConstructedSFX_1;
    public static event Action OnUnitTrap_ConstructedSFX_2;

    private void OnEnable()
    {
        _animController.Play(anim_BuildName);
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
            CheckRangeOnEnemyEncounter();

            if (isTriggered)
            {
                Destroy(gameObject);
            }
        }
    }

    private void CheckRangeOnEnemyEncounter()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, triggerRadius);
        foreach(Collider collider in colliders)
        {
            if(collider.tag == "EnemyShields")
            {
                isTriggered = true;
                PlayTrapExplodeSFX();
                ExplodeOnCollider();
            }
        }
    }

    private void ExplodeOnCollider()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);
        foreach (Collider collider in colliders)
        {
            if(collider.tag == "EnemyShields")
            {
                Damage(collider.transform);
            }
        }
    }

    private void Damage(Transform enemyShield)
    {
        Enemy_Shield eS = enemyShield.GetComponent<Enemy_Shield>();

        if (eS != null)
        {
            eS.TakeShieldDamage(explosionDamage);
        }
    }

    #region SFX:

    public void PlayTrapExplodeSFX()
    {
        OnAntiShieldMineExplode?.Invoke();
    }

    public void PlayTurretConstructionSFX_1()
    {
        OnUnitTrap_ConstructedSFX_1?.Invoke();
    }

    public void PlayTurretConstructionSFX_2()
    {
        OnUnitTrap_ConstructedSFX_2?.Invoke();
    }
    #endregion

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, triggerRadius);

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }
}


//AudioManager audioManager;
/*    private void Start()
    {
        GameObject audioHubInstance = GameObject.Find("Audio_Manager");
        audioManager = audioHubInstance.GetComponent<AudioManager>();
    }*/
//audioManager.PlayOneShot("Unit_Built_2");
//audioManager.PlayOneShot("Unit_Built_1");
//audioManager.PlayOneShot("Trap_Boom");

/*    public void EnableTrap()
    {
        trapReady = true;
    }*/

/*    [Header("Animations")]
    [SerializeField] Animator animController = null;
    [SerializeField] string animation_IdleName;
    [SerializeField] string animation_ActivateName;
    [SerializeField] string animation_BuildName;
    [SerializeField] string animation_RemoveName;
    [SerializeField] bool trapReady = false;*/