using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class D_Unit_Turret_AS : MonoBehaviour
{
    [Header("Attributes")]
    public Transform target;
    public Enemy_Shield targetShield;
    [SerializeField] string shieldTag = "EnemyShields";
    [SerializeField] float range = 1f;
    [SerializeField] float fireRate = 1f;
    [SerializeField] float fireCountDown = 0f;

    [Header("Unit Rotation")]
    [SerializeField] float turnSpeed = 10f;
    [SerializeField] Transform partToRotate;

    [Header("Bullet Setup")]
    [SerializeField] GameObject bullet_AS_Prefab;
    [SerializeField] Transform firingPosition;

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

/*        if (targetEnemy.isShielded)
        {
            return;
        }*/

        LockOnTarget();

        if (fireCountDown <= 0f)
        {
            Shoot();
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
        GameObject[] Shields = GameObject.FindGameObjectsWithTag(shieldTag);

        float shortestDistance = Mathf.Infinity;
        GameObject nearestShieldObject = null;

        foreach (GameObject ShieldObject in Shields)
        {
            float distanceToShieldObject = Vector3.Distance(transform.position, ShieldObject.transform.position); // set the distance to enemy.

            if (distanceToShieldObject < shortestDistance)
            {
                shortestDistance = distanceToShieldObject;
                nearestShieldObject = ShieldObject;
            }
        }

        if (nearestShieldObject != null && shortestDistance <= range)
        {
            target = nearestShieldObject.transform;
            targetShield = nearestShieldObject.GetComponent<Enemy_Shield>();
        }
        else { target = null; }

    }

    public void Shoot()
    {
        GameObject bulletGO = Instantiate(bullet_AS_Prefab, firingPosition.position, firingPosition.rotation);
        Bullet_AS bullet_AS = bulletGO.GetComponent<Bullet_AS>();

        if (bullet_AS != null)
        {
            bullet_AS.SeekTarget(target);
        }
    }

    public void BuffDefendingUnit(float bonusAmount)
    {
        range += bonusAmount;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
