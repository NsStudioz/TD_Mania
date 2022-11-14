using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace ShopSystem
{
    [CreateAssetMenu(fileName = "ShopData", menuName = "Scriptable/Create ShopData")]
    [System.Serializable]
    public class ShopItemsScriptable : ScriptableObject
    {
        public string itemName;
        public int Item_LevelIndex;
        public UnitItemInfo[] unit_Level;
    }

/*    [System.Serializable]
    public class ShopItems
    {
        public string itemName;
        public int Item_LevelIndex;
        public UnitItemInfo[] unit_Level;
    }*/
    //
    //---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    // ITEM CATEGORIES:

    [System.Serializable]
    public class UnitItemInfo
    {
        public int unlockCost;
        public int unit_LevelIndex;

        [Header("Turrets Section")]
        public float radius;
        public float quad_Scale_X;
        public float quad_Scale_Y;
        public Vector3 quad_Scale;
        public float turnSpeed;
        public float FireRate;
        public float damageOverTime;
        public float slowingPercentage;

        [Header("Trap Section")]
        public float triggerRadius;
        public float triggerQuad_X;
        public float triggerQuad_Y;
        public Vector3 triggerQuad_Scale;
        public float explosionRadius;
        public float explosionQuad_X;
        public float explosionQuad_Y;
        public Vector3 explosionQuad_Scale;
        public float bindRadius;
        public float bindDuration;
        //
        public float damage;
        public float damage_AS; // anti-shield damage.
        //
        public int goldToEarn;
        public float gold_DelayTime;

        [Header("Arsenal Section")]
        public float bullet_speed;
        public float bullet_damage;
        public float bullet_ShieldDamage;
    }
}



