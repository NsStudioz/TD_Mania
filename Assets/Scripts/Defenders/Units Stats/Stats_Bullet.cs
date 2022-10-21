using UnityEngine;

namespace ShopSystem
{
    public class Stats_Bullet : MonoBehaviour
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

            bullet.damage = shopItemSO.unit_Level[itemLevelIndex].bullet_damage;
            bullet.speed = shopItemSO.unit_Level[itemLevelIndex].bullet_speed;
        }
    }
}

