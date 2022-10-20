using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ShopSystem
{
    public class Stats_NormalTurrets : MonoBehaviour
    {

        [SerializeField] ShopItemsScriptable shopItemSO;

        D_Unit_Turret normalTurret;

        void Start()
        {
            normalTurret = GetComponent<D_Unit_Turret>();
        }

        // Update is called once per frame
        void Update()
        {
            StatsCheckerAndSetter();
        }


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

