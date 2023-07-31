using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public static event Action OnEnemy_Death_SFX;

    [HideInInspector]
    public float movingSpeed; // actual enemy speed

    [Header("Elements")]
    [SerializeField] private GameObject deathEFX;
    [SerializeField] private int goldToEarn = 100;
    [SerializeField] private float startSpeed = 2f;

    [Header("Elements")]
    [SerializeField] private float enemyHealth = 100f;
    [SerializeField] private float currentEnemyHealth;

    [Header("Shields")]
    public bool hasShield;
    public bool isProtected;
    [SerializeField] private float range = 1f;
    //
    [Header("Health Bar")]
    [SerializeField] private Enemy_HealthBar _healthBar;
    [SerializeField] private GameObject _healthBar_Canvas_GO;
    [SerializeField] private float healthBarDelay_Threshold = 4f;
    [SerializeField] private float healthBarDelay;
    [SerializeField] private bool showHealthBar = false;
   
    public float GetStartSpeed()
    {
        return startSpeed;
    }

    public float GetMovingSpeed()
    {
        return movingSpeed;
    }

    public void ResetEnemyMovementSpeed()
    {
        movingSpeed = startSpeed;
    }

    public void StopEnemyMovement()
    {
        movingSpeed = startSpeed * 0f;
    }

    void Start()
    {
        movingSpeed = startSpeed;
        currentEnemyHealth = enemyHealth;

        HealthBarVisibility(false);
        CalculateHealthBarUI();
    }

    private void Update() => HealthBarTimer();


    public void TakeDamage(float amount)
    {
        currentEnemyHealth -= amount;

        if (currentEnemyHealth <= 0f)
        {
            OnEnemy_Death_SFX?.Invoke();
            Die();
        }

        UpdateHealthBarUI();
    }

    #region Enemy_HealthBar:

    private void UpdateHealthBarUI()
    {
        HealthBarVisibility(true);
        CalculateHealthBarUI();
    }

    private void HealthBarVisibility(bool state)
    {
        showHealthBar = state;

        if (showHealthBar) 
            _healthBar_Canvas_GO.SetActive(true);
        else
            _healthBar_Canvas_GO.SetActive(false);
    }

    private void HealthBarTimer()
    {
        if (showHealthBar)
        {
            healthBarDelay -= Time.deltaTime;

            if (healthBarDelay <= 0)
                HealthBarVisibility(false);
        }
    }

    private void CalculateHealthBarUI()
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

    public void SlowEnemyOnLaserHit(float slowPct) // slow percantage on laser hit.
    {
        movingSpeed = startSpeed * (1f - slowPct); // percantages can be misleading since in unity the value is between 0 - 1 (and not 0% - 100%);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, range);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("EnemyShields"))
            isProtected = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("EnemyShields"))
            isProtected = false;
    }
}


/*    [Header("Binding")]
    public bool isBinded = false;
    public float bindDelay = 10f;*/

/*    public void BindingEnemy(float bindValue)
    {
        isBinded = true;
        if (isBinded)
        {
            bindDelay -= Time.deltaTime;
            movingSpeed = startSpeed * bindValue;
        }
        
        if (bindDelay <= 0f) 
            isBinded = false;
    }
*/
