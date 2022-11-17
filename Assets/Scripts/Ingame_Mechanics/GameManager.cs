using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class GameManager : MonoBehaviour
{
    // RESPONSIBLE FOR GAME-OVER\GAME-WON UI FUNCTIONALITY AFTER GAME-SESSION ENDS:

    [SerializeField] GameObject gameOverUI;
    [SerializeField] GameObject gameWonUI;
    [SerializeField] TMP_Text secondsSuvivedText; // after game ends.

    [Header("TouchButtons GameObject Parent")]
    [SerializeField] GameObject TouchButtons_GO;

    [Header("Game-Won Elements")]
    [SerializeField] TMP_Text current_Gold_Text;
    [SerializeField] TMP_Text total_Gold_Text;
    [SerializeField] GameObject nextLevelButton_Blocker;
    [SerializeField] int setCurrentGoldToZero = 0;
    public static event Action OnClick_PlayGoldConversion;

    void Start()
    {
        gameOverUI.SetActive(false);
        gameWonUI.SetActive(false);
        nextLevelButton_Blocker.SetActive(true);
        TouchButtons_GO.SetActive(true);
    }

    void Update()
    {
        if (GamePlay_Manager.GetGameOver()) 
        { 
            SetGameOverUI();
            secondsSuvivedText.text = GamePlay_Manager.GetSurvivalTimerResults().ToString("F2"); // ALSO CONVERT TO FLOAT WITH 2 DECIMAL POINTS.
        }

        else if (GamePlay_Manager.GetGameWon()) { SetGameWonUI(); }

        OnGameEnds_DeactivateTouchButtonsUI();
        SetGoldTextsValues();
    }

    private void SetGameOverUI()
    {
        gameOverUI.SetActive(true); 
    }

    private void SetGameWonUI()
    {
        gameWonUI.SetActive(true); 
    }

    private void OnGameEnds_DeactivateTouchButtonsUI()
    {
        if (GamePlay_Manager.GetGameOver() || GamePlay_Manager.GetGameWon())
        {
            TouchButtons_GO.SetActive(false);
        }
    }

    public void OnGameWon_SetCurrentGoldToTotalGoldConversion()
    {
        PlayerStats._TotalGold += PlayerStats.Gold;
        PlayerStats.Gold = setCurrentGoldToZero;
        //
        PlayGoldConversion_SFX();
        SetNextLevelButtonInteractable();
    }

    private void SetGoldTextsValues()
    {
        current_Gold_Text.text = PlayerStats.Gold.ToString();
        total_Gold_Text.text = PlayerStats._TotalGold.ToString();
    }

    private void PlayGoldConversion_SFX()
    {
        OnClick_PlayGoldConversion?.Invoke();
    }
    private void SetNextLevelButtonInteractable()
    {
        nextLevelButton_Blocker.SetActive(false);
    }
}
