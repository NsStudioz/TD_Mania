using System;
using UnityEngine;

public class D_Trap_Mine : MonoBehaviour
{
    [Header("Attributes")]
    [SerializeField] public float triggerRadius = 0.5f;
    [SerializeField] public float explosionRadius = 1f;
    [SerializeField] public float explosionDamage = 100;
    [SerializeField] bool isTriggered = false;

    [HideInInspector]
    public GameObject TGR_Quad;
    public GameObject EXP_Quad;

    [Header("Animations")]
    [SerializeField] Animator animController = null;
    [SerializeField] string animation_IdleName;
    [SerializeField] string animation_ActivateName;
    [SerializeField] string animation_BuildName;
    [SerializeField] string animation_RemoveName;
    [SerializeField] bool trapReady = false;

    //EVENTS:
    public static event Action OnMineExplode;
    public static event Action OnUnitTrap_ConstructedSFX_1;
    public static event Action OnUnitTrap_ConstructedSFX_2;

    private void OnEnable()
    {
        animController.Play(animation_BuildName);
    }

    void Update()
    {
        if (GamePlay_Manager.GetGameOver() || GamePlay_Manager.GetGameWon())
        {
            return;
        }
        //
        if (trapReady)
        {
            CheckRangeOnEnemyEncounter();

            if (isTriggered == true)
            {
                Destroy(gameObject);
            }
        }
    }

    private void CheckRangeOnEnemyEncounter()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, triggerRadius);
        foreach (Collider collider in colliders)
        {
            if (collider.tag == "Attackers")
            {
                isTriggered = true;
                PlayTrapExplodeSFX();
                Explode();
            }
        }
    }

    private void Explode()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);
        foreach (Collider collider in colliders)
        {
            if (collider.tag == "Attackers")
            {
                Damage(collider.transform);
            }
        }
    }

    private void Damage(Transform enemy)
    {
        Enemy e = enemy.GetComponent<Enemy>();

        if (e != null)
        {
            e.TakeDamage(explosionDamage);
        }
    }

    public void EnableTrap()
    {
        trapReady = true;
    }

    #region SFX:

    public void PlayTrapExplodeSFX()
    {
        OnMineExplode?.Invoke();
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

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, triggerRadius);
        //
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
//audioManager.PlayOneShot("Trap_Boom");
//audioManager.PlayOneShot("Unit_Built_1");
//audioManager.PlayOneShot("Unit_Built_2");