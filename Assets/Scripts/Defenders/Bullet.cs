using System;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    private Transform target;

    public GameObject impactEFX;

    public float speed = 10f;
    public float explosionRadius = 0f;
    public float damage = 50;
    //
    [Header("Anti-Shield Attributes")]
    [SerializeField] bool useAntiShieldBullets;
    [SerializeField] string bulletTags;
    [SerializeField] string shieldTag = "EnemyShields";
    private string antiShield_Tag = "AS_Bullet";
    private string antiShield_Auto_Tag = "AS_Auto_Bullet";
    private string sd_Destroyer_Tag = "SD_Bullet";
    public float turret_AS_Damage = 25f;
    public float autoTurret_AS_Damage = 20f;
    public float shieldDestroyer_AS_Damage = 50f;

    // EVENTS:
    public static event Action OnBulletImpact_Bullet;
    public static event Action OnBulletImpact_Missile;
    public static event Action OnBulletImpact_BulletAuto;

    public void SeekTarget(Transform _target)
    {
        target = _target;
    }

    private void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return; // stop reading the code from here once destroyed.
        }

        Vector3 dir = target.position - transform.position;

        float distanceThisFrame = speed * Time.deltaTime;

        if (dir.magnitude <= distanceThisFrame)
        {
            HitTarget();        
            return;
        }

        // move at a constant speed by using normalized function, while at world space.
        transform.Translate(dir.normalized * distanceThisFrame, Space.World); // Move/fly towards the target
        transform.LookAt(target); // point towards the target.
    }

    private void HitTarget()
    {
        GameObject bullet_EFX_Ins = Instantiate(impactEFX, transform.position, transform.rotation);

        if (!useAntiShieldBullets)
        {
            if (explosionRadius > 0f)
            {
                Explode(); // Damage multiple targets.
            }
            else 
            {
                Damage(target); // damage only the target.
            } 
        }

        Destroy(gameObject);
    }

    private void Explode()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius); // shoot out a sphere, as an explosion. We'll see what it hits.

        foreach (Collider collider in colliders) // loop through all of the things it hits.
        {
            if (collider.tag == "Attackers") // if the colliders are tagged as Enemy.
            {
                Damage(collider.transform); // damage the affected colliders
                PlayBulletImpactSFX();
            }
        }
    }

    private void Damage(Transform enemy)
    {
        Enemy e = enemy.GetComponent<Enemy>();

        if (e != null)
        {
            e.TakeDamage(damage);
            PlayBulletImpactSFX();
        }
    }

    private void OnTriggerEnter(Collider shieldCollider)
    {
        if (useAntiShieldBullets)
        {

            if (shieldCollider.tag == shieldTag)
            {
                GameObject antiShieldImpactEFX = Instantiate(impactEFX, transform.position, transform.rotation);

                PlayBulletImpactSFX();

                Enemy_Shield shield = shieldCollider.GetComponent<Enemy_Shield>();

                if (gameObject.CompareTag(antiShield_Tag))
                {
                    shield.TakeShieldDamage(turret_AS_Damage);
                }
                else if (gameObject.CompareTag(antiShield_Auto_Tag))
                {
                    shield.TakeShieldDamage(autoTurret_AS_Damage);
                }
                else if (gameObject.CompareTag(sd_Destroyer_Tag))
                {
                    shield.TakeShieldDamage(shieldDestroyer_AS_Damage);
                }
                
                Destroy(gameObject);
            }
        }
        else if (useAntiShieldBullets)
        {
            if (shieldCollider.tag != shieldTag)
            {
                Destroy(gameObject);
            }
        }
        else if (!useAntiShieldBullets)
        {
            if (shieldCollider.tag == shieldTag)
            {
                Destroy(gameObject);
            }
        }
    }

    private void PlayBulletImpactSFX()
    {
        if(bulletTags == "Bullet")
        {
            OnBulletImpact_Bullet?.Invoke();
        }
        else if (bulletTags == "Bullet_Auto")
        {
            OnBulletImpact_BulletAuto?.Invoke();
        }
        else if (bulletTags == "Missile")
        {
            OnBulletImpact_Missile?.Invoke();
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }

}

#region Trash_Code:

/*    AudioManager audioManager;*/
/*    private void Start()
    {
        GameObject audioHubInstance = GameObject.Find("Audio_Manager");
        audioManager = audioHubInstance.GetComponent<AudioManager>();
    }*/

/*        else if (!useAntiShieldBullets)
        {
            if (shieldCollider.tag != shieldTag)
            {
                Destroy(gameObject);
            }
        }*/

/*    private void OnTriggerEnter(Collider shieldCollider)
    {
        if (useAntiShieldBullets)
        {
            if (shieldCollider.tag == shieldTag)
            {
                Enemy_Shield shield = shieldCollider.GetComponent<Enemy_Shield>();

                shield.TakeShieldDamage(AutoTurret_AS_Damage);
                Destroy(gameObject);
            }
        }
        else if (useAntiShieldBullets)
        {
            if (shieldCollider.tag != shieldTag)
            {
                Destroy(gameObject);
            }
        }
        else if (!useAntiShieldBullets)
        {
            if (shieldCollider.tag == shieldTag)
            {
                Destroy(gameObject);
            }
        }
        */
/*        else if (!useAntiShieldBullets)
                {
                    if (shieldCollider.tag != shieldTag)
                    {
                        Destroy(gameObject);
                    }
                }*/
/*
    }*/


/*    private void HitTarget()
    {
        // GameObject effectsIns = Instantiate(impactEffects, transform.position, transform.rotation);

        if (explosionRadius > 0f)
        {
            Explode(); // Damage multiple targets.
        }
        else { Damage(target); } // damage only the target.

        Destroy(gameObject);

    }*/

/*    public void BuffBullet(float buffAmount)
    {
        if (isBuffedByBuffer)
        {
            damage += buffAmount;
        }
    }

    public void BuffBullet_AS(float buffAmount) // Anti-Shield
    {
        if (isBuffedByBuffer)
        {
            turret_AS_Damage += buffAmount;
        }
    }

    public void BuffBullet_AS_Auto(float buffAmount) // Anti-Shield Auto
    {
        if (isBuffedByBuffer)
        {
            autoTurret_AS_Damage += buffAmount;
        }
    }

    public void BuffBullet_AS_SD(float buffAmount) // Shield Destroyer
    {
        if (isBuffedByBuffer)
        {
            shieldDestroyer_AS_Damage += buffAmount;
        }
    }*/

// For Object Pooling:

/*#region ObjectPooling
public void SetPool(IObjectPool<Bullet> pool)
    {
        bulletPool = pool;
    }

    private void ForObjectPooling()
    {
        bulletPool.Release(this);
    }

    #endregion*/

#endregion
