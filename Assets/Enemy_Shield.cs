using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Shield : MonoBehaviour
{
    [SerializeField] float shieldHealth;

    public void TakeShieldDamage(float amount)
    {
        shieldHealth -= amount;
        if (shieldHealth <= 0f)
        {
            Destroy(gameObject);
        }
    }

}
