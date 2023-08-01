using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Shield : MonoBehaviour
{
    [SerializeField] float shieldHealth;
    [SerializeField] float current_shieldHealth;
    [SerializeField] bool shieldOn = true;
    public float range;
    [SerializeField] float rangeTimerDelay = 1f;
    private float sizeChangeDelay = 0.05f;

    Enemy enemy;
    SphereCollider shieldCollider;
    MeshRenderer shield_renderer;

    [Header("Shield Bar")]
    [SerializeField] Enemy_HealthBar _ShieldBar;
    [SerializeField] GameObject _ShieldBar_Canvas_GO;
    [SerializeField] float shieldBarDelay_Threshold = 4f;
    [SerializeField] float shieldBarDelay;
    [SerializeField] bool showShieldBar = false;

    public bool GetShieldStatus()
    {
        return shieldOn;
    }

    private void CacheComponents()
    {
        shield_renderer = GetComponent<MeshRenderer>();
        shieldCollider = GetComponent<SphereCollider>();
        enemy = GetComponentInParent<Enemy>();
    }

    private void Start()
    {
        current_shieldHealth = shieldHealth;
        shieldOn = true;

        CacheComponents();
        UpdateShieldBarUI(false);
    }

    private void Update() => ShieldBarTimer();

    public void TakeShieldDamage(float amount)
    {
        current_shieldHealth -= amount;

        if (current_shieldHealth <= 0f)
        {
            DeactivateShield();
            DestroyShield();
            RemoveEnemiesShieldProtection();
            //
            SetShieldRangeToZero();
            //
            UpdateShieldBarUI(false);
            return;
        }

        UpdateShieldBarUI(true);
    }

    private void DestroyShield()
    {
        if (!shieldOn)
        {
            shieldCollider.enabled = false;
            shield_renderer.enabled = false;
            enemy.hasShield = false;
        }
    }

    private void OnTriggerEnter(Collider bullet)
    {
        if (bullet.CompareTag("AS_Bullet") || bullet.CompareTag("AS_Auto_Bullet") || bullet.CompareTag("SD_Bullet"))
            if (shieldOn)
                StartCoroutine(ShieldHitEffect());
    }

    private IEnumerator ShieldHitEffect()
    {
        transform.localScale = new Vector3(9.75f, 9.75f, 9.75f);
        yield return new WaitForSecondsRealtime(sizeChangeDelay);
        transform.localScale = new Vector3(10f, 10f, 10f);
    }

    private void DeactivateShield()
    {
        shieldOn = false;
        showShieldBar = false;
    }

    private void RemoveEnemiesShieldProtection()
    {
        if (!shieldOn)
        {
            Collider[] attackers = Physics.OverlapSphere(transform.position, range);

            foreach (Collider attacker in attackers)
                if (attacker.tag == "Attackers")
                {
                    Enemy noShield_enemy = attacker.GetComponent<Enemy>();

                    noShield_enemy.isProtected = false;
                }
        }
    }

    private void SetShieldRangeToZero()
    {
        range = 0f;
    }


    #region Enemy_Shield_Bar

    private void UpdateShieldBarUI(bool state)
    {
        ShieldBarVisibility(state);
        CalculateShieldBarUI();
    }


    private void CalculateShieldBarUI()
    {
        _ShieldBar.UpdateEnemyShieldBar(shieldHealth, current_shieldHealth);

        shieldBarDelay = shieldBarDelay_Threshold;
    }

    private void ShieldBarVisibility(bool state)
    {
        showShieldBar = state;

        if (showShieldBar) 
            _ShieldBar_Canvas_GO.SetActive(true);
        else 
            _ShieldBar_Canvas_GO.SetActive(false);
    }

    private void ShieldBarTimer()
    {
        if (showShieldBar)
        {
            shieldBarDelay -= Time.deltaTime;

            if (shieldBarDelay <= 0) 
                showShieldBar = false;
        }
    }
    #endregion

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}







