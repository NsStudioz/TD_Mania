using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace ShopSystem
{
    public class Main_Menu_Shop_UI : MonoBehaviour
    {

        public ShopItemsScriptable[] shopItemsData;
        public Item_Template[] shopItemsTemplates;

        private void Start()
        {
            for (int i = 0; i < shopItemsData.Length; i++)
            {
                shopItemsTemplates[i].titleText.text = shopItemsData[i].itemName;
                shopItemsTemplates[i].costText.text = shopItemsData[i].unit_Level[0].unlockCost.ToString();
            }
        }

        private void Update()
        {
            
        }


        public void OnItemUpgradeClick()
        {

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
#endregion

