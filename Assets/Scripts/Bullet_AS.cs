using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_AS : MonoBehaviour
{
    private Transform target;

    //public GameObject impactEffects;

    [SerializeField] float speed = 50f;
    [SerializeField] float explosionRadius = 0f;
    [SerializeField] float AntiShield_Damage = 50;
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
            HitShieldTarget();
            return;
        }

        // move at a constant speed by using normalized function, while at world space.
        transform.Translate(dir.normalized * distanceThisFrame, Space.World); // Move/fly towards the target
        transform.LookAt(target); // point towards the target.
    }

    private void HitShieldTarget()
    {
        // GameObject effectsIns = Instantiate(impactEffects, transform.position, transform.rotation);

        if (explosionRadius > 0f)
        {
            AntiShieldExplode(); // Damage multiple targets.
        }
        else 
        { 
            AntiShieldDamage(target); // damage only the target.
        } 

        Destroy(gameObject);

    }

    private void AntiShieldExplode()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius); // shoot out a sphere, as an explosion. We'll see what it hits.

        foreach (Collider collider in colliders) // loop through all of the things it hits.
        {
            if (collider.tag == "EnemyShields") // if the colliders are tagged as Enemy.
            {
                AntiShieldDamage(collider.transform); // damage the affected colliders
            }
        }
    }

    private void AntiShieldDamage(Transform enemyShield)
    {
        Enemy_Shield es = enemyShield.GetComponent<Enemy_Shield>();

        if (es != null)
        {
            es.TakeShieldDamage(AntiShield_Damage);
        }
    }

    public void BuffAntiShieldBullet(float buffAmount)
    {
        if (isBuffedByBuffer)
        {
            AntiShield_Damage += buffAmount;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }
}
