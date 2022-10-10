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

    [SerializeField] GameObject pauseMenu_UI;
    [SerializeField] bool gameIsPaused;

    private void Start()
    {
        pauseMenu_UI.SetActive(false);
    }

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
        Time.timeScale = ResumeGame;
        FadeLevel(currentSceneIndex);
    }

    public void ReturnToMainMenu()
    {
        Time.timeScale = ResumeGame;
        FadeLevel(main_Menu_Index);
    }

    public void ResumeGameSession() // resume game
    {
        Time.timeScale = ResumeGame;
        pauseMenu_UI.SetActive(false);
    }

    public void PauseGameSession() // pause game
    {
        Time.timeScale = pauseGame;
        pauseMenu_UI.SetActive(true);

    }

    public void IngameMenuFunction()
    {
        if (!gameIsPaused)
        {
            PauseGameSession();
            gameIsPaused = true;
        }
        else if (gameIsPaused)
        {
            ResumeGameSession();
            gameIsPaused = false;
        }
        // play SFX
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
