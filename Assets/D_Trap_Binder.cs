using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class D_Trap_Binder : MonoBehaviour
{

    [SerializeField] float bindRadius = 1f;
    [SerializeField] float bindingDuration = 2f;
    [SerializeField] float triggerRadius = 0.5f;
    [SerializeField] float bindValue = 0f;

    [SerializeField] float delayTime = 1f; // stop the binding effect on unaffected enemies if is triggered.
    [SerializeField] bool bindOn = false;
    [SerializeField] bool isTriggered;


    private bool startBindingCountdown = false;

    private void Update()
    {
        CheckRangeOnEnemyEncounter();

        if (isTriggered == true)
        {
            startBindingCountdown = true;
            BindingCountdown();
        }
        /////////////////
/*        if (bindOn)
        {
            delayTime -= Time.deltaTime;
        }

        if (delayTime <= 0)
        {
            bindOn = false;
        }

        if (!bindOn)
        {
            delayTime = 1f;
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

    public void InitiateBind(Transform enemy)
    {
        Enemy e = enemy.GetComponent<Enemy>();
        
        if (e != null)
        {
            e.BindingEnemy(bindValue);
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
