using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class Tutorial_Handler : MonoBehaviour
{

    [SerializeField] TMP_Text visibleText;
    //
    [SerializeField] string[] tutorialTexts; // For explaining the rules of the game.
    int indexPointer = 0;

    [Header("Timers")]
    private float timerDelay = 0f;
    private float timerDelayThreshold = 0f;

    private void Start()
    {
        timerDelay = timerDelayThreshold;
    }

    private void Update()
    {
        PlayTutorial();
    }

    private void PlayTutorial()
    {
        timerDelay += Time.deltaTime;

        if (timerDelay > 1f && timerDelay < 7.99f)
        {
            visibleText.text = tutorialTexts[0];
        }
        else if (timerDelay > 8f && timerDelay < 15.99f)
        {
            visibleText.text = tutorialTexts[indexPointer + 1];
        }
        else if (timerDelay > 16f && timerDelay < 23.99f)
        {
            visibleText.text = tutorialTexts[indexPointer + 2];
        }
        else if (timerDelay > 24f && timerDelay < 31.99f)
        {
            visibleText.text = tutorialTexts[indexPointer + 3];
        }
        else if (timerDelay > 32f && timerDelay < 39.99f)
        {
            visibleText.text = tutorialTexts[indexPointer + 4];
        }
        else if (timerDelay > 40f && timerDelay < 49.99f)
        {
            visibleText.text = tutorialTexts[indexPointer + 5];
        }
        else if (timerDelay > 50f && timerDelay < 59.99f)
        {
            visibleText.text = tutorialTexts[indexPointer + 6];
        }
        else if (timerDelay > 60f && timerDelay < 69.99f)
        {
            visibleText.text = tutorialTexts[indexPointer + 7];
        }
        else if (timerDelay > 70f && timerDelay < 79.99f)
        {
            visibleText.text = tutorialTexts[indexPointer + 8];
        }
        else if (timerDelay > 80f && timerDelay < 89.99f)
        {
            visibleText.text = tutorialTexts[indexPointer + 9];
        }
        else if (timerDelay > 90f && timerDelay < 99.99f)
        {
            visibleText.text = tutorialTexts[indexPointer + 10];
        }
        else if (timerDelay > 100f && timerDelay < 109.99f)
        {
            visibleText.text = tutorialTexts[indexPointer + 11];
        }
        else if (timerDelay > 110f && timerDelay < 119.99f)
        {
            visibleText.text = tutorialTexts[indexPointer + 12];
        }
        else
        {
            visibleText.text = "";
        }
    }

}
