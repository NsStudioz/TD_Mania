using UnityEngine;

public class D_Trap_AntiShield : MonoBehaviour
{

    [Header("Attributes")]
    [SerializeField] float explosionRadius;
    [SerializeField] float explosionDamage = 100f;
    [SerializeField] float triggerRadius;
    [SerializeField] bool isTriggered;

    [Header("Animations")]
    [SerializeField] Animator animController = null;
    [SerializeField] string animation_IdleName;
    [SerializeField] string animation_ActivateName;
    [SerializeField] string animation_BuildName;
    [SerializeField] string animation_RemoveName;
    [SerializeField] bool trapReady = false;

    private void OnEnable()
    {
        animController.Play(animation_BuildName);
    }

    void Update()
    {
        if (trapReady)
        {
            CheckRangeOnEnemyEncounter();

            if (isTriggered)
            {
                Destroy(gameObject);
            }
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
                ExplodeOnCollider();
            }
        }
    }

    private void ExplodeOnCollider()
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

    public void EnableTrap()
    {
        trapReady = true;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, triggerRadius);

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }

}
