using UnityEngine;
using TD_Mania_MainMenu;
public class Music_Handler : MonoBehaviour
{

    [SerializeField] MusicManager musicManager;

    private void OnEnable()
    {
        GameManager.OnGameEnds_StopThemeTrack += StopBattleTrack;
        Levels_Handler.OnGameEnds_PlayBattleThemeOnNextLevel += PlayBattleTrack;
        LevelSelection.OnUIclick_SwapTracks_MenuToBattle += SwapTracks_FromMenuToBattleTheme;
        Levels_Handler.OnThemeSwap_BattleToMenu += SwapTracks_FromBattleToMenuTheme_Simple;
    }

    private void OnDisable()
    {
        GameManager.OnGameEnds_StopThemeTrack -= StopBattleTrack;
        Levels_Handler.OnGameEnds_PlayBattleThemeOnNextLevel -= PlayBattleTrack;
        LevelSelection.OnUIclick_SwapTracks_MenuToBattle -= SwapTracks_FromMenuToBattleTheme;
        Levels_Handler.OnThemeSwap_BattleToMenu -= SwapTracks_FromBattleToMenuTheme_Simple;
    }

    public void SwapTracks_FromMenuToBattleTheme()
    {
        musicManager.SwapTracks("Main_Menu_Theme", "Battle_Theme");
    }
    public void SwapTracks_FromBattleToMenuTheme_Simple()
    {
        musicManager.SwapTracks("Battle_Theme", "Main_Menu_Theme");
    }

    public void StopBattleTrack() // Fade Out mode.
    {
        musicManager.Stop("Battle_Theme");
    }
    public void PlayBattleTrack() // Fade in mode.
    {
        musicManager.Play("Battle_Theme");
    }
}


/*    [SerializeField] int currentSceneIndex;
    [SerializeField] int MainMenuandShopThemeSceneIndex = 2;*/

/*    private void Update()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
    }*/