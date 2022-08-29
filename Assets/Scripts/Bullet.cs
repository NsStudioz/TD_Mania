using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Bullet : MonoBehaviour
{
    private IObjectPool<Bullet> bulletPool;
    private Transform target;

    //public GameObject impactEffects;

    [SerializeField] float speed = 10f;
    [SerializeField] float explosionRadius = 0f;
    [SerializeField] float damage = 50;
    //
    [SerializeField] bool useAntiShieldBullets;
    [SerializeField] string shieldTag = "EnemyShields";
    [SerializeField] float Turret_AS_Damage = 50;
    [SerializeField] float AutoTurret_AS_Damage = 50;
    [SerializeField] float shieldDestroyer_AS_Damage = 50;
    //
    public bool isBuffedByBuffer;

    public void SeekTarget(Transform _target)
    {
        target = _target;
    }

    private void Awake()
    {
        isBuffedByBuffer = false;
    }

    private void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return; // stop reading the code from here once destroyed.
        }

        Vector3 dir = target.position - transform.position;

        float distanceThisFrame = speed * Time.deltaTime;

        if (dir.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }

        // move at a constant speed by using normalized function, while at world space.
        transform.Translate(dir.normalized * distanceThisFrame, Space.World); // Move/fly towards the target
        transform.LookAt(target); // point towards the target.
    }

    private void HitTarget()
    {
        // GameObject effectsIns = Instantiate(impactEffects, transform.position, transform.rotation);

        if (explosionRadius > 0f)
        {
            Explode(); // Damage multiple targets.
        }
        else { Damage(target); } // damage only the target.

        Destroy(gameObject);

    }

    private void Explode()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius); // shoot out a sphere, as an explosion. We'll see what it hits.

        foreach (Collider collider in colliders) // loop through all of the things it hits.
        {
            if (collider.tag == "Attackers") // if the colliders are tagged as Enemy.
            {
                Damage(collider.transform); // damage the affected colliders
            }
        }
    }

    private void Damage(Transform enemy)
    {
        Enemy e = enemy.GetComponent<Enemy>();

        if (e != null)
        {
            e.TakeDamage(damage);
        }
    }

    public void buffBullet(float buffAmount)
    {
        if (isBuffedByBuffer)
        {
            damage += buffAmount;
        }
    }

    private void OnTriggerEnter(Collider shieldCollider)
    {
        if (useAntiShieldBullets)
        {
            if (shieldCollider.tag == shieldTag)
            {
                Enemy_Shield shield = shieldCollider.GetComponent<Enemy_Shield>();

                shield.TakeShieldDamage(AutoTurret_AS_Damage);
                Destroy(gameObject);
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }

    // collider trigger testing:
/*    private void OnTriggerEnter(Collider collider)
    {
        Destroy(gameObject);   
    }*/

    // For Object Pooling:

    #region ObjectPooling
    public void SetPool(IObjectPool<Bullet> pool)
    {
        bulletPool = pool;
    }

    private void ForObjectPooling()
    {
        bulletPool.Release(this);
    }

    #endregion

}
