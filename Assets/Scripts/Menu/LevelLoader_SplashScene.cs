using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace TD_Mania_Splash
{
    public class LevelLoader_SplashScene : MonoBehaviour
    {

        [Header("Elements")]
        [SerializeField] private float delayTime = 5f;
        private readonly int mainMenuSceneIndex = 1;

        [Header("Animations")]
        [SerializeField] private Animator animator;
        [SerializeField] private string _FadeInAnim;
        [SerializeField] private string _FadeOutAnim;

        private void Awake()
        {
            animator = GetComponent<Animator>();

            StartCoroutine(SplashCountdownToSwitchScene());
        }

        private IEnumerator SplashCountdownToSwitchScene()
        {
            animator.Play(_FadeInAnim);
            yield return new WaitForSeconds(delayTime);
            animator.Play(_FadeOutAnim);
        }

        // Connected to an animation event.
        public void Splash_GoToMainMenu()
        {
            SceneManager.LoadScene(mainMenuSceneIndex);
        }

    }
}


