using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace ShopSystem
{
    public class Stats_AntiMine : MonoBehaviour
    {

        [SerializeField] ShopItemsScriptable shopItemSO;

        D_Trap_AntiShield antiMine;

        void Start()
        {
            antiMine = GetComponent<D_Trap_AntiShield>();
        }

        void Update()
        {
            StatsCheckerAndSetter();
        }

        public void StatsCheckerAndSetter()
        {
            int itemLevelIndex = shopItemSO.Item_LevelIndex;

            antiMine.triggerRadius = shopItemSO.unit_Level[itemLevelIndex].triggerRadius;
            antiMine.explosionRadius = shopItemSO.unit_Level[itemLevelIndex].explosionRadius;
            antiMine.explosionDamage = shopItemSO.unit_Level[itemLevelIndex].damage_AS;
            //
            antiMine.TGR_Quad.transform.localScale = shopItemSO.unit_Level[itemLevelIndex].triggerQuad_Scale;
            antiMine.EXP_Quad.transform.localScale = shopItemSO.unit_Level[itemLevelIndex].explosionQuad_Scale;
        }
    }
}

