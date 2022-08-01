using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class D_Unit_Turret_LaserBeamer : MonoBehaviour
{
    [Header("Attributes")]
    public Transform target;
    public Enemy targetEnemy;
    public string enemyTag = "Attackers";
    public float range = 15f;
    public float fireRate = 1f;
    public float fireCountDown = 0f;

    [Header("Unit Rotation")]
    public float turnSpeed = 10f;
    public Transform partToRotate;
    // Bullet setup:
    public GameObject bulletPrefab;
    public Transform firingPosition;

    [Header("Unit Laser Turret")]
    public bool useLaser = false;
    public LineRenderer lineRenderer;
    public ParticleSystem laserImpactEffects;
    public Light laserImpactLight;
    public int damageOverTime = 30;
    public float laserHitSlowPct = .5f;


    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }


    void Update()
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
    }

    private void UseTheLaser()
    {
        targetEnemy.TakeDamage(damageOverTime * Time.deltaTime);
        targetEnemy.SlowEnemyOnLaserHit(laserHitSlowPct);

        if (!lineRenderer.enabled)
        {
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

    private void Shoot()
    {
        GameObject bulletGO = Instantiate(bulletPrefab, firingPosition.position, firingPosition.rotation);
        Bullet bullet = bulletGO.GetComponent<Bullet>();

        if (bullet != null)
        {
            bullet.SeekTarget(target);
        }
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

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
