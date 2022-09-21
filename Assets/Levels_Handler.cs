using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Levels_Handler : MonoBehaviour
{

    float pauseGame = 0f;
    float ResumeGame = 1f;

    public void Retry() // restart loaded scene
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); 
    }

    public void ReturnToMainMenu()
    {
        Debug.Log("Go to Menu");
        //SceneManager.LoadScene(0);
    }

    public void ResumeGameSession()
    {
        Time.timeScale = ResumeGame;
    }

    public void IngameMenuFunction()
    {
        //
    }

    public void PauseGameSession()
    {
        Time.timeScale = pauseGame;
    }
}
