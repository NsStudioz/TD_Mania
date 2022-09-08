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
    [SerializeField] string defBullet_AS_Tag = "Bullet_AS";

    // Bonuses:
    [SerializeField] float turretRangeBonus = 0.5f;
    [SerializeField] float bulletDamageBonus = 25f;
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
        {
            if (collider.tag == defUnit_Tag)
            {
                InitiateBuffForTurrets(collider.transform);
            }
            else if (collider.tag == defBullet_Tag)
            {
                bullet.isBuffedByBuffer = true;
                InitiateBuffForBullets(collider.transform);
            }

        }
    }

    #region TurretBuffs:
    private void InitiateBuffForTurrets(Transform turret)
    {
        D_Unit_Turret defUnit = GetComponent<D_Unit_Turret>();

        if(defUnit != null)
        {
            defUnit.BuffDefendingUnit(turretRangeBonus);
        }
    }


    #endregion

    #region ArsenalBuffs:
    private void InitiateBuffForBullets(Transform thisBullet)
    {
        Bullet defbullet = GetComponent<Bullet>();
        
        if (bullet != null)
        {
            defbullet.buffBullet(bulletDamageBonus);
        }
    }

    #endregion

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, rangeRadius);
    }

}
