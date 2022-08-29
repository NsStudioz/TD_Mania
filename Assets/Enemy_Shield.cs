using UnityEngine;

public class Enemy_Shield : MonoBehaviour
{
    [SerializeField] float shieldHealth;

    private Enemy enemy;

    private void Start()
    {
        gameObject.SetActive(true);
    }

    public void TakeShieldDamage(float amount)
    {
        shieldHealth -= amount;
        if (shieldHealth <= 0f)
        {
            gameObject.SetActive(false);
            enemy.isShielded = false;
            //Destroy(gameObject);
        }
    }

}
