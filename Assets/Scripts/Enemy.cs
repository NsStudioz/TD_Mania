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
    //[SerializeField] Enemy_Shield enemy_Shield;
    SphereCollider enemyBodyCollider;
    // binding:
    public bool isBinded = false;
    public float bindDelay = 2f;
    // Shields:
    public bool hasShield;
    public bool isProtected;
/*    [SerializeField] float range = 1f;*/


    void Start()
    {
        enemyBodyCollider = GetComponent<SphereCollider>();
/*        if (enemy_Shield != null)
        {
            if (enemy_Shield.isActiveAndEnabled)
            {
                hasShield = true;
            }
        }*/

        movingSpeed = startSpeed;
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


    private void OnTriggerStay(Collider shield)
    {
        if (shield.CompareTag("EnemyShields"))
        {
            isProtected = true;
        }   
    }

}

    /*    public void TurnOnShields()
{
    isShielded = true;
}*/

    /*    public void BindEnemy(float bindValue)
{
    movingSpeed = startSpeed * bindValue;
}

public void UnbindEnemy()
{
    movingSpeed = startSpeed;
}*/

/*    private void Update()
{

*//*        if(enemy_Shield != null)
        {
            if (enemy_Shield.isActiveAndEnabled)
            {
                isShielded = true;
            }

            else if (!enemy_Shield.isActiveAndEnabled)
            {
                isShielded = false;
            }
            else
            {
                isShielded = false;
            }
        }*//*
    }*/

/*    private void OnTriggerStay(Collider shieldCol)
    {
        if (!hasShield)
        {
            if (shieldCol.tag == "Attacker")
            {
                Enemy enemy = shieldCol.GetComponent<Enemy>();

                if (enemy.hasShield)
                {
                    hasShield = true;
                }

            }
        }*/

/*        if (!isShielded)
        {
            if (shieldCol.tag == "EnemyShield")
            {
                Enemy enemy = shieldCol.GetComponent<Enemy>();
                enemy.isShielded = false;
            }
        }*/




/*    private void OnTriggerExit(Collider shieldColl)
    {
        if (isShielded)
        {
            if (shieldColl.tag == "Attackers")
            {
                Enemy enemy = shieldColl.GetComponent<Enemy>();
                enemy.isShielded = false;
            }
        }
    }*/

//}



