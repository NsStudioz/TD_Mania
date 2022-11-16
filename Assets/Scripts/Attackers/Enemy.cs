using System;
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
    [SerializeField] float currentEnemyHealth;
    [SerializeField] int goldToEarn = 100;
    // binding:
    public bool isBinded = false;
    public float bindDelay = 10f;
    // Shields:
    public bool hasShield;
    public bool isProtected;
    [SerializeField] float range = 1f;
    //
    public static event Action OnEnemy_Death_SFX;

    [Header("Health Bar")]
    [SerializeField] Enemy_HealthBar _healthBar;
    [SerializeField] GameObject _healthBar_Canvas_GO;
    [SerializeField] float healthBarDelay_Threshold = 4f;
    [SerializeField] float healthBarDelay;
    [SerializeField] bool healthBar_Switch = false;

    void Start()
    {
        movingSpeed = startSpeed;
        currentEnemyHealth = enemyHealth;

        UpdateHealthBar();
    }

    private void Update()
    {
        if (!hasShield)
        {
            Collider[] colliders = Physics.OverlapSphere(transform.position, range);
            foreach (Collider collider in colliders)
            {
                if (collider.CompareTag("EnemyShields") && collider.enabled) { isProtected = true; }

                else { isProtected = false; }
            }
        }

        HealthBarVisibility();
        HealthBarTimer();
    }

    public void TakeDamage(float amount)
    {
        currentEnemyHealth -= amount;
        UpdateHealthBar();
        healthBar_Switch = true;

        if (currentEnemyHealth <= 0f)
        {
            OnEnemy_Death_SFX?.Invoke();
            Die();
        }
    }

    #region Enemy_HealthBar
    private void HealthBarVisibility()
    {
        if (healthBar_Switch) { _healthBar_Canvas_GO.SetActive(true); }
        else                  { _healthBar_Canvas_GO.SetActive(false); }
    }

    private void HealthBarTimer()
    {
        if (healthBar_Switch)
        {
            healthBarDelay -= Time.deltaTime;

            if (healthBarDelay <= 0) { healthBar_Switch = false; }
        }
    }

    private void UpdateHealthBar()
    {
        _healthBar.UpdateEnemyHealthBar(enemyHealth, currentEnemyHealth);

        healthBarDelay = healthBarDelay_Threshold;
    }
    #endregion

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
        
        if(bindDelay <= 0f) { isBinded = false; }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, range);
    }

}

/*    AudioManager audioManager;

    private void Awake()
    {
        GameObject audioHubInstance = GameObject.Find("Audio_Manager");
        audioManager = audioHubInstance.GetComponent<AudioManager>();
    }
*/
//audioManager.PlayOneShot("Enemy_Boom");

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


