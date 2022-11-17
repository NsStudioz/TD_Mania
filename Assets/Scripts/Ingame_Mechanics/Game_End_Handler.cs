using System;
using UnityEngine;

public class Game_End_Handler : MonoBehaviour
{
    // Game-Over / Game-Won Animations and SFX
    [SerializeField] Animator animator;

    public static event Action OnClick_Ingame_GameOver_SFX;
    public static event Action OnClick_Ingame_GameWon_SFX;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (GamePlay_Manager.GetGameOver()) { PlayGameOverAnimation(); }

        else if (GamePlay_Manager.GetGameWon()) { PlayGameWonAnimation(); }
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
        OnClick_Ingame_GameOver_SFX?.Invoke();
    }

    public void SetGameWonSFX()
    {
        OnClick_Ingame_GameWon_SFX?.Invoke();
    }
}