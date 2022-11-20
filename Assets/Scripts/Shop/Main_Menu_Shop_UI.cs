using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

namespace ShopSystem
{
    public class Main_Menu_Shop_UI : MonoBehaviour
    {
        public ShopItemsScriptable[] shopItemsData;
        public Item_Template[] shopItemsTemplates;

        private int resetItem_LevelIndex = 0;

        public static event Action OnClick_UI_Upgrade_SFX;
        public static event Action OnClick_UI_GoldSpent_SFX;

        private void Start()
        {
            SyncItems_Startup();
        }

        private void Update()
        {
            SyncItems_UpgradeLevels();
        }

        private void SyncItems_Startup()
        {
            for (int i = 0; i < shopItemsData.Length; i++)
            {
                shopItemsTemplates[i].titleText.text = shopItemsData[i].itemName;

                int item_LevelIndex = shopItemsData[i].Item_LevelIndex;
                if (item_LevelIndex == resetItem_LevelIndex)
                {
                    shopItemsTemplates[i].costText.text = shopItemsData[i].unit_Level[item_LevelIndex].unlockCost.ToString();
                }
            }
        }

        private void SyncItems_UpgradeLevels()
        {
            for (int i = 0; i < shopItemsData.Length; i++)
            {
                int item_LevelIndex = shopItemsData[i].Item_LevelIndex + 1;
                if (item_LevelIndex < shopItemsData[i].unit_Level.Length)
                {
                    shopItemsTemplates[i].costTextGO.SetActive(true);
                    shopItemsTemplates[i].UpgradeText.text = $"Upgrade";
                    shopItemsTemplates[i].costText.text = shopItemsData[i].unit_Level[item_LevelIndex].unlockCost.ToString();
                }
                else
                {
                    shopItemsTemplates[i].costTextGO.SetActive(false);
                    shopItemsTemplates[i].UpgradeText.text = $"Maxed";
                    shopItemsTemplates[i].upgradeButton.interactable = false;
                }
            }
        }

        public void OnItemUpgradeClick(int thisItemIndex)
        {
            int item_LevelIndex = shopItemsData[thisItemIndex].Item_LevelIndex;

            if (PlayerPrefs.GetInt("TotalGoldCount") >= shopItemsData[thisItemIndex].unit_Level[item_LevelIndex + 1].unlockCost)
            {
                PlayerPrefs.SetInt("TotalGoldCount", PlayerStats._TotalGold - shopItemsData[thisItemIndex].unit_Level[item_LevelIndex + 1].unlockCost);

                if (item_LevelIndex < shopItemsData[thisItemIndex].unit_Level.Length)
                {
                    shopItemsData[thisItemIndex].Item_LevelIndex++;
                    shopItemsTemplates[thisItemIndex].costText.text = shopItemsData[thisItemIndex].unit_Level[item_LevelIndex].unlockCost.ToString();
                }

                if (item_LevelIndex == shopItemsData[thisItemIndex].unit_Level.Length)
                {
                    shopItemsData[thisItemIndex].Item_LevelIndex++;
                    //
                    shopItemsTemplates[thisItemIndex].costTextGO.SetActive(false);
                    //
                    shopItemsTemplates[thisItemIndex].UpgradeText.text = $"Maxed";
                    shopItemsTemplates[thisItemIndex].upgradeButton.interactable = false;
                }

                PlayCategorySFX();
                Play_GoldSpent_SFX();
            }
        }

        private void PlayCategorySFX()
        {
            OnClick_UI_Upgrade_SFX?.Invoke();
        }

        private void Play_GoldSpent_SFX()
        {
            OnClick_UI_GoldSpent_SFX?.Invoke();
        }

        private void ResetUpgradesBackToZero()
        {
            for (int i = 0; i < shopItemsData.Length; i++)
            {
                shopItemsData[i].Item_LevelIndex = resetItem_LevelIndex;
                shopItemsTemplates[i].costTextGO.SetActive(true);
                shopItemsTemplates[i].UpgradeText.text = $"Upgrade";
            }
        }
    }
}


#region Trash Code
/*        public List<TMP_Text> itemsList_CostText = new List<TMP_Text>();
        public List<TMP_Text> itemsList_LevelText = new List<TMP_Text>();
        public List<Button> itemsList_UpgradeButton = new List<Button>();

        [SerializeField] int theseListsItemsIndex;
        [SerializeField] int selectedItemIndex;
        [SerializeField] int shopItemINdex;
        [SerializeField] int totalItemsIndex = 0;*/

/*    public Button item1;

    private void Start()
    {
        item1.interactable = !item1.interactable;
        item1.interactable = false;
        item1.interactable = true;
        
    }*/

