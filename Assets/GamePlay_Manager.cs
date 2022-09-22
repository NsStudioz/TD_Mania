using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GamePlay_Manager : MonoBehaviour
{
    // RESPONSIBLE FOR GAME-OVER\GAME-WON FUNCTIONALITY DURING GAMEPLAY:

    [Header("Text Objects")]
    [SerializeField] TMP_Text GoldCountText;   // Gold count
    [SerializeField] TMP_Text healthCountText; // Remaining Health
    [SerializeField] TMP_Text TimerCountText;  // Time left for game & waves to end

    [Header("Master Timer")]
    [SerializeField] float masterTimer = 0f;
    [SerializeField] float masterTimerThreshold = 0;
    //
    [SerializeField] static float survivalTimer = 0f;
    [SerializeField] float survivalTimerThreshold = 0f;
    //
    [SerializeField] static bool gameOver;
    [SerializeField] static bool gameWon;


    void Start()
    {
        gameWon = false;
        gameOver = false;
        masterTimer = masterTimerThreshold;
        survivalTimer = survivalTimerThreshold;
    }

    void Update()
    {
        if (gameOver || gameWon)
        {
            return;
        }

        LinkTexts();

        SetGameStates();

        masterTimer -= Time.deltaTime;
        survivalTimer += Time.deltaTime;
    }

    private void LinkTexts()
    {
        GoldCountText.text = "$" + PlayerStats.Gold.ToString();
        healthCountText.text = PlayerStats.Lives.ToString();
        TimerCountText.text = string.Format("{0:00.00}", masterTimer);
    }

    private void SetGameStates()
    {
        if (masterTimer <= 0)
        {
            gameWon = true;
        }
        else if (PlayerStats.Lives <= 0) 
        {
            gameOver = true;
        }
        else if (Input.GetKeyDown("n"))
        {
            gameOver = true;
        }
    }

    public static bool GetGameOver()
    {
        return gameOver;
    }

    public static bool GetGameWon()
    {
        return gameWon;
    }

    public static float GetSurvivalTimerResults() // when game ends.
    {
            return survivalTimer;
    }

}

    //[SerializeField] int goldText = 0;
    //private float countdown = 2f;
    //[SerializeField] private int healthText = 0;
    //[SerializeField] private float timerText = 0f;


/*    private void LinkTexts()
    {
        goldText = PlayerStats.Gold;
        GoldCountText.text = goldText.ToString();
    //TimerCountText.text = timerText.ToString();
    //healthCountText.text = healthText.ToString();
    }*/