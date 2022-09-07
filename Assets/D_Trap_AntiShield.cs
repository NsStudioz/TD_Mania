using UnityEngine;

public class D_Trap_AntiShield : MonoBehaviour
{

    [Header("Attributes")]
    [SerializeField] float triggerRadius;
    [SerializeField] float explosionRadius;
    [SerializeField] bool isTriggered;
    [SerializeField] bool Explode;
    [SerializeField] float explosionDamage = 100f;

    void Update()
    {
        CheckRangeOnEnemyEncounter();

        if (isTriggered)
        {
            Destroy(gameObject);
        }
    }

    private void CheckRangeOnEnemyEncounter()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, triggerRadius);
        foreach(Collider collider in colliders)
        {
            if(collider.tag == "EnemyShields")
            {
                isTriggered = true;
                ExlodeOnCollider();
            }
        }
    }

    private void ExlodeOnCollider()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);
        foreach (Collider collider in colliders)
        {
            if(collider.tag == "EnemyShields")
            {
                Damage(collider.transform);
            }
        }
    }

    private void Damage(Transform enemyShield)
    {
        Enemy_Shield eS = enemyShield.GetComponent<Enemy_Shield>();

        if (eS != null)
        {
            eS.TakeShieldDamage(explosionDamage);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, triggerRadius);

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }

}
