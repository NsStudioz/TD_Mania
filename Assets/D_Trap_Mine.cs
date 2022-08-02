using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class D_Trap_Mine : MonoBehaviour
{
    [Header("Attributes")]
    //public List<GameObject> defUnitsInRange = new List<GameObject>();
    public string defendingUnitTag = "Defenders";
    public float explosionRadius = 1f;
    public int explosionDamage = 100;

    [SerializeField] bool isTriggered;


    void Start()
    {
        isTriggered = false;
    }

    void Update()
    {
        Explode();

        if (isTriggered == true)
        {
            Destroy(gameObject);
        }
    }

    private void Explode()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);
        foreach (Collider collider in colliders)
        {
            if (collider.tag == "Attackers")
            {
                Damage(collider.transform);
                isTriggered = true;
            }
        }
    }

    private void Damage(Transform enemy)
    {
        Enemy e = enemy.GetComponent<Enemy>();

        if (e != null)
        {
            e.TakeDamage(explosionDamage);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }
}
