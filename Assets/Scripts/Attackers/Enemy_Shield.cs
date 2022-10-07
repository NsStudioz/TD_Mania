using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Shield : MonoBehaviour
{
    [SerializeField] float shieldHealth;
    [SerializeField] bool shieldOn;
    public float range = 1f;
    private float sizeChangeDelay = 0.05f;

    Enemy enemy;
    SphereCollider shieldCollider;

    private void Start()
    {
        gameObject.SetActive(true);

        shieldCollider = GetComponent<SphereCollider>();

        enemy = GetComponentInParent<Enemy>();

        shieldOn = true;
    }

    private void Update()
    {

    }

    public void TakeShieldDamage(float amount)
    {
        shieldHealth -= amount;
        if (shieldHealth <= 0f)
        {
            DestroyShield();
            shieldOn = false;
        }
    }

    private void DestroyShield()
    {
        shieldCollider.enabled = false;
        gameObject.SetActive(false);
        enemy.hasShield = false;
        //Destroy(gameObject);
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

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}







