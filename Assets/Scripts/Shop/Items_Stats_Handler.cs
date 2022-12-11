using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace ShopSystem
{
    public class Items_Stats_Handler : MonoBehaviour
    {

        [Header("Item Lists")]
        [SerializeField] ShopItemsScriptable[] shopItems;

        [SerializeField] Main_Menu_Shop_UI menuShop_UI;

        [Header("TEXT-OBJECTS")]
        [SerializeField] TMP_Text titleText;
        [SerializeField] TMP_Text attributeText_1; // Turrets => radius;  Traps => Trigger Radius
        [SerializeField] TMP_Text attributeText_2;
        [SerializeField] TMP_Text attributeText_3;
        [SerializeField] TMP_Text attributeText_4;
        //
        int selected_ItemIndex;

        [Header("Special turret indexes")]
        // TURRETS:
        int laserBeamer_Index = 3;
        int turretBuffer_Index = 8;
        //TRAPS:
        int binder_index = 10;
        int goldGenerator_index = 11;
        int antiMine_index = 12;

        void Start()
        {
                titleText.text = "";
                attributeText_1.text = "";
                attributeText_2.text = "";
                attributeText_3.text = "";
                attributeText_4.text = "";
        }

        void Update()
        {
            //Sync_ItemsStats();
            Sync_ItemsStats_Final();
        }

        public void OnBtnClick_ShowItemStats(int itemIndex)
        {
            selected_ItemIndex = itemIndex;
        }

        #region Sync_Unit_Stats (Final Product):
        private void Sync_ItemsStats_Final()
        {
            int thisItemIndex = menuShop_UI.unitsLevelHandler[selected_ItemIndex].GetUnitLevel();

            titleText.text = shopItems[selected_ItemIndex].itemName;
            // TURRETS:
            if (selected_ItemIndex <= 8)
            {
                attributeText_1.text = "Radius => " + shopItems[selected_ItemIndex].unit_Level[thisItemIndex].radius;
                attributeText_2.text = "Turn Speed => " + shopItems[selected_ItemIndex].unit_Level[thisItemIndex].turnSpeed;
                attributeText_3.text = "Fire Rate => " + shopItems[selected_ItemIndex].unit_Level[thisItemIndex].FireRate;
                attributeText_4.text = "";

                if (selected_ItemIndex == laserBeamer_Index)
                {
                    attributeText_3.text = "Slowing % => " + shopItems[laserBeamer_Index].unit_Level[thisItemIndex].slowingPercentage;
                    attributeText_4.text = "Damage/s => " + shopItems[laserBeamer_Index].unit_Level[thisItemIndex].damageOverTime;
                }
                else if (selected_ItemIndex == turretBuffer_Index)
                {
                    attributeText_1.text = "Radius => " + shopItems[turretBuffer_Index].unit_Level[thisItemIndex].radius.ToString();
                    attributeText_2.text = "";
                    attributeText_3.text = "";
                    attributeText_3.text = "";
                }
            }
            // TRAPS:
            else if (selected_ItemIndex > 8 && selected_ItemIndex <= 12)
            {
                attributeText_1.text = "TGR Radius => " + shopItems[selected_ItemIndex].unit_Level[thisItemIndex].triggerRadius;
                attributeText_2.text = "EXP Radius => " + shopItems[selected_ItemIndex].unit_Level[thisItemIndex].explosionRadius;
                attributeText_3.text = "Damage => " + shopItems[selected_ItemIndex].unit_Level[thisItemIndex].damage;
                attributeText_4.text = "";

                if (selected_ItemIndex == binder_index)
                {
                    attributeText_1.text = "TGR Radius => " + shopItems[binder_index].unit_Level[thisItemIndex].triggerRadius;
                    attributeText_2.text = "Bind Radius => " + shopItems[binder_index].unit_Level[thisItemIndex].bindRadius;
                    attributeText_3.text = "Bind Duration/Sec => " + shopItems[binder_index].unit_Level[thisItemIndex].bindDuration;
                }
                else if (selected_ItemIndex == goldGenerator_index)
                {
                    attributeText_1.text = "Gold => " + shopItems[goldGenerator_index].unit_Level[thisItemIndex].goldToEarn;
                    attributeText_2.text = "Cycle Time => " + shopItems[goldGenerator_index].unit_Level[thisItemIndex].gold_DelayTime;
                    attributeText_3.text = "";
                }
                else if (selected_ItemIndex == antiMine_index)
                {
                    attributeText_3.text = "Damage => " + shopItems[antiMine_index].unit_Level[thisItemIndex].damage_AS;
                }
            }
            // ARSENAL:
            else if (selected_ItemIndex > 12 && selected_ItemIndex <= 16)
            {
                attributeText_1.text = "Bullet Speed => " + shopItems[selected_ItemIndex].unit_Level[thisItemIndex].bullet_speed;
                attributeText_2.text = "Damage => " + shopItems[selected_ItemIndex].unit_Level[thisItemIndex].bullet_damage;
                attributeText_3.text = "";
                attributeText_4.text = "";
            }
            else if (selected_ItemIndex > 16 && selected_ItemIndex <= 19)
            {
                attributeText_1.text = "Bullet Speed => " + shopItems[selected_ItemIndex].unit_Level[thisItemIndex].bullet_speed;
                attributeText_2.text = "Anti-Damage => " + shopItems[selected_ItemIndex].unit_Level[thisItemIndex].bullet_ShieldDamage;
                attributeText_3.text = "";
                attributeText_4.text = "";
            }
    }

#endregion

        #region Sync_Unit_Stats_Editor:
        private void Sync_ItemsStats()
        {
            int thisItemIndex = shopItems[selected_ItemIndex].Item_LevelIndex;

            titleText.text = shopItems[selected_ItemIndex].itemName;
            // TURRETS:
            if(selected_ItemIndex <= 8)
            {
                attributeText_1.text = "Radius => " + shopItems[selected_ItemIndex].unit_Level[thisItemIndex].radius;
                attributeText_2.text = "Turn Speed => " + shopItems[selected_ItemIndex].unit_Level[thisItemIndex].turnSpeed;
                attributeText_3.text = "Fire Rate => " + shopItems[selected_ItemIndex].unit_Level[thisItemIndex].FireRate;
                attributeText_4.text = "";

                if (selected_ItemIndex == laserBeamer_Index)
                {
                    attributeText_3.text = "Slowing % => " + shopItems[laserBeamer_Index].unit_Level[thisItemIndex].slowingPercentage;
                    attributeText_4.text = "Damage/s => " + shopItems[laserBeamer_Index].unit_Level[thisItemIndex].damageOverTime;
                }
                else if (selected_ItemIndex == turretBuffer_Index)
                {
                    attributeText_1.text = "Radius => " + shopItems[laserBeamer_Index].unit_Level[thisItemIndex].radius.ToString();
                    attributeText_2.text = "";
                    attributeText_3.text = "";
                    attributeText_3.text = "";
                }
            }
            // TRAPS:
            else if(selected_ItemIndex > 8 && selected_ItemIndex <= 12)
            {
                attributeText_1.text = "TGR Radius => " + shopItems[selected_ItemIndex].unit_Level[thisItemIndex].triggerRadius;
                attributeText_2.text = "EXP Radius => " + shopItems[selected_ItemIndex].unit_Level[thisItemIndex].explosionRadius;
                attributeText_3.text = "Damage => " + shopItems[selected_ItemIndex].unit_Level[thisItemIndex].damage;
                attributeText_4.text = "";

                if (selected_ItemIndex == binder_index)
                {
                    attributeText_1.text = "TGR Radius => " + shopItems[binder_index].unit_Level[thisItemIndex].triggerRadius;
                    attributeText_2.text = "Bind Radius => " + shopItems[binder_index].unit_Level[thisItemIndex].bindRadius;
                    attributeText_3.text = "Bind Duration/Sec => " + shopItems[binder_index].unit_Level[thisItemIndex].bindDuration;
                }
                else if (selected_ItemIndex == goldGenerator_index)
                {
                    attributeText_1.text = "Gold => " + shopItems[goldGenerator_index].unit_Level[thisItemIndex].goldToEarn;
                    attributeText_2.text = "Cycle Time => " + shopItems[goldGenerator_index].unit_Level[thisItemIndex].gold_DelayTime;
                    attributeText_3.text = "";
                }
                else if (selected_ItemIndex == antiMine_index)
                {
                    attributeText_3.text = "Damage => " + shopItems[antiMine_index].unit_Level[thisItemIndex].damage_AS;
                }
            }
            // ARSENAL:
            else if (selected_ItemIndex > 12 && selected_ItemIndex <= 16)
            {
                attributeText_1.text = "Bullet Speed => " + shopItems[selected_ItemIndex].unit_Level[thisItemIndex].bullet_speed;
                attributeText_2.text = "Damage => " + shopItems[selected_ItemIndex].unit_Level[thisItemIndex].bullet_damage;
                attributeText_3.text = "";
                attributeText_4.text = "";
            }
            else if (selected_ItemIndex > 16 && selected_ItemIndex <= 19)
            {
                attributeText_1.text = "Bullet Speed => " + shopItems[selected_ItemIndex].unit_Level[thisItemIndex].bullet_speed;
                attributeText_2.text = "Anti-Damage => " + shopItems[selected_ItemIndex].unit_Level[thisItemIndex].bullet_ShieldDamage;
                attributeText_3.text = "";
                attributeText_4.text = "";
            }
        }

        #endregion
    }
}

