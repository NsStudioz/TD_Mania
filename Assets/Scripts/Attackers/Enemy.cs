using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public GameObject deathEFX;
    public float startSpeed = 2f;
    //
    [HideInInspector]
    public float movingSpeed;
    //
    [SerializeField] float enemyHealth = 100f;
    [SerializeField] int goldToEarn = 100;
    // binding:
    public bool isBinded = false;
    public float bindDelay = 10f;
    // Shields:
    public bool hasShield;
    public bool isProtected;
    [SerializeField] float range = 1f;

    AudioManager audioManager;

    private void Awake()
    {
        GameObject audioHubInstance = GameObject.Find("Audio_Manager");
        audioManager = audioHubInstance.GetComponent<AudioManager>();
    }

    void Start()
    {
        movingSpeed = startSpeed;
    }

    private void Update()
    {
        if (!hasShield)
        {
            Collider[] colliders = Physics.OverlapSphere(transform.position, range);
            foreach (Collider collider in colliders)
            {
                if (collider.CompareTag("EnemyShields") && collider.enabled)
                {
                    isProtected = true;
                }
                else
                {
                    isProtected = false;
                }
            }
        }
    }

    public void TakeDamage(float amount)
    {
        enemyHealth -= amount;
        if (enemyHealth <= 0f)
        {
            audioManager.PlayOneShot("Enemy_Boom");
            Die();
        }
    }

    private void Die()
    {
        PlayerStats.Gold += goldToEarn;

        GameObject deathEffects = Instantiate(deathEFX, transform.position, Quaternion.identity);
        Destroy(deathEffects, 2f);

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

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, range);
    }

}

#region TrashCode:

/*    public void BindEnemy(float bindValue)
{
movingSpeed = startSpeed * bindValue;
}

public void UnbindEnemy()
{
movingSpeed = startSpeed;
}*/


//[SerializeField] Enemy_Shield enemy_Shield;

/*        start method:
 *        if (enemy_Shield != null)
        {
            if (enemy_Shield.isActiveAndEnabled)
            {
                hasShield = true;
            }
        }*/

/*    private void OnTriggerStay(Collider shield)
    {
*//*        if (shield.CompareTag("EnemyShields"))
        {
            isProtected = true;
        }*//*
    }

    private void OnTriggerExit(Collider other)
    {
        *//*isProtected = false;*//*
    }*/

#endregion


