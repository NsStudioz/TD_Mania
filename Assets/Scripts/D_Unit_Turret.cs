using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class D_Unit_Turret : MonoBehaviour
{

    [Header("Attributes")]
    public Transform target;
    public Enemy targetEnemy;
    [SerializeField] string enemyTag = "Attackers";
    [SerializeField] float range = 1f;
    [SerializeField] float fireRate = 1f;
    [SerializeField] float fireCountDown = 0f;

    [Header("Unit Rotation")]
    [SerializeField] float turnSpeed = 10f;
    [SerializeField] Transform partToRotate;

    [Header("Bullet Setup")]
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] Transform firingPosition;
    // Object Pooling:
    private IObjectPool<Bullet> bulletPool;
    [SerializeField] Bullet bulletPrefab_New;
    

/*    [Header("Unit Use Laser?")]
    [SerializeField] bool useLaser = false;*/

    private void Awake()
    {
        //bulletPool = new ObjectPool<Bullet>(CreateBullet, OnGet);
    }

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

            if (fireCountDown <= 0f)
            {
                Shoot();
                //bulletPool.Get();
                //AimAtTarget();
                fireCountDown = 1f / fireRate;
            }

            fireCountDown -= Time.deltaTime;
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
        Bullet bullet = bulletGO.GetComponent<Bullet>();

        if (bullet != null)
        {
            bullet.SeekTarget(target);
        }
    }

/*    private void UseTheLaser()
    {
        return; // do nothing in this method since we don't use it on most turrets.
    }*/

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }

    //
    // FOR OBJECT POOLING:
    //

    #region ObjectPooling
    private void AimAtTarget()
    {
        Bullet bullet = GetComponent<Bullet>();

        if (bullet != null)
        {
            bullet.SeekTarget(target);
        }
    }

    private Bullet CreateBullet()
    {
        Bullet bullet = Instantiate(bulletPrefab_New);
        bullet.SetPool(bulletPool);
        return bullet;
    }

    private void OnGet(Bullet bullet)
    {
        bullet.gameObject.SetActive(true);
        bullet.transform.position = firingPosition.transform.position;
    }

    private void OnRelease(Bullet bullet)
    {
        bullet.gameObject.SetActive(false);
    }

    private void OnDestroyBullet(Bullet bullet)
    {
        Destroy(bullet.gameObject);
    }
    #endregion

    #region OldUpdateMethod

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

    #endregion

}
