using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class D_Trap_Binder : MonoBehaviour
{

    [SerializeField] float bindRadius = 1f;
    [SerializeField] float bindingDuration = 2f;
    [SerializeField] float triggerRadius = 0.5f;

    [SerializeField] bool isTriggered;

    [SerializeField] bool startBindingCountdown = false;


    private void Update()
    {
        CheckRangeOnEnemyEncounter();

        if (isTriggered == true)
        {
            gameObject.SetActive(false);
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
        Collider[] colliders = Physics.OverlapSphere(transform.position, bindRadius);
        foreach (Collider collider in colliders)
        {
            if (collider.tag == "Attackers")
            {
                InitiateBind(collider.transform);
            }
        }
    }

    private void InitiateBind(Transform transform)
    {
        Enemy e = GetComponent<Enemy>();

        if (e != null)
        {
            e.BindEnemy();
            startBindingCountdown = true;
            if (startBindingCountdown)
            {
                bindingDuration -= Time.deltaTime;

                if (bindingDuration <= 0f)
                {
                    startBindingCountdown = false;
                    e.UnbindEnemy();
                    Destroy(gameObject);
                }
            }
        }
    }
}
