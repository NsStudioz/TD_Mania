using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GamePlay_Manager : MonoBehaviour
{

    public TMP_Text GoldCountText;  // Gold shown on Screen
    public TMP_Text wavesCountText; // wave count, when timer ends start new wave.
    public TMP_Text TimerCountText; // Time left for game\waves to end.

    [SerializeField] int goldText = 0;
    [SerializeField] private int wavesText = 0;
    [SerializeField] private float timerText = 0f;

    

    void Start()
    {
        //LinkTextsToVars();
        
    }

    void Update()
    {
        //LinkTextsToVars();
        goldText = PlayerStats.Gold;
        GoldCountText.text = goldText.ToString();
    }


    private void LinkTextsToVars()
    {
        GoldCountText.text = goldText.ToString();
        wavesCountText.text = wavesText.ToString();
        TimerCountText.text = timerText.ToString();
    }

}
