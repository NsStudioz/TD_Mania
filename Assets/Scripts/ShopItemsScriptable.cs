using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace ShopSystem
{
    [CreateAssetMenu(fileName = "ShopData", menuName = "Scriptable/Create ShopData")]
    public class ShopItemsScriptable : ScriptableObject
    {
        public ShopItem[] shopItems;
    }

    [System.Serializable]
    public class ShopItem
    {
        public string itemName;
        public bool isUnlocked;
        public int unlockCost;
        public int unlockedLevel;
        public TurretItemInfo[] turret_Level;
        public BulletItemInfo[] bullet_Level;
        public TrapItemInfo[]   trap_Level;
    }

    [System.Serializable]
    public class TurretItemInfo
    {
        public int unlockCost;
        public float radius;
        public float turnSpeed;
        public float FireRate;
        public float damageOverTime;
        public float slowingPercentage;
    }

    [System.Serializable]
    public class BulletItemInfo
    {
        public int unlockCost;
        public float bullet_speed;
        public float bullet_damage;
        public float bullet_ShieldDamage;
    }

    [System.Serializable]
    public class TrapItemInfo 
    {
        public int unlockCost;
        //
        public float triggerRadius;
        public float explosionRadius;
        public float bindRadius;
        public float bindDuration;
        //
        public float damage;
        public float damage_AS; // anti-shield damage.
        //
        public int goldToEarn;
        public float gold_DelayTime;

    }

}

/*    public class TurretLaserItemInfo
    {
        public int unlockCost;
        public float range;
        public float turnSpeed;
    }*/

