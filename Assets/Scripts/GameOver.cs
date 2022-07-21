using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public TMP_Text roundsText;

    void OnEnable()
    {
        roundsText.text = PlayerStats.Rounds.ToString();
    }

    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // restart currently loaded scene on its index position.
    }

    public void ReturnToMainMenu()
    {
        Debug.Log("Go to Menu");
        //SceneManager.LoadScene(0);
    }

}
