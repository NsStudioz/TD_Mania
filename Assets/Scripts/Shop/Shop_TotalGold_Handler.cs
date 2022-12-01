using UnityEngine;
using TMPro;

public class Shop_TotalGold_Handler : MonoBehaviour
{

    [SerializeField] TMP_Text _TotalGoldText;

    void Start()
    {
        PlayerStats._TotalGold = PlayerPrefs.GetInt("TotalGoldCount");
        _TotalGoldText.text = PlayerStats._TotalGold.ToString();
    }


    void Update()
    {
        PlayerStats._TotalGold = PlayerPrefs.GetInt("TotalGoldCount");
        _TotalGoldText.text = PlayerStats._TotalGold.ToString();
    }
}
