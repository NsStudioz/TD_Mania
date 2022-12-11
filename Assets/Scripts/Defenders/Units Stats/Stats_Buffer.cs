using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ShopSystem
{
    public class Stats_Buffer : MonoBehaviour
    {

        [SerializeField] ShopItemsScriptable shopItemSO;
        [SerializeField] Units_Data_Handler unitLevelHandler;

        D_Unit_Buffer turretBuffer;

        void Start()
        {
            turretBuffer = GetComponent<D_Unit_Buffer>();
        }

        void Update()
        {
            //StatsCheckerAndSetter();
            StatsCheckerAndSetter_Final();
        }

        // Final Product Stats Check:
        private void StatsCheckerAndSetter_Final()
        {   // INITIALIZER:
            int thisItem_LevelIndex = unitLevelHandler.GetUnitLevel();
            // Radius + Quad Sync:
            turretBuffer.LOS.transform.localScale = shopItemSO.unit_Level[thisItem_LevelIndex].quad_Scale;
            turretBuffer.rangeRadius = shopItemSO.unit_Level[thisItem_LevelIndex].radius;
        }

        // Editor Product Stats Check:
        private void StatsCheckerAndSetter()
        {   // INITIALIZER:
            int thisItem_LevelIndex = shopItemSO.Item_LevelIndex;
            // Radius + Quad Sync:
            turretBuffer.LOS.transform.localScale = shopItemSO.unit_Level[thisItem_LevelIndex].quad_Scale;
            turretBuffer.rangeRadius = shopItemSO.unit_Level[thisItem_LevelIndex].radius;
        }
    }

}
