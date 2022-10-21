using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ShopSystem
{
    public class Stats_GoldGenerator : MonoBehaviour
    {

        [SerializeField] ShopItemsScriptable shopItemSO;

        D_Trap_GoldGenerator goldGenerator;

        void Start()
        {
            goldGenerator = GetComponent<D_Trap_GoldGenerator>();
        }


        void Update()
        {
            StatsCheckerAndSetter();
        }

        public void StatsCheckerAndSetter()
        {
            int itemLevelIndex = shopItemSO.Item_LevelIndex;

            goldGenerator.goldToEarn = shopItemSO.unit_Level[itemLevelIndex].goldToEarn;
            goldGenerator.gold_DelayTime = shopItemSO.unit_Level[itemLevelIndex].gold_DelayTime;
        }
    }
}

