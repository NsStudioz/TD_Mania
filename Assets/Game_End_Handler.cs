using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_End_Handler : MonoBehaviour
{
    AudioManager audioManager;

    [SerializeField] Animator animator;

    private void Awake()
    {
        GameObject forAudioManager = GameObject.Find("Audio_Manager");
        audioManager = forAudioManager.GetComponent<AudioManager>();
    }

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (GamePlay_Manager.GetGameOver())
        {
            PlayGameOverAnimation();
            
        }
        else if (GamePlay_Manager.GetGameWon())
        {
            PlayGameWonAnimation(); 
        }
    }

    public void PlayGameWonAnimation()
    {
        animator.Play("GameWon_Anim");
    }
    public void PlayGameOverAnimation()
    {
        animator.Play("GameOver_Anim");
    }

    public void SetGameOverSFX()
    {
        audioManager.PlayOneShot("Ingame_GameOver");
    }

    public void SetGameWonSFX()
    {
        audioManager.PlayOneShot("Ingame_GameWon");
    }
}