/*            foreach (TMP_Text indexedText in itemsList_CostText)
            {
                itemsList_CostText[totalItemsIndex].text = shopItemsData[totalItemsIndex]
            }*/

/*            foreach (TMP_Text tmp_text in itemsList_CostText)
            {
                itemsList_CostText[totalItemsIndex].text = shopItemsData.shopItems[totalItemsIndex].unit_Level[1].unlockCost.ToString();
                totalItemsIndex++;
                if (totalItemsIndex == 20) 
                {
                    totalItemsIndex = 0;
                    break; 
                }
            }*/

/*
            for (int i = 0; i < itemsList_CostText.Count; i++)
            {
                itemsList_CostText[i].text = shopItemsData.shopItems[i].unit_Level[1].unlockCost.ToString();
            }*/

/*            shopItemINdex = shopItemsData.shopItems[shopItemINdex].shopItemIndex;
            selectedItemIndex = shopItemINdex;
*/

/*            switch (itemLevelIndex)
            {
                case 1:
                    itemLevelIndex++;
                    shopItemsTemplates[thisItemIndex].unitLevel = shopItemsData[thisItemIndex].unit_Level[itemLevelIndex + 1].unit_LevelIndex;
                    shopItemsTemplates[thisItemIndex].costText.text = shopItemsData[thisItemIndex].unit_Level[itemLevelIndex + 1].unlockCost.ToString();
                    break;
                case 2:
                    itemLevelIndex++;
                    shopItemsTemplates[thisItemIndex].unitLevel = shopItemsData[thisItemIndex].unit_Level[itemLevelIndex + 1].unit_LevelIndex;
                    shopItemsTemplates[thisItemIndex].costText.text = shopItemsData[thisItemIndex].unit_Level[itemLevelIndex + 1].unlockCost.ToString();
                    break;
                case 3:
                    itemLevelIndex++;
                    shopItemsTemplates[thisItemIndex].unitLevel = shopItemsData[thisItemIndex].unit_Level[itemLevelIndex + 1].unit_LevelIndex;
                    shopItemsTemplates[thisItemIndex].costText.text = shopItemsData[thisItemIndex].unit_Level[itemLevelIndex + 1].unlockCost.ToString();
                    break;
                case 4:
                    itemLevelIndex++;
                    shopItemsTemplates[thisItemIndex].unitLevel = shopItemsData[thisItemIndex].unit_Level[itemLevelIndex + 1].unit_LevelIndex;
                    shopItemsTemplates[thisItemIndex].costText.text = shopItemsData[thisItemIndex].unit_Level[itemLevelIndex + 1].unlockCost.ToString();
                    break;
                default:
                    break;
            }*/

/*        public void SwitchUpgrade()
        {
            switch (shopItemsUpgradeButtons)
            {
                case 0:

            }
        }*/



/*                    for (int i = 0; i<shopItemsUpgradeButtons.Length; i++)
    {
        //int unitLevelIndex = 0;
        //shopItemsTemplates[i].unitLevel = shopItemsData[i].Item_LevelIndex;
        //shopItemsTemplates[i].costText.text = shopItemsData[i].unit_Level[0].unlockCost.ToString();

        int nextLevelIndex = shopItemsData[i].Item_LevelIndex + 1;
shopItemsTemplates[i].unitLevel = shopItemsData[i].unit_Level[nextLevelIndex].unit_LevelIndex;
        shopItemsTemplates[i].costText.text = shopItemsData[i].unit_Level[nextLevelIndex].unlockCost.ToString();
        if(nextLevelIndex == nextLevelIndex + 1)
        {
            break;
        }

    }*/

/*        public void ForEachUpgrade(int thisItemIndex)
        {
            int itemLevelIndex = shopItemsData[thisItemIndex].Item_LevelIndex;
            if (itemLevelIndex < 4)
            {
                //int nextLevelIndex = shopItemsData[thisItemIndex].Item_LevelIndex + 1;

                shopItemsTemplates[thisItemIndex].unitLevel = shopItemsData[thisItemIndex].unit_Level[itemLevelIndex + 1].unit_LevelIndex;
                shopItemsTemplates[thisItemIndex].costText.text = shopItemsData[thisItemIndex].unit_Level[itemLevelIndex + 1].unlockCost.ToString();
            }

        }*/
#endregion

/*audioManager.PlayOneShot("UI_ClickUpgrade");*/
/*        AudioManager audioManager;

        private void Awake()
        {
            GameObject forAudioManager = GameObject.Find("Audio_Manager");
            audioManager = forAudioManager.GetComponent<AudioManager>();
        }*/
//public int[] unit_LevelIndex;
//public Button[] shopItemsUpgradeButtons;