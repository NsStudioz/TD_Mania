using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Levels_Handler : MonoBehaviour
{
    // RELATED TO LEVEL LOAD FUNCTIONALITIES:
    private const float pauseGame = 0f;
    private const float ResumeGame = 1f;
    private const int main_Menu_Index = 1;
    private int levelToLoad;
    //
    [SerializeField] int currentSceneIndex;
    [SerializeField] int NextSceneIndex;
    //
    [SerializeField] Animator animator;
    //
    [SerializeField] GameObject pauseMenu_UI;
    [SerializeField] GameObject gameOver_UI;
    [SerializeField] GameObject gameWon_UI;
    [SerializeField] bool gameIsPaused;

    // EVENTS:
    public static event Action OnUIClick_Menu_SFX;
    public static event Action OnUIClick_Ingame_SFX;
    public static event Action OnGameEnds_PlayBattleThemeOnNextLevel;
    public static event Action OnThemeSwap_BattleToMenu;

    // Getters:
    public static float GetPauseGame()
    {
        return pauseGame;
    }
    public static float GetResumeGame()
    {
        return ResumeGame;
    }

    private void Start()
    {
        pauseMenu_UI.SetActive(false);
    }

    private void Update()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        NextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
    }

    public void GoToNextLevel()
    {
        OnUIClick_Menu_SFX?.Invoke();
        gameWon_UI.SetActive(false);
        FadeLevel(currentSceneIndex + 1);
        if (NextSceneIndex > PlayerPrefs.GetInt("Level_At")) { PlayerPrefs.SetInt("Level_At", NextSceneIndex); }
    }

    public void RestartGameSession() // restart current scene
    {
        Time.timeScale = ResumeGame;
        OnUIClick_Menu_SFX?.Invoke();
        pauseMenu_UI.SetActive(false);
        FadeLevel(currentSceneIndex);  
    }

    public void ReturnToMainMenu()
    {
        Time.timeScale = ResumeGame;
        OnUIClick_Menu_SFX?.Invoke();
        pauseMenu_UI.SetActive(false);
        FadeLevel(main_Menu_Index);     
    }

    public void ReturnToMainMenuFromGameOver()
    {
        gameOver_UI.SetActive(false);
        OnUIClick_Menu_SFX?.Invoke();
        FadeLevel(main_Menu_Index);
    }

    public void ReturnToMainMenuFromGameWon()
    {
        OnUIClick_Menu_SFX?.Invoke();
        gameWon_UI.SetActive(false);
        FadeLevel(main_Menu_Index);
    }

    public void ResumeGameSession() // resume game
    {
        Time.timeScale = ResumeGame;
        OnUIClick_Ingame_SFX?.Invoke();
        pauseMenu_UI.SetActive(false);
    }

    public void PauseGameSession() // pause game
    {
        OnUIClick_Ingame_SFX?.Invoke();
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

        if(levelToLoad != main_Menu_Index)
        {
            OnGameEnds_PlayBattleThemeOnNextLevel?.Invoke();
        }
        else { OnThemeSwap_BattleToMenu?.Invoke(); }
    }
}