using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform target;

    //public GameObject impactEffects;

    public float speed = 50f;
    public float explosionRadius = 0f;
    public int damage = 50;

    public void SeekTarget(Transform _target)
    {
        target = _target;
    }

    void Update()
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

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }
}
