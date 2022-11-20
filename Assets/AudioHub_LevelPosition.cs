using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioHub_LevelPosition : MonoBehaviour
{

    [Header("Scene Indexes")]
    [SerializeField] private int currentSceneIndex = 0;

    
    private int mainMenuSceneIndex= 2; // 
    private int tutorialMapSceneIndex= 3; // 
    private int firstGameplayMap_SceneIndex= 4; // 
    private int lastGameplayMap_SceneIndex= 12; // 
    // test index
    private int _TestSceneIndex = 2; // 

    [Header("Vectors")]
    //[SerializeField] Vector3 mainShopScene_Pos;
    [SerializeField] Vector3 mainMenuScene_Pos;
    [SerializeField] Vector3 TutorialScene_Pos;
    [SerializeField] Vector3 gameplayScenes_Pos;

    void Update()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        OnLevelIndexLoad_CorrectTransformPosition();
    }

    private void OnLevelIndexLoad_CorrectTransformPosition()
    {
        if (currentSceneIndex == _TestSceneIndex)
        {
            transform.position = gameplayScenes_Pos;
        }
        else
        {
            transform.position = mainMenuScene_Pos;
        }
/*        else if (currentSceneIndex <= tutorialMapSceneIndex)
        {
            transform.position = TutorialScene_Pos;
        }
        else if (currentSceneIndex >= firstGameplayMap_SceneIndex || currentSceneIndex <= lastGameplayMap_SceneIndex)
        {
            transform.position = gameplayScenes_Pos;
        }*/
    }
}
