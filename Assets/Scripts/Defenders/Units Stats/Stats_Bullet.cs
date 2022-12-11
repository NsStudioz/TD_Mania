using UnityEngine;

namespace ShopSystem
{
    public class Stats_Bullet : MonoBehaviour
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

            bullet.damage = shopItemSO.unit_Level[itemLevelIndex].bullet_damage;
            bullet.speed = shopItemSO.unit_Level[itemLevelIndex].bullet_speed;
        }

        // Editor Product Stats Check:
        private void StatsCheckerAndSetter()
        {
            int itemLevelIndex = shopItemSO.Item_LevelIndex;

            bullet.damage = shopItemSO.unit_Level[itemLevelIndex].bullet_damage;
            bullet.speed = shopItemSO.unit_Level[itemLevelIndex].bullet_speed;
        }
    }
}

