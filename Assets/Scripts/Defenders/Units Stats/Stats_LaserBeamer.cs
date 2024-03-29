using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace ShopSystem
{
    public class Stats_LaserBeamer : MonoBehaviour
    {
        
        [SerializeField] ShopItemsScriptable shopItemSO;
        [SerializeField] Units_Data_Handler unitLevelHandler;

        D_Unit_Turret_LaserBeamer laserBeamer;

        private void Start()
        {
            laserBeamer = GetComponent<D_Unit_Turret_LaserBeamer>();
        }

        private void Update()
        {
            //StatsCheckerAndSetter();
            StatsCheckerAndSetter_Final();
        }

        // Final Product Stats Check:
        private void StatsCheckerAndSetter_Final()
        {   // INITIALIZER:
            int thisItem_LevelIndex = unitLevelHandler.GetUnitLevel();
            // Attributes Sync
            laserBeamer.turnSpeed = shopItemSO.unit_Level[thisItem_LevelIndex].turnSpeed;
            laserBeamer.damageOverTime = shopItemSO.unit_Level[thisItem_LevelIndex].damageOverTime;
            laserBeamer.laserHitSlowPct = shopItemSO.unit_Level[thisItem_LevelIndex].slowingPercentage;

            // Radius + Quad Sync:
            laserBeamer.LOS.transform.localScale = shopItemSO.unit_Level[thisItem_LevelIndex].quad_Scale;
            laserBeamer.range = shopItemSO.unit_Level[thisItem_LevelIndex].radius;
        }

        // Editor Product Stats Check:
        private void StatsCheckerAndSetter()
        {   // INITIALIZER:
            int thisItem_LevelIndex = shopItemSO.Item_LevelIndex;
            // Attributes Sync
            laserBeamer.turnSpeed = shopItemSO.unit_Level[thisItem_LevelIndex].turnSpeed;
            laserBeamer.damageOverTime = shopItemSO.unit_Level[thisItem_LevelIndex].damageOverTime;
            laserBeamer.laserHitSlowPct = shopItemSO.unit_Level[thisItem_LevelIndex].slowingPercentage;

            // Radius + Quad Sync:
            laserBeamer.LOS.transform.localScale = shopItemSO.unit_Level[thisItem_LevelIndex].quad_Scale;
            laserBeamer.range = shopItemSO.unit_Level[thisItem_LevelIndex].radius;
        }


    }
}
// OLD:
/*        private void StatsCheckerAndSetter_OLD()
        {
            // INITIALIZER:
            int thisItem_LevelIndex = shopItemsData[laserBeamer_ShopIndexIdentifier].Item_LevelIndex;
            // Attributes Sync
            laserBeamer.turnSpeed = shopItemsData[laserBeamer_ShopIndexIdentifier].unit_Level[thisItem_LevelIndex].turnSpeed;
            laserBeamer.damageOverTime = shopItemsData[laserBeamer_ShopIndexIdentifier].unit_Level[thisItem_LevelIndex].damageOverTime;
            laserBeamer.laserHitSlowPct = shopItemsData[laserBeamer_ShopIndexIdentifier].unit_Level[thisItem_LevelIndex].slowingPercentage;

            // Radius + Quad Sync:
            laserBeamer.LOS.transform.localScale = shopItemsData[laserBeamer_ShopIndexIdentifier].unit_Level[thisItem_LevelIndex].quad_Scale;
            laserBeamer.range = shopItemsData[laserBeamer_ShopIndexIdentifier].unit_Level[thisItem_LevelIndex].radius;
        }
*/
