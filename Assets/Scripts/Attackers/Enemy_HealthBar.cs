using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy_HealthBar : MonoBehaviour
{

    Enemy enemy;

    [SerializeField] Image _HealthBarSprite;

    void Start()
    {
        enemy = GetComponent<Enemy>();
    }

    void Update()
    {
        
    }

    public void UpdateEnemyHealthBar(float maxHealth, float currentHealth)
    {
        _HealthBarSprite.fillAmount = currentHealth / maxHealth * Time.deltaTime;
    }

    public void UpdateEnemyHealthBar(float maxHealth)
    {
        _HealthBarSprite.fillAmount = maxHealth * Time.deltaTime;
    }
}
