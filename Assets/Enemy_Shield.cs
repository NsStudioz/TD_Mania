using UnityEngine;

public class Enemy_Shield : MonoBehaviour
{
    [SerializeField] float shieldHealth;

    private void Start()
    {
        gameObject.SetActive(true);
    }

    public void TakeShieldDamage(float amount)
    {
        shieldHealth -= amount;
        if (shieldHealth <= 0f)
        {
            DestroyShield();
        }
    }

    private void DestroyShield()
    {
        gameObject.SetActive(false);
        //Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "AS_Bullet")
        {
            TakeShieldDamage(50);
            Destroy(collider.gameObject);
        }  
    }

}
