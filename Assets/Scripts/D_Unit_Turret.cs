using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class D_Unit_Turret : MonoBehaviour
{

    [Header("Attributes")]
    public Transform target;
    public Enemy targetEnemy;
    public string enemyTag = "Attackers";
    public float range = 1f;
    public float fireRate = 1f;
    public float fireCountDown = 0f;

    [Header("Unit Rotation")]
    public float turnSpeed = 10f;
    public Transform partToRotate;

    [Header("Bullet Setup")]
    public GameObject bulletPrefab;
    public Transform firingPosition;

    [Header("Unit Use Laser?")]
    public bool useLaser = false;


    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    void Update()
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

    private void Shoot()
    {
        GameObject bulletGO = Instantiate(bulletPrefab, firingPosition.position, firingPosition.rotation);
        // Bullet bullet = bulletGO.GetComponent<Bullet>();

/*        if(bullet != null)
        {
            bullet.SeekTarget(target);
        }*/
    }

    private void UseTheLaser()
    {
        return; // do nothing in this method since we don't use it on most turrets.
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }



}
