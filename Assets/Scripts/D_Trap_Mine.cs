using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class D_Trap_Mine : MonoBehaviour
{
    [Header("Attributes")]
    //public List<GameObject> defUnitsInRange = new List<GameObject>();
    //public string defendingUnitTag = "Defenders";
    [SerializeField] float explosionRadius = 1f;
    [SerializeField] float explosionDamage = 100;
    [SerializeField] float triggerRadius = 0.5f;

    [SerializeField] bool isTriggered;


    void Start()
    {
        isTriggered = false;
    }

    void Update()
    {
        CheckRangeOnEnemyEncounter();

/*        if (isTriggered == true)
        {
            Destroy(gameObject);
        }*/
    }

    private void CheckRangeOnEnemyEncounter()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, triggerRadius);
        foreach (Collider collider in colliders)
        {
            if (collider.tag == "Attackers")
            {
                isTriggered = true;
                Explode();
                Destroy(gameObject);
            }
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
                //isTriggered = false;
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

    public void BuffTrap(float buffAmount)
    {
        explosionDamage += buffAmount;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, triggerRadius);

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
        
    }
}
