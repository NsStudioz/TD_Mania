using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class D_Unit_Buffer : MonoBehaviour
{

    [Header("Attributes")]
    [SerializeField] float rangeRadius = 1f;
    // For Turrets:
    [SerializeField] string defUnit_Tag = "Turrets";
    [SerializeField] string defUnit_Laser_Tag = "TurretLaser";
    [SerializeField] string defUnit_AS_Tag = "Turrets_AS";
    // For Bullets
    [SerializeField] string defBullet_Tag = "Bullet";
    [SerializeField] string defBullet_AS_Tag = "AS_Bullet";
    [SerializeField] string defBullet_AS_Auto_Tag = "AS_Auto_Bullet";
    [SerializeField] string defBullet_AS_SD_Tag = "SD_Bullet";

    // Bonuses:
    [SerializeField] float turret_RangeBonus = 0.5f;
    [SerializeField] float turret_Laser_RangeBonus = 0.5f;
    [SerializeField] int Turret_Laser_DamageBonus = 25;
    [SerializeField] float bulletDamageBonus = 25f;
    [SerializeField] float bullet_AS_DamageBonus = 25f;
    [SerializeField] float bullet_AS_Auto_DamageBonus = 25f;
    [SerializeField] float bullet_AS_SD_DamageBonus = 25f;
    [SerializeField] float bullet_AntiShield_DamageBonus = 25f;

    //
    Bullet bullet;


    void Update()
    {
        CheckRangeRadius();
    }

    private void CheckRangeRadius()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, rangeRadius);
        foreach (Collider collider in colliders)
        {   // Turrets:

                if (collider.tag == "Turrets")
                {
                    InitiateBuffForTurrets(collider.transform); // For Regulars
                }
/*                else if (collider.CompareTag(defUnit_AS_Tag))
                {
                    InitiateBuffForTurrets(collider.transform); // For Anti-Shield
                }
                else if (collider.CompareTag(defUnit_Laser_Tag))
                {
                    InitiateBuffForTurretLaserBeamer(collider.transform); // For Laser-Beamer
                }*/

                // Bullets:
/*                if (collider.tag == defBullet_Tag)
                {
                    bullet.isBuffedByBuffer = true;
                    InitiateBuffForBullets(collider.transform);
                }
                else if (collider.CompareTag(defBullet_AS_Tag))
                {
                    bullet.isBuffedByBuffer = true;
                    InitiateBuffForBullets_AS(collider.transform);
                }
                else if (collider.CompareTag(defBullet_AS_Auto_Tag))
                {
                    bullet.isBuffedByBuffer = true;
                    InitiateBuffForBullets_AS_Auto(collider.transform);
                }
                else if (collider.CompareTag(defBullet_AS_SD_Tag))
                {
                    bullet.isBuffedByBuffer = true;
                    InitiateBuffForBullets_AS_SD(collider.transform);
                }*/


        }
    }

    #region TurretBuffs:
    private void InitiateBuffForTurrets(Transform turret)
    {
        D_Unit_Turret defUnit = GetComponent<D_Unit_Turret>();

        if(defUnit != null)
        {
            defUnit.BuffDefendingUnit_Range(turret_RangeBonus);
            //defUnit.isBuffed = true;
        }
    }

    private void InitiateBuffForTurretLaserBeamer(Transform turret_Laser)
    {
        D_Unit_Turret_LaserBeamer defunit_Laser = GetComponent<D_Unit_Turret_LaserBeamer>();

        if(defunit_Laser != null)
        {
            defunit_Laser.BuffDefendingUnit_Range(turret_Laser_RangeBonus);
            defunit_Laser.BuffDefendingUnit_Damage(Turret_Laser_DamageBonus);
        }
    }

    #endregion

    #region ArsenalBuffs:
    private void InitiateBuffForBullets(Transform thisBullet)
    {
        Bullet defbullet = GetComponent<Bullet>();
        
        if (bullet != null)
        {
            defbullet.BuffBullet(bulletDamageBonus);
        }
    }

    private void InitiateBuffForBullets_AS(Transform thisBullet)
    {
        Bullet defbullet = GetComponent<Bullet>();

        if (bullet != null)
        {
            defbullet.BuffBullet_AS(bullet_AS_DamageBonus);
        }
    }

    private void InitiateBuffForBullets_AS_Auto(Transform thisBullet)
    {
        Bullet defbullet = GetComponent<Bullet>();

        if (bullet != null)
        {
            defbullet.BuffBullet_AS_Auto(bullet_AS_Auto_DamageBonus);
        }
    }

    private void InitiateBuffForBullets_AS_SD(Transform thisBullet)
    {
        Bullet defbullet = GetComponent<Bullet>();

        if (bullet != null)
        {
            defbullet.BuffBullet_AS_SD(bullet_AS_SD_DamageBonus);
        }
    }

    #endregion

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, rangeRadius);
    }

}
