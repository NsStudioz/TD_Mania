using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ShopSystem
{
    public class Stats_NormalTurrets : MonoBehaviour
    {

        [SerializeField] ShopItemsScriptable shopItemSO;
        [SerializeField] Units_Data_Handler unitLevelHandler;

        D_Unit_Turret normalTurret;

        void Start()
        {
            normalTurret = GetComponent<D_Unit_Turret>();
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

            // Attributes Sync
            normalTurret.turnSpeed = shopItemSO.unit_Level[thisItem_LevelIndex].turnSpeed;
            normalTurret.fireRate = shopItemSO.unit_Level[thisItem_LevelIndex].FireRate;

            // Radius + Quad Sync:
            normalTurret.LOS.transform.localScale = shopItemSO.unit_Level[thisItem_LevelIndex].quad_Scale;
            normalTurret.range = shopItemSO.unit_Level[thisItem_LevelIndex].radius;
        }

        // Editor Product Stats Check:
        private void StatsCheckerAndSetter()
        {   // INITIALIZER:
            int thisItem_LevelIndex = shopItemSO.Item_LevelIndex;
            // Attributes Sync
            normalTurret.turnSpeed = shopItemSO.unit_Level[thisItem_LevelIndex].turnSpeed;
            normalTurret.fireRate = shopItemSO.unit_Level[thisItem_LevelIndex].FireRate;

            // Radius + Quad Sync:
            normalTurret.LOS.transform.localScale = shopItemSO.unit_Level[thisItem_LevelIndex].quad_Scale;
            normalTurret.range = shopItemSO.unit_Level[thisItem_LevelIndex].radius;
        }

    }
}

