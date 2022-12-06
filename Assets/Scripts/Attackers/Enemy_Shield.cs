using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Shield : MonoBehaviour
{
    [SerializeField] float shieldHealth;
    [SerializeField] float current_shieldHealth;
    [SerializeField] bool shieldOn;
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
    [SerializeField] bool shieldBar_Switch = false;

    public bool GetShieldStatus()
    {
        return shieldOn;
    }

    private void Start()
    {
        current_shieldHealth = shieldHealth;

        gameObject.SetActive(true);

        shield_renderer = GetComponent<MeshRenderer>();
        shieldCollider = GetComponent<SphereCollider>();
        enemy = GetComponentInParent<Enemy>();

        shieldOn = true;
    }

    private void Update()
    {
        ShieldBarVisibility();
        ShieldBarTimer();

        RemoveEnemiesProtection();
        CalculateRangeOnShieldOff();
    }

    public void TakeShieldDamage(float amount)
    {
        current_shieldHealth -= amount;
        shieldBar_Switch = true;

        UpdateShieldBar();

        if (current_shieldHealth <= 0f)
        {
            DestroyShield();
            _ShieldBar_Canvas_GO.SetActive(false);
            shieldOn = false;
        }
    }

    private void DestroyShield()
    {
        shieldCollider.enabled = false;
        shield_renderer.enabled = false;
        //gameObject.SetActive(false);
        enemy.hasShield = false;
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("AS_Bullet") || collider.CompareTag("AS_Auto_Bullet") || collider.CompareTag("SD_Bullet"))
        {
            if (shieldOn)
            {
                StartCoroutine(ShieldHitEffect());
            }
        }
    }

    private IEnumerator ShieldHitEffect()
    {
        transform.localScale = new Vector3(9.75f, 9.75f, 9.75f);
        yield return new WaitForSecondsRealtime(sizeChangeDelay);
        transform.localScale = new Vector3(10f, 10f, 10f);
    }

    private void RemoveEnemiesProtection()
    {
        if (!shieldOn)
        {
            Collider[] attackers = Physics.OverlapSphere(transform.position, range);
            foreach (Collider attacker in attackers)
            {
                if (attacker.tag == "Attackers")
                {
                    Enemy noShield_enemy = attacker.GetComponent<Enemy>();

                    noShield_enemy.isProtected = false;
                }
            }
        }
    }

    private void CalculateRangeOnShieldOff()
    {
        if (!shieldOn)
        {
            rangeTimerDelay -= Time.deltaTime;

            if (rangeTimerDelay <= 0f)
            {
                range = 0f;
            }
        }
    }


    #region Enemy_Shield_Bar
    private void UpdateShieldBar()
    {
        _ShieldBar.UpdateEnemyShieldBar(shieldHealth, current_shieldHealth);

        shieldBarDelay = shieldBarDelay_Threshold;
    }

    private void ShieldBarVisibility()
    {
        if (shieldBar_Switch) { _ShieldBar_Canvas_GO.SetActive(true); }
        else { _ShieldBar_Canvas_GO.SetActive(false); }
    }

    private void ShieldBarTimer()
    {
        if (shieldBar_Switch)
        {
            shieldBarDelay -= Time.deltaTime;

            if (shieldBarDelay <= 0) { shieldBar_Switch = false; }
        }
    }
    #endregion

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}







