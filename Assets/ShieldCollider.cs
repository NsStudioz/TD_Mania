using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldCollider : MonoBehaviour
{

    [SerializeField] float range = 1f;

    private void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}

/*    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Attackers"))
        {
            Enemy enemy = other.GetComponent<Enemy>();

            if (enemy.hasShield)
            {
                enemy.isProtected = true;
            }
        }
    }*/

/*    private void CoverNonShieldedEnemiesWithShield()
    {
        if (gameObject.activeSelf)
        {
            Collider[] enemies = Physics.OverlapSphere(transform.position, range); // shoot out a sphere, as range. We'll see what it hits.

            foreach (Collider enemy in enemies) // loop through all of the things it hits.
            {
                if (enemy.tag == "EnemyShields") // if the colliders are tagged as Enemy.
                {
                    Enemy nonShieldedEnemy = GetComponent<Enemy>();

                    if (nonShieldedEnemy != null)
                    {
                        nonShieldedEnemy.isProtected = true;
                    }

                }
            }
        }

    }*/






//[SerializeField] GameObject enemyShield;
/*    [SerializeField] GameObject shieldObject;

    [SerializeField] bool isProtected;*/


