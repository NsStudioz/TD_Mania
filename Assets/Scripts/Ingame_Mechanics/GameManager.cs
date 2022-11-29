using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class GameManager : MonoBehaviour
{
    // RESPONSIBLE FOR GAME-OVER\GAME-WON UI FUNCTIONALITY AFTER GAME-SESSION ENDS:
    // Included an On Game Start method to run Music.

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

    // Health Vars:
    private int _MaxHealth = 10; // For Gold Trophy
    private int _MidHealth = 5;  // For Silver Trophy
    private int _NoHealth = 0;   // For Bronze Trophy

    // EVENTS:
    public static event Action OnGameEnds_StopThemeTrack; // Battle Theme

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
        OnGameEnds_StopMusicTrack();
    }

    #region Game End UI
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

    #endregion

    #region Mobile Controls Visibility
    private void OnGameEnds_DeactivateTouchButtonsUI()
    {
        if (GamePlay_Manager.GetGameOver() || GamePlay_Manager.GetGameWon()) { TouchButtons_GO.SetActive(false); }
    }

    private void OnGamePauses_DeactivateTouchButtonsUI()
    {
        if (Time.timeScale == Levels_Handler.GetPauseGame()) { TouchButtons_GO.SetActive(false); }
        else if (Time.timeScale == Levels_Handler.GetResumeGame()) { TouchButtons_GO.SetActive(true); }
    }

    #endregion

    #region Gold, SaveGold & Next button
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
    private void SetNextLevelButtonInteractable() // after conversion
    {
        nextLevelButton_Blocker.SetActive(false);
    }
    private void SaveTotalGoldCount()
    {
        PlayerPrefs.SetInt("TotalGoldCount", PlayerStats._TotalGold);
        PlayerStats._TotalGold = PlayerPrefs.GetInt("TotalGoldCount");
        PlayerPrefs.Save();
    }
    #endregion
    
    #region Trophies
    private void OnGameStarts_SetTrophiesToNotVisible()
    {
        _BronzeTrophy.SetActive(false);
        _SilverTrophy.SetActive(false);
        _GoldTrophy.SetActive(false);
    }

    private void OnGameWon_SetTrophiesVisibility()
    {
        if (PlayerStats.Lives == _MaxHealth) { _GoldTrophy.SetActive(true); }
        else if (PlayerStats.Lives >= _MidHealth & PlayerStats.Lives < _MaxHealth) { _SilverTrophy.SetActive(true); }
        else if (PlayerStats.Lives > _NoHealth & PlayerStats.Lives < _MidHealth) { _BronzeTrophy.SetActive(true); }
    }
    #endregion
    
    private void OnGameEnds_StopMusicTrack()
    {
        if (GamePlay_Manager.GetGameOver() || GamePlay_Manager.GetGameWon()) { OnGameEnds_StopThemeTrack?.Invoke(); }
    }
}

/*if (PlayerStats.Lives == 20) { _GoldTrophy.SetActive(true); }
else if (PlayerStats.Lives >= 11 & PlayerStats.Lives < 20) { _SilverTrophy.SetActive(true); }
else if (PlayerStats.Lives > 0 & PlayerStats.Lives <= 10) { _BronzeTrophy.SetActive(true); }*/