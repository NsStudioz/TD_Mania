using UnityEngine;
using TMPro;

public class Tutorial_Handler_LVL1 : MonoBehaviour
{

    [SerializeField] private GameObject _TutorialText;

    private void Start()
    {
        _TutorialText.SetActive(false);
    }

    void Update()
    {
        if (GamePlay_Manager.GetGameWon())
        {
            _TutorialText.SetActive(true);
        }
    }
}
