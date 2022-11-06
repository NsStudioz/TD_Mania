using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class D_Unit_Turret_LaserBeamer : MonoBehaviour
{
    [Header("Attributes")]
    public Transform target;
    public Enemy targetEnemy;
    [SerializeField] string enemyTag = "Attackers";
    [SerializeField] public float range = 15f;

    [Header("Unit Rotation")]
    [SerializeField] public float turnSpeed = 10f;
    [SerializeField] Transform partToRotate;

    [Header("Bullet Setup")]
    [SerializeField] Transform firingPosition;

    [Header("Unit Laser Turret")]
    [SerializeField] bool useLaser = false;
    [SerializeField] LineRenderer lineRenderer;
    [SerializeField] ParticleSystem laserImpactEffects;
    [SerializeField] Light laserImpactLight;
    [SerializeField] public float damageOverTime = 30;
    [SerializeField] public float laserHitSlowPct = .4f;

    [Header("Animations")]
    [SerializeField] Animator animController = null;
    [SerializeField] string animation_IdleName;
    [SerializeField] string animation_FireName;
    [SerializeField] string animation_BuildName;
    [SerializeField] string animation_RemoveName;
    [SerializeField] bool turretReady = false;

    [HideInInspector]
    public GameObject LOS;

    // EVENTS:
    public static event Action OnUnitTurret_ConstructedSFX_1;
    public static event Action OnUnitTurret_ConstructedSFX_2;
    //
    public static event Action OnUnitTurret_LaserBeamer_Fire;
    public static event Action OnUnitTurret_LaserBeamer_Stop;

    private void OnEnable()
    {
        animController.Play(animation_BuildName);
    }

    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
        lineRenderer.enabled = false;
        laserImpactLight.enabled = false;
    }

    void Update()
    {
        if (turretReady)
        {
            if (target == null)
            {
                if (useLaser)
                {
                    if (lineRenderer.enabled)
                    {
                        lineRenderer.enabled = false;
                        laserImpactLight.enabled = false;
                        laserImpactEffects.Stop();
                        StopTurretShootingSFX();
                    }
                }
                return;
            }

            if (target != null)
            {
                if (targetEnemy.hasShield || targetEnemy.isProtected)
                {
                    if (useLaser)
                    {
                        if (lineRenderer.enabled)
                        {
                            lineRenderer.enabled = false;
                            laserImpactLight.enabled = false;
                            laserImpactEffects.Stop();
                            StopTurretShootingSFX();
                        }
                    }
                    return;
                }
            }
            LockOnTarget();

            if (useLaser)
            {
                UseTheLaser();
            }
            /*        else
                    {
                        if (fireCountDown <= 0f)
                        {
                            Shoot();
                            fireCountDown = 1f / fireRate;
                        }

                        fireCountDown -= Time.deltaTime;
                    }*/
        }
    }

    private void UseTheLaser()
    {
        targetEnemy.TakeDamage(damageOverTime * Time.deltaTime);
        targetEnemy.SlowEnemyOnLaserHit(laserHitSlowPct);

        if (!lineRenderer.enabled)
        {
            PlayTurretShootingSFX();
            lineRenderer.enabled = true;
            laserImpactLight.enabled = true;
            laserImpactEffects.Play();  
        }

        lineRenderer.SetPosition(0, firingPosition.position); // line starts based on position index (written in the component, can create more if want lasers to bend or change positions).
        lineRenderer.SetPosition(1, target.position); // Index one = end of line. End at target's position (Enemy).

        Vector3 dir = firingPosition.position - target.position;

        laserImpactEffects.transform.position = target.position + dir.normalized; // dir.normalized = normalize the length to 1, then multiply by 0.1f.

        laserImpactEffects.transform.rotation = Quaternion.LookRotation(dir);
    }

    private void LockOnTarget()
    {
        Vector3 dir = target.position - transform.position;

        Quaternion lookRotation = Quaternion.LookRotation(dir);

        Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;

        partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);
    }

    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);

        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if (nearestEnemy != null && shortestDistance <= range)
        {
            target = nearestEnemy.transform;
            targetEnemy = nearestEnemy.GetComponent<Enemy>();
        }
        else { target = null; }
    }

    public void EnableTurret()
    {
        turretReady = true;
    }

    #region SFX:

    public void PlayTurretShootingSFX()
    {
        OnUnitTurret_LaserBeamer_Fire?.Invoke();
    }
    private void StopTurretShootingSFX()
    {
        OnUnitTurret_LaserBeamer_Stop?.Invoke();
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
}

#region TrashCode:

/*void Update()
{
    if (target == null)
    {
        if (useLaser)
        {
            if (lineRenderer.enabled)
            {
                lineRenderer.enabled = false;
                laserImpactLight.enabled = false;
                laserImpactEffects.Stop();
            }

        }

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

//[SerializeField] float fireRate = 1f;
//[SerializeField] float fireCountDown = 0f;

//[SerializeField] GameObject bulletPrefab;

//AudioManager audioManager;

/*        GameObject audioHubInstance = GameObject.Find("Audio_Manager");
        audioManager = audioHubInstance.GetComponent<AudioManager>();*/

//audioManager.PlayOneShot("Unit_Built_1");
//audioManager.PlayOneShot("LaserBeamer_Fire");
//audioManager.PlayOneShot("Unit_Built_2");

/*    private void Shoot()
    {
        GameObject bulletGO = Instantiate(bulletPrefab, firingPosition.position, firingPosition.rotation);
        Bullet bullet = bulletGO.GetComponent<Bullet>();

        if (bullet != null)
        {
            bullet.SeekTarget(target);
        }
    }*/

/*    public void BuffDefendingUnit_Range(float bonusRangeAmount)
    {
        range += bonusRangeAmount;
    }*/

#endregion