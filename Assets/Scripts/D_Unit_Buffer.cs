using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

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

    [Header("Events")]
    [SerializeField] bool isCollision;
    //
    Bullet bullet;

    void Start()
    {
        isCollision = false;    
    }


    void Update()
    {

    }

    private void CheckRangeRadius()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, rangeRadius);
        foreach (Collider collider in colliders)
        {   // Turrets:
            if (collider.CompareTag("Defenders"))
            {
                isCollision = true;
            }
        }
    }


    #region TurretBuffs:
    private void InitiateBuffForTurretLaserBeamer(Transform turret_Laser)
    {
        D_Unit_Turret_LaserBeamer defunit_Laser = GetComponent<D_Unit_Turret_LaserBeamer>();

        if(defunit_Laser != null)
        {
            defunit_Laser.BuffDefendingUnit_Range(turret_Laser_RangeBonus);
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


    #endregion

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, rangeRadius);
    }

}

#region TrashCode:
/*private void CheckRangeRadius()
{
    Collider[] colliders = Physics.OverlapSphere(transform.position, rangeRadius);
    foreach (Collider collider in colliders)
    {
        // Turrets:
        if (collider.CompareTag("Turrets"))
        {
            InitiateBuffForTurrets(collider.transform); // For Regulars
        }
        else if (collider.CompareTag(defUnit_AS_Tag))
        {
            InitiateBuffForTurrets(collider.transform); // For Anti-Shield
        }
        else if (collider.CompareTag(defUnit_Laser_Tag))
        {
            InitiateBuffForTurretLaserBeamer(collider.transform); // For Laser-Beamer
        }

        // Bullets:
        if (collider.tag == defBullet_Tag)
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
        }


    }
}*/

#endregion
