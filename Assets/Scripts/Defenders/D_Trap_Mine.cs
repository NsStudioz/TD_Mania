using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class D_Trap_Mine : MonoBehaviour
{
    [Header("Attributes")]
    [SerializeField] public float triggerRadius = 0.5f;
    [SerializeField] public float explosionRadius = 1f;
    [SerializeField] public float explosionDamage = 100;
    [SerializeField] bool isTriggered = false;

    [Header("Trigger Line Of Sight")]
    public GameObject TGR_Quad;

    [Header("Explosion Radius")]
    public GameObject EXP_Quad;

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
        GameObject audioHubInstance = GameObject.Find("Audio_Manager");
        audioManager = audioHubInstance.GetComponent<AudioManager>();
    }

    void Update()
    {
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
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, triggerRadius);
        //
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);  
    }
}
