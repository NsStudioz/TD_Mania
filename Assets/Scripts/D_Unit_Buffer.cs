using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class D_Unit_Buffer : MonoBehaviour
{

    [Header("Attributes")]
    [SerializeField] string defendingUnitTag = "Defenders";
    [SerializeField] float rangeRadius = 1f;
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
            if (collider.tag == defendingUnitTag)
            {
                InitiateBuffForTurrets(collider.transform);
            }
            else if (collider.tag == "Bullet")
            {
                bullet.isBuffedByBuffer = true;
                InitiateBuffForBullets(collider.transform);
            }

        }
    }

    #region Turret&TrapBuffs:
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
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position, rangeRadius);
    }

}
