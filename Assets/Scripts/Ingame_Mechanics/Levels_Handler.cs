using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Levels_Handler : MonoBehaviour
{
    // RELATED TO LEVEL LOAD FUNCTIONALITIES:
    private const float pauseGame = 0f;
    private const float ResumeGame = 1f;
    private const int main_Menu_Index = 0;
    private int levelToLoad;

    [SerializeField] int currentSceneIndex;

    [SerializeField] Animator animator;


    private void Update()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
    }

    public void GoToNextLevel()
    {
        FadeLevel(currentSceneIndex++);
    }

    public void RestartGameSession() // restart current scene
    {
        FadeLevel(currentSceneIndex);
    }

    public void ReturnToMainMenu()
    {
        FadeLevel(main_Menu_Index);
    }

    public void ResumeGameSession() // resume game
    {
        Time.timeScale = ResumeGame;
    }

    public void PauseGameSession() // pause game
    {
        Time.timeScale = pauseGame;
    }

    public void IngameMenuFunction()
    {
        //
    }

    //------------------------------------------------------------------------------------------------------------------------------------------------------------------
    // LevelFader:
    private void FadeLevel(int currentSceneIndex)
    {
        levelToLoad = currentSceneIndex;
        animator.SetTrigger("FadeScene");
    }

    public void OnFadeComplete()
    {
        SceneManager.LoadScene(levelToLoad);
    }
}
