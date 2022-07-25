using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Test : MonoBehaviour
{
    public float startSpeed = 2f;
    public int waypointIndex = 0;

    //[HideInInspector]
    public float movingSpeed;

    public float enemyHealth = 100f;
    public int goldToEarn = 100;

    void Start()
    {
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

        Destroy(gameObject);
    }

    internal void SlowEnemyOnLaserHit(float slowPct) // slow percantage on laser hit.
    {
        movingSpeed = startSpeed * (1f - slowPct); // percantages can be misleading since in unity the value is between 0 - 1 (and not 0% - 100%);
    }
}
