using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class D_Trap_Binder : MonoBehaviour
{

    [SerializeField] float bindRadius = 1f;
    [SerializeField] float bindingDuration = 5f;
    [SerializeField] float triggerRadius = 0.5f;
    [SerializeField] float bindValue = 0f;

    [SerializeField] bool isTriggered;

    public bool startBindingCountdown = false;


    private void Update()
    {
        CheckRangeOnEnemyEncounter();

        if (isTriggered == true)
        {
            startBindingCountdown = true;
            BindingCountdown();
        }

    }

    private void CheckRangeOnEnemyEncounter()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, triggerRadius);
        foreach (Collider collider in colliders)
        {
            if (collider.tag == "Attackers")
            {
                isTriggered = true;
                TriggerBinding();
            }
        }
    }

    private void TriggerBinding()
    {
        Collider[] enemies = Physics.OverlapSphere(transform.position, bindRadius);
        foreach (Collider enemy in enemies)
        {
            if (enemy.tag == "Attackers")
            {
                InitiateBind(enemy.transform);
            }
        }
    }

    private void InitiateBind(Transform enemy)
    {
        Enemy e = enemy.GetComponent<Enemy>();
        
        if (e != null)
        {
            e.BindEnemy(bindValue);

            if (startBindingCountdown == false)
            {
                e.UnbindEnemy();
            }
        }
    }

    private void BindingCountdown()
    {
        if (startBindingCountdown)
        {
            bindingDuration -= Time.deltaTime;

            if (bindingDuration <= 0)
            {
                startBindingCountdown = false;
                Destroy(gameObject);
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, triggerRadius);

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, bindRadius);
    }
}
