using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy_HealthBar : MonoBehaviour
{


    [SerializeField] Image _HealthBarSprite;
    [SerializeField] Image _ShieldBarSprite;

    public void UpdateEnemyHealthBar(float maxHealth, float currentHealth)
    {
        _HealthBarSprite.fillAmount = currentHealth / maxHealth;
    }

    public void UpdateEnemyShieldBar(float maxHealth, float currentHealth)
    {
        _ShieldBarSprite.fillAmount = currentHealth / maxHealth;
    }
}
