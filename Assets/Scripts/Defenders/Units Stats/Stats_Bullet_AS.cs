using UnityEngine;

namespace ShopSystem
{
    public class Stats_Bullet_AS : MonoBehaviour
    {
        [SerializeField] ShopItemsScriptable shopItemSO;

        Bullet bullet;

        void Start()
        {
            bullet = GetComponent<Bullet>();
        }

        void Update()
        {
            StatsCheckerAndSetter();
        }

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

