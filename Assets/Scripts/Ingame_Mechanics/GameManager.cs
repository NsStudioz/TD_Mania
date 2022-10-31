using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    // RESPONSIBLE FOR GAME-OVER\GAME-WON UI FUNCTIONALITY AFTER GAME-SESSION ENDS:

    [SerializeField] GameObject gameOverUI;
    [SerializeField] GameObject gameWonUI;
    [SerializeField] TMP_Text secondsSuvivedText; // after game ends.

    void Start()
    {
        gameOverUI.SetActive(false);
        gameWonUI.SetActive(false);
    }

    void Update()
    {
        if (GamePlay_Manager.GetGameOver()) 
        { 
            SetGameOverUI();
            secondsSuvivedText.text = GamePlay_Manager.GetSurvivalTimerResults().ToString("F2"); // ALSO CONVERT TO FLOAT WITH 2 DECIMAL POINTS.
        }

        else if (GamePlay_Manager.GetGameWon()) { SetGameWonUI(); } 
    }

    private void SetGameOverUI()
    {
        gameOverUI.SetActive(true); 
    }

    private void SetGameWonUI()
    {
        gameWonUI.SetActive(true); 
    }
}
