using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GamePlay_Manager : MonoBehaviour
{

    [SerializeField] TMP_Text GoldCountText;  // Gold shown on Screen
    [SerializeField] TMP_Text healthCountText; // wave count, when timer ends start new wave.
    [SerializeField] TMP_Text TimerCountText; // Time left for game\waves to end.

    [SerializeField] int goldText = 0;
    private float countdown = 2f;
    //[SerializeField] private int healthText = 0;
    //[SerializeField] private float timerText = 0f;

    void Start()
    {
        //LinkTextsToVars(); 
    }

    void Update()
    {
        //LinkTextsToVars();
        goldText = PlayerStats.Gold;
        GoldCountText.text = goldText.ToString();
        healthCountText.text = PlayerStats.Lives.ToString();
        TimerCountText.text = string.Format("{0:00.00}", countdown);
    }


    private void LinkTextsToVars()
    {
        GoldCountText.text = goldText.ToString();
        

        
        //TimerCountText.text = timerText.ToString();
        //healthCountText.text = healthText.ToString();
    }

}
