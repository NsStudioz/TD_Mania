using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ShopSystem
{
    public class Stats_Mine : MonoBehaviour
    {
        [SerializeField] ShopItemsScriptable shopItemSO;

        D_Trap_Mine mine;

        void Start()
        {
            mine = GetComponent<D_Trap_Mine>();
        }


        void Update()
        {
            StatsCheckerAndSetter();
        }

        public void StatsCheckerAndSetter()
        {
            int itemLevelIndex = shopItemSO.Item_LevelIndex;

            mine.triggerRadius = shopItemSO.unit_Level[itemLevelIndex].triggerRadius;
            mine.explosionRadius = shopItemSO.unit_Level[itemLevelIndex].explosionRadius;
            mine.explosionDamage = shopItemSO.unit_Level[itemLevelIndex].damage;
            //
            mine.TGR_Quad.transform.localScale = shopItemSO.unit_Level[itemLevelIndex].triggerQuad_Scale;
            mine.EXP_Quad.transform.localScale = shopItemSO.unit_Level[itemLevelIndex].explosionQuad_Scale;
        }
    }
}

