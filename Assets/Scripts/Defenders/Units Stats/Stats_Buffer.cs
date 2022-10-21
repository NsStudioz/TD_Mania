using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ShopSystem
{
    public class Stats_Buffer : MonoBehaviour
    {

        [SerializeField] ShopItemsScriptable shopItemSO;

        D_Unit_Buffer turretBuffer;

        // Start is called before the first frame update
        void Start()
        {
            turretBuffer = GetComponent<D_Unit_Buffer>();
        }

        // Update is called once per frame
        void Update()
        {
            StatsCheckerAndSetter();
        }

        private void StatsCheckerAndSetter()
        {   // INITIALIZER:
            int thisItem_LevelIndex = shopItemSO.Item_LevelIndex;
            // Radius + Quad Sync:
            turretBuffer.LOS.transform.localScale = shopItemSO.unit_Level[thisItem_LevelIndex].quad_Scale;
            turretBuffer.rangeRadius = shopItemSO.unit_Level[thisItem_LevelIndex].radius;
        }
    }

}
