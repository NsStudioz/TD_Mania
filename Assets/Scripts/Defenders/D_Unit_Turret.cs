using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class D_Unit_Turret : MonoBehaviour
{

    [Header("Attributes")]
    public Transform target;
    public Enemy targetEnemy;
    [SerializeField] bool isAntiShield;
    [SerializeField] string enemyTag = "Attackers";
    [SerializeField] public string statsIdentifierTag = "Attackers";
    [SerializeField] public float range = 2f;
    [SerializeField] public float fireRate = 1f;
    [SerializeField] public float fireCountDown = 0f;

    [Header("Unit Rotation")]
    [SerializeField] public float turnSpeed = 10f;
    [SerializeField] Transform partToRotate;

    [Header("Bullet Setup")]
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] Transform firingPosition;

    [Header("Effects")]
    [SerializeField] ParticleSystem muzzleEFX  = null;
    /*    [SerializeField] GameObject deathEFX  = null;*/

    [HideInInspector]
    public GameObject LOS;

    [Header("Animations")]
    [SerializeField] Animator animController = null;
    [SerializeField] string animation_IdleName;
    [SerializeField] string animation_FireName;
    [SerializeField] string animation_BuildName;
    [SerializeField] string animation_RemoveName;
    [SerializeField] bool turretReady = false;

    // EVENTS:
    public static event Action OnUnitTurret_ConstructedSFX_1;
    public static event Action OnUnitTurret_ConstructedSFX_2;
    //
    public static event Action OnUnitTurret_Cannon_Fire;
    public static event Action OnUnitTurret_MissileLauncher_Fire;
    public static event Action OnUnitTurret_AutoTurret_Fire;
    public static event Action OnUnitTurret_PlasmaCannon_Fire;
    //

    private void OnEnable()
    {
        animController.Play(animation_BuildName);
    }

    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    void Update()
    {
        if (turretReady)
        {
            if (target == null)
            {
                return;
            }

            if (isAntiShield)
            {
                if (!targetEnemy.hasShield)
                {
                    return;
                }
            }
            else if (!isAntiShield)
            {
                if (targetEnemy.hasShield || targetEnemy.isProtected)
                {
                    return;
                }
            }

            LockOnTarget();

            if (fireCountDown <= 0f)
            {
                Shoot();
                fireCountDown = 1f / fireRate;
            }

            fireCountDown -= Time.deltaTime;
        }
    }

    private void LockOnTarget()
    {
        Vector3 dir = target.position - transform.position;

        Quaternion lookRotation = Quaternion.LookRotation(dir);

        Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;

        partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);
    }

    private void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);

        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach(GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position); // set the distance to enemy.
            
            if(distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if(nearestEnemy != null && shortestDistance <= range)
        {
            target = nearestEnemy.transform;
            targetEnemy = nearestEnemy.GetComponent<Enemy>();
        }
        else { target = null; }
    }

    public void Shoot()
    {
        GameObject bulletGO = Instantiate(bulletPrefab, firingPosition.position, firingPosition.rotation);
        muzzleEFX.Play();
        animController.Play(animation_FireName);
        PlayTurretShootingSFX();
        Bullet bullet = bulletGO.GetComponent<Bullet>();

        if (bullet != null)
        {
            bullet.SeekTarget(target);
        }
    }

    public void EnableTurret()
    {
        turretReady = true;
    }

    #region SFX:
    private void PlayTurretShootingSFX()
    {
        if (statsIdentifierTag == "Cannon" || statsIdentifierTag == "AS_Cannon")
        {
            OnUnitTurret_Cannon_Fire?.Invoke();
        }
        else if (statsIdentifierTag == "Auto_Turret" || statsIdentifierTag == "AS_Auto")
        {
            OnUnitTurret_AutoTurret_Fire?.Invoke();
        }
        else if (statsIdentifierTag == "Missile_Launcher" || statsIdentifierTag == "AS_ShieldDestroyer")
        {
            OnUnitTurret_MissileLauncher_Fire?.Invoke();
        }
        else if (statsIdentifierTag == "Plasma_Cannon")
        {
            OnUnitTurret_PlasmaCannon_Fire?.Invoke();
        }
    }

    public void PlayTurretConstructionSFX_1()
    {
        OnUnitTurret_ConstructedSFX_1?.Invoke();
    }

    public void PlayTurretConstructionSFX_2()
    {
        OnUnitTurret_ConstructedSFX_2?.Invoke();
    }
    #endregion

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }


    #region TrashCode:

    /*    public void BuffDefendingUnit_Range(float bonusAmount)
    {
        range += bonusAmount;
    }*/

    /*    void LeUpdate()
        {
            if (target == null)
            {
                return;
            }

            LockOnTarget();

            if (useLaser)
            {
                UseTheLaser();
            }
            else
            {
                if (fireCountDown <= 0f)
                {
                    Shoot();
                    fireCountDown = 1f / fireRate;
                }

                fireCountDown -= Time.deltaTime;

            }
        }*/

    /*    private void OnDestroy()
    {
        GameObject buildEFX = Instantiate(deathEFX, transform.position, Quaternion.identity);
        Destroy(buildEFX, 2f);
    }*/


    //AudioManager audioManager;
    /*    private void Awake()
        {
            GameObject audioHubInstance = GameObject.Find("Audio_Manager");
            audioManager = audioHubInstance.GetComponent<AudioManager>();
        }*/

    //audioManager.PlayOneShot("Cannon_Fire");
    //audioManager.PlayOneShot("Auto_Fire");
    //audioManager.PlayOneShot("Missile_Fire");
    //audioManager.PlayOneShot("Plasma_Fire");
    //audioManager.PlayOneShot("Unit_Built_1");
    //audioManager.PlayOneShot("Unit_Built_2");

    #endregion


}
