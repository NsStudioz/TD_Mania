using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class D_Unit_Buffer : MonoBehaviour
{

    [Header("Attributes")]
    [SerializeField] public float rangeRadius = 1f;

    private new SphereCollider collider;

    AudioManager audioManager;

    [Header("Line Of Sight")]
    public GameObject LOS;

    [Header("Animations")]
    [SerializeField] Animator animController = null;
    [SerializeField] string animation_IdleName;
    [SerializeField] string animation_ActivateName;
    [SerializeField] string animation_BuildName;
    [SerializeField] string animation_RemoveName;
    [SerializeField] bool turretReady = false;

    private void Start()
    {
        collider = GetComponent<SphereCollider>();

        GameObject audioHubInstance = GameObject.Find("Audio_Manager");
        audioManager = audioHubInstance.GetComponent<AudioManager>();
    }

    private void Update()
    {
        collider.radius = rangeRadius;
    }

    private void OnEnable()
    {
        animController.Play(animation_BuildName);
    }

    public void EnableTurret()
    {
        turretReady = true;
    }

    public void PlayBufferIdleSFX()
    {
        audioManager.PlayOneShot("Buffer_Activate");
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
        Gizmos.DrawWireSphere(transform.position, rangeRadius);
    }

}


