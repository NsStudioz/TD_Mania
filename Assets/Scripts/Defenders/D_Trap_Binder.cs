using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class D_Trap_Binder : MonoBehaviour
{

    [SerializeField] public float bindingDuration = 2f; // upgradeable
    [SerializeField] public float triggerRadius = 0.5f;
    [SerializeField] public float bindRadius;
    [SerializeField] bool isTriggered;
    //
    SphereCollider sphereCol;

    [Header("Trigger Line Of Sight")]
    public GameObject TGR_Quad;

    [Header("Explosion Radius")]
    public GameObject Bind_Quad;


    [Header("Animations")]
    [SerializeField] Animator animController = null;
    [SerializeField] string animation_IdleName;
    [SerializeField] string animation_ActivateName;
    [SerializeField] string animation_BuildName;
    [SerializeField] string animation_RemoveName;
    [SerializeField] bool trapReady = false;

    AudioManager audioManager;

    private void OnEnable()
    {
        animController.Play(animation_BuildName);
    }

    private void Start()
    {
        sphereCol = GetComponent<SphereCollider>();

        sphereCol.enabled = false;

        GameObject audioHubInstance = GameObject.Find("Audio_Manager");
        audioManager = audioHubInstance.GetComponent<AudioManager>();
    }

    private void Update()
    {
        sphereCol.radius = bindRadius;
        //
        if (trapReady)
        {
            EnableBind();

            if (isTriggered)
            {
                animController.Play(animation_ActivateName);
            }
        }
    }

    private void EnableBind()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, triggerRadius);
        foreach (Collider collider in colliders)
        {
            if (collider.tag == "Attackers")
            {
                sphereCol.enabled = true;
                isTriggered = true;
            }
        }
    }

    public void DestroyTrap()
    {
        sphereCol.enabled = false;
        Destroy(gameObject);
    }

    public void EnableTrap()
    {
        trapReady = true;
    }

    public void PlayTrapBeepSFX()
    {
        audioManager.PlayOneShot("Trap_Beep");
    }

    public void PlayTrapExplodeSFX()
    {
        audioManager.PlayOneShot("Trap_Boom");
    }

    public void PlayTurretConstructionSFX_1()
    {
        audioManager.PlayOneShot("Unit_Built_1");
    }

    public void PlayTurretConstructionSFX_2()
    {
        audioManager.PlayOneShot("Unit_Built_2");
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, triggerRadius);
    }
}

#region Backup:
//    [SerializeField] float bindValue = 0f; // enemy speed if on bind radius of trap
//   private bool startBindingCountdown = false;

///
/*        CheckRangeOnEnemyEncounter();

    if (isTriggered == true)
    {
        startBindingCountdown = true;
        BindingCountdown();
    }*/

/*        if (bindOn)
        {
            trapTimeElapsed -= Time.deltaTime;

            if (trapTimeElapsed <= 0)
            {
                bindOn = false;
                bindRadius = 0f;
            }
        }*/
/// 

/*    private void CheckRangeOnEnemyEncounter()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, triggerRadius);
        foreach (Collider collider in colliders)
        {
            if (collider.tag == "Attackers")
            {
                isTriggered = true;
                TriggerBinding();
            }
        }
    }

    private void TriggerBinding()
    {
        Collider[] enemies = Physics.OverlapSphere(transform.position, bindRadius);
        foreach (Collider enemy in enemies)
        {
            if (enemy.tag == "Attackers")
            {
                InitiateBind(enemy.transform);
            }
        }
    }

    public void InitiateBind(Transform enemy)
    {
        Enemy e = enemy.GetComponent<Enemy>();

        if (e != null)
        {
            e.BindingEnemy(bindValue);
        }
    }

    private void BindingCountdown()
    {
        if (startBindingCountdown)
        {
            bindingDuration -= Time.deltaTime;

            if (bindingDuration <= 0)
            {
                startBindingCountdown = false;
                Destroy(gameObject);
            }
        }
    }*/

#endregion

//[SerializeField] float bindRadius = 1f;
//[SerializeField] public float bindingDurationThreshold;
// Vars for stopping unnecessary enemies from getting trapped:
//[SerializeField] float trapTimeElapsed;
//[SerializeField] float trapTimeThreshold = 2f;

//trapTimeElapsed = trapTimeThreshold;

/*private void SetTrapToWork()
{
    if (trapReady)
    {
        EnableBind();

        if (sphereCol.enabled)
        {
            trapTimeElapsed -= Time.deltaTime;

            if (trapTimeElapsed <= 0f)
            {
                sphereCol.enabled = false;
                Destroy(gameObject);
            }
        }

        if (isTriggered)
        {
            bindingDuration -= Time.deltaTime;

            if (bindingDuration <= 0f)
            {
                Destroy(gameObject);
            }
        }
    }
}*/
