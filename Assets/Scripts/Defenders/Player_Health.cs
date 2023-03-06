using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Health : MonoBehaviour
{

    [SerializeField] float range = 0f;

/*    private void Update()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, range);
        foreach (Collider collider in colliders)
        {
            if (collider.CompareTag("Attackers"))
            {
                PlayerStats.Lives--;
                Destroy(collider.gameObject);
            }
        }
    }*/

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position, range);
    }

    private void OnTriggerEnter(Collider enemy)
    {
        if (enemy.CompareTag("Attackers"))
        {
            PlayerStats.Lives--;
            Destroy(enemy.gameObject);
        }
    }

}
