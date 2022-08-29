using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    //public GameObject deathEFX;
    public float startSpeed = 2f;

    [HideInInspector]
    public float movingSpeed;

    [SerializeField] float enemyHealth = 100f;
    [SerializeField] int goldToEarn = 100;
    [SerializeField] Enemy_Shield enemy_Shield;

    // binding:
    public bool isBinded = false;
    public float bindDelay = 2f;
    // Shields:
    public bool isShielded;


    void Start()
    {
        movingSpeed = startSpeed;
    }

    private void Update()
    {
        if(enemy_Shield != null)
        {
            if (enemy_Shield.isActiveAndEnabled)
            {
                isShielded = true;
            }
            else
            {
                isShielded = false;
            }
        }
    }

    public void TakeDamage(float amount)
    {
        enemyHealth -= amount;
        if (enemyHealth <= 0f)
        {
            Die();
        }
    }

    private void Die()
    {
        PlayerStats.Gold += goldToEarn;

/*        GameObject deathEffects = Instantiate(deathEFX, transform.position, Quaternion.identity);
        Destroy(deathEffects, 3f);*/

        Destroy(gameObject);
    }

    internal void SlowEnemyOnLaserHit(float slowPct) // slow percantage on laser hit.
    {
        movingSpeed = startSpeed * (1f - slowPct); // percantages can be misleading since in unity the value is between 0 - 1 (and not 0% - 100%);
    }

/*    public void BindEnemy(float bindValue)
    {
        movingSpeed = startSpeed * bindValue;
    }

    public void UnbindEnemy()
    {
        movingSpeed = startSpeed;
    }*/

    public void BindingEnemy(float bindValue)
    {
        isBinded = true;
        if (isBinded)
        {
            bindDelay -= Time.deltaTime;
            movingSpeed = startSpeed * bindValue;
        }
        
        if(bindDelay <= 0f)
        {
            isBinded = false;
        }
    }
}
