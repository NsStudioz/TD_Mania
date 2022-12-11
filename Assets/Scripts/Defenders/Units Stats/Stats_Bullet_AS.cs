using UnityEngine;

namespace ShopSystem
{
    public class Stats_Bullet_AS : MonoBehaviour
    {
        [SerializeField] ShopItemsScriptable shopItemSO;
        [SerializeField] Units_Data_Handler unitLevelHandler;

        Bullet bullet;

        void Start()
        {
            bullet = GetComponent<Bullet>();
        }

        void Update()
        {
            //StatsCheckerAndSetter();
            StatsCheckerAndSetter_Final();
        }

        // Final Product Stats Check:
        private void StatsCheckerAndSetter_Final()
        {
            int itemLevelIndex = unitLevelHandler.GetUnitLevel();

            bullet.speed = shopItemSO.unit_Level[itemLevelIndex].bullet_speed;
            //
            bullet.turret_AS_Damage = shopItemSO.unit_Level[itemLevelIndex].bullet_ShieldDamage;
            bullet.autoTurret_AS_Damage = shopItemSO.unit_Level[itemLevelIndex].bullet_ShieldDamage;
            bullet.shieldDestroyer_AS_Damage = shopItemSO.unit_Level[itemLevelIndex].bullet_ShieldDamage;
        }

        // Editor Product Stats Check:
        private void StatsCheckerAndSetter()
        {
            int itemLevelIndex = shopItemSO.Item_LevelIndex;

            bullet.speed = shopItemSO.unit_Level[itemLevelIndex].bullet_speed;
            //
            bullet.turret_AS_Damage = shopItemSO.unit_Level[itemLevelIndex].bullet_ShieldDamage;
            bullet.autoTurret_AS_Damage = shopItemSO.unit_Level[itemLevelIndex].bullet_ShieldDamage;
            bullet.shieldDestroyer_AS_Damage = shopItemSO.unit_Level[itemLevelIndex].bullet_ShieldDamage;
        }
    }
}

