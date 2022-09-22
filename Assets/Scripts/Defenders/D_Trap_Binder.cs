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
    //
    // Vars for stopping unnecessary enemies from getting trapped:
    SphereCollider sphereCol;
    [SerializeField] float trapTimeElapsed;
    [SerializeField] float trapTimeThreshold = 2f;


    private void Start()
    {
        trapTimeElapsed = trapTimeThreshold;

        sphereCol = GetComponent<SphereCollider>();
        sphereCol.enabled = false;
    }

    private void Update()
    {
        EnableBind();

        if (sphereCol.enabled)
        {
            trapTimeElapsed -= Time.deltaTime;

            if (trapTimeElapsed <= 0f)
            {
                sphereCol.enabled = false;
            }
        }

        if (isTriggered)
        {
            bindingDuration -= Time.deltaTime;

            if (bindingDuration <= 0f)
            {
                Destroy(gameObject);
            }  
        }
    }

    private void EnableBind()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, triggerRadius);
        foreach (Collider collider in colliders)
        {
            if (collider.tag == "Attackers")
            {
                sphereCol.enabled = true;
                isTriggered = true;
            }
        }
    }

    #region Backup:
    //    [SerializeField] float bindValue = 0f; // enemy speed if on bind radius of trap
    //   private bool startBindingCountdown = false;

    ///
    /*        CheckRangeOnEnemyEncounter();

        if (isTriggered == true)
        {
            startBindingCountdown = true;
            BindingCountdown();
        }*/

    /*        if (bindOn)
            {
                trapTimeElapsed -= Time.deltaTime;

                if (trapTimeElapsed <= 0)
                {
                    bindOn = false;
                    bindRadius = 0f;
                }
            }*/
    /// 

    /*    private void CheckRangeOnEnemyEncounter()
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
        }*/

    #endregion



    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, triggerRadius);

/*        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, bindRadius);*/
    }
}
