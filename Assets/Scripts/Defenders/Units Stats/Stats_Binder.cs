using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace ShopSystem
{
    public class Stats_Binder : MonoBehaviour
    {

        [SerializeField] ShopItemsScriptable shopItemSO;
        [SerializeField] Units_Data_Handler unitLevelHandler;

        D_Trap_Binder binder;

        void Start()
        {
            binder = GetComponent<D_Trap_Binder>();
        }


        void Update()
        {
            //StatsCheckerAndSetter();
            StatsCheckerAndSetter_Final();
        }

        // Final Product Stats Check:
        private void StatsCheckerAndSetter_Final()
        {
            int itemLevelIndex = shopItemSO.Item_LevelIndex;

            binder.triggerRadius = shopItemSO.unit_Level[itemLevelIndex].triggerRadius;
            binder.bindRadius = shopItemSO.unit_Level[itemLevelIndex].bindRadius;
            binder.bindingDuration = shopItemSO.unit_Level[itemLevelIndex].bindDuration;
            //
            binder.TGR_Quad.transform.localScale = shopItemSO.unit_Level[itemLevelIndex].triggerQuad_Scale;
            binder.Bind_Quad.transform.localScale = shopItemSO.unit_Level[itemLevelIndex].explosionQuad_Scale;
        }

        // Editor Product Stats Check:
        private void StatsCheckerAndSetter()
        {
            int itemLevelIndex = unitLevelHandler.GetUnitLevel();

            binder.triggerRadius = shopItemSO.unit_Level[itemLevelIndex].triggerRadius;
            binder.bindRadius = shopItemSO.unit_Level[itemLevelIndex].bindRadius;
            binder.bindingDuration = shopItemSO.unit_Level[itemLevelIndex].bindDuration;
            //
            binder.TGR_Quad.transform.localScale = shopItemSO.unit_Level[itemLevelIndex].triggerQuad_Scale;
            binder.Bind_Quad.transform.localScale = shopItemSO.unit_Level[itemLevelIndex].explosionQuad_Scale;
        }
    }
}

