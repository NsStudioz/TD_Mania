using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform target;

    public GameObject impactEffects;

    public float speed = 70f;

    public void SeekTarget(Transform _target)
    {
        target = _target;
    }

    void Update()
    {
        if(target == null)
        {
            Destroy(gameObject);
            return; // stop reading the code from here once destroyed.
        }

        Vector3 dir = target.position - transform.position;

        float distanceThisFrame = speed * Time.deltaTime;

        if(dir.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }

        // move at a constant speed by using normalized function, while at world space.
        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
    }

    private void HitTarget()
    {
        Destroy(target.gameObject); // destroy targeted enemy object when hit by the bullet.
        Destroy(gameObject);
    }
}
