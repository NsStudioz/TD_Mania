using System;
using UnityEngine;

public class D_Unit_Buffer : Anims_Template
{

    [Header("Attributes")]
    [SerializeField] public float rangeRadius = 1f;

    private new SphereCollider collider;

    [HideInInspector]
    public GameObject LOS;

    // EVENTS:
    public static event Action OnUnitTurret_ConstructedSFX_1;
    public static event Action OnBuffer_IdleSFX;


    private void Start()
    {
        collider = GetComponent<SphereCollider>();
    }

    private void Update()
    {
        collider.radius = rangeRadius;

        if (isDefUnitReady) { _animController.Play(anim_IdleName); }
    }

    private void OnEnable()
    {
        _animController.Play(anim_BuildName);
    }

    #region SFX:
    public void PlayBufferIdleSFX()
    {
        OnBuffer_IdleSFX?.Invoke();
    }

    public void PlayTurretConstructionSFX_1()
    {
        OnUnitTurret_ConstructedSFX_1?.Invoke();
    }
    #endregion

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, rangeRadius);
    }

}

#region TrashCode:
/*    AudioManager audioManager;*/
/*        GameObject audioHubInstance = GameObject.Find("Audio_Manager");
    audioManager = audioHubInstance.GetComponent<AudioManager>();*/
//audioManager.PlayOneShot("Unit_Built_1");
//audioManager.PlayOneShot("Buffer_Activate");


/*    public void EnableTurret()
    {
        turretReady = true;
    }*/

/*    [Header("Animations")]
    [SerializeField] Animator animController = null;
    [SerializeField] string animation_IdleName;
    [SerializeField] string animation_ActivateName;
    [SerializeField] string animation_BuildName;
    [SerializeField] string animation_RemoveName;
    [SerializeField] bool turretReady = false;*/

/*    public void EnableTurret()
{
    turretReady = true;
}*/

/*    public void DisableTurret()
    {
        turretReady = false;
    }*/

/*    public void RemoveTurretTest()
    {
        animController.Play(animation_RemoveName);
    }*/

/*    public void DestroyTurretTest()
    {
        Destroy(gameObject);
    }*/

#endregion
