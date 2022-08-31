using UnityEngine;

public class Enemy_Shield : MonoBehaviour
{
    [SerializeField] float shieldHealth;
    public float range = 1f;

    Enemy enemy;

    private void Start()
    {
        gameObject.SetActive(true);

        enemy = GetComponentInParent<Enemy>();
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
        }
    }

    private void DestroyShield()
    {
        gameObject.SetActive(false);
        enemy.hasShield = false;
        //Destroy(gameObject);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}



/*    private void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "AS_Bullet")
        {
            TakeShieldDamage(50);
            Destroy(collider.gameObject);
        }  
    }*/



