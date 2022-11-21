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

    [Header("Game-Won Trophies")]
    [SerializeField] GameObject _BronzeTrophy;
    [SerializeField] GameObject _SilverTrophy;
    [SerializeField] GameObject _GoldTrophy;

    void Start()
    {
        PlayerStats._TotalGold = PlayerPrefs.GetInt("TotalGoldCount");
        //
        SetGameOver_GameWonToNotVisible();
        OnGameStarts_SetTrophiesToNotVisible();
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

        else if (GamePlay_Manager.GetGameWon()) 
        { 
            SetGameWonUI();
            OnGameWon_SetTrophiesVisibility();
        }

        OnGamePauses_DeactivateTouchButtonsUI();
        OnGameEnds_DeactivateTouchButtonsUI();
        SetGoldTextsValues();
    }

    private void SetGameOver_GameWonToNotVisible()
    {
        gameOverUI.SetActive(false);
        gameWonUI.SetActive(false);
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
        if (GamePlay_Manager.GetGameOver() || GamePlay_Manager.GetGameWon()) { TouchButtons_GO.SetActive(false); }
    }

    private void OnGamePauses_DeactivateTouchButtonsUI()
    {
        if (Time.timeScale == Levels_Handler.GetPauseGame()) { TouchButtons_GO.SetActive(false); }
        else if (Time.timeScale == Levels_Handler.GetResumeGame()) { TouchButtons_GO.SetActive(true); }
    }

    public void OnGameWon_SetCurrentGoldToTotalGoldConversion() // Button Function
    {
        PlayerStats._TotalGold += PlayerStats.Gold;
        PlayerStats.Gold = setCurrentGoldToZero;
        //
        PlayGoldConversion_SFX();
        SaveTotalGoldCount();
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

    private void SaveTotalGoldCount()
    {
        PlayerPrefs.SetInt("TotalGoldCount", PlayerStats._TotalGold);
        PlayerStats._TotalGold = PlayerPrefs.GetInt("TotalGoldCount");
        PlayerPrefs.Save();
    }

    private void OnGameStarts_SetTrophiesToNotVisible()
    {
        _BronzeTrophy.SetActive(false);
        _SilverTrophy.SetActive(false);
        _GoldTrophy.SetActive(false);
    }

    private void OnGameWon_SetTrophiesVisibility()
    {
        if (PlayerStats.Lives == 20) { _GoldTrophy.SetActive(true); }
        else if (PlayerStats.Lives >= 11 & PlayerStats.Lives < 20) { _SilverTrophy.SetActive(true); }
        else if (PlayerStats.Lives > 0 & PlayerStats.Lives <= 10) { _BronzeTrophy.SetActive(true); }
    }
}
