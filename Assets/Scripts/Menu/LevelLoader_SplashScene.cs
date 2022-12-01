using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader_SplashScene : MonoBehaviour
{

    [SerializeField] float delayTime;
    [SerializeField] float delayTimeThreshold = 8f;
    [SerializeField] int mainMenuSceneIndex = 1;
    
    [Header("Animations")]
    [SerializeField] Animator animator;
    [SerializeField] string _FadeInAnim;
    [SerializeField] string _FadeOutAnim;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    void Start()
    {
        delayTime = delayTimeThreshold;

        animator.Play(_FadeInAnim);
    }

    void Update()
    {
        delayTime -= Time.deltaTime;

        if (delayTime <= 0f) { animator.Play(_FadeOutAnim); }
    }

    public void Splash_GoToMainMenu()
    {
        SceneManager.LoadScene(mainMenuSceneIndex);
    }

}
