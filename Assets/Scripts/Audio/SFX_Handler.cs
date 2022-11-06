using UnityEngine;

namespace ShopSystem 
{
    public class SFX_Handler : MonoBehaviour
    {
        [SerializeField] AudioManager audioManager;

        void Awake()
        {
            audioManager = GetComponent<AudioManager>();
        }

        #region Subscribe\Unsubscribe:
        private void OnEnable()
        {
            //TURRETS (Firing + Constructed):
            D_Unit_Turret.OnUnitTurret_Cannon_Fire += PlaySoundFX_UnitTurret_Cannon;
            D_Unit_Turret.OnUnitTurret_MissileLauncher_Fire += PlaySoundFX_UnitTurret_MissileLauncher;
            D_Unit_Turret.OnUnitTurret_AutoTurret_Fire += PlaySoundFX_UnitTurret_AutoTurret;
            D_Unit_Turret.OnUnitTurret_PlasmaCannon_Fire += PlaySoundFX_UnitTurret_PlasmaCannon;
            D_Unit_Turret.OnUnitTurret_ConstructedSFX_1 += PlayUnitConstructionSFX_1;
            D_Unit_Turret.OnUnitTurret_ConstructedSFX_2 += PlayUnitConstructionSFX_2;
            //
            D_Unit_Turret_LaserBeamer.OnUnitTurret_LaserBeamer_Fire += PlaySoundFX_UnitTurret_LaserBeamer;
            D_Unit_Turret_LaserBeamer.OnUnitTurret_LaserBeamer_Stop += StopSoundFX_UnitTurret_LaserBeamer;
            D_Unit_Turret_LaserBeamer.OnUnitTurret_ConstructedSFX_1 += PlayUnitConstructionSFX_1;
            D_Unit_Turret_LaserBeamer.OnUnitTurret_ConstructedSFX_2 += PlayUnitConstructionSFX_2;
            //
            D_Unit_Buffer.OnUnitTurret_ConstructedSFX_1 += PlayUnitConstructionSFX_1;
            D_Unit_Buffer.OnBuffer_IdleSFX += PlaySoundFX_UnitTurret_Buffer;
            // BULLET IMPACT SFX:
            Bullet.OnBulletImpact_Bullet += PlayBulletImpact_SFX;
            Bullet.OnBulletImpact_Missile += PlayMissileImpact_SFX;
            Bullet.OnBulletImpact_BulletAuto += PlayBulletAutoImpact_SFX;
            Plasma_EFX.OnPlasmaBoomSFX += PlayPlasmaBoom_SFX;
            // TRAPS SFX:
            D_Trap_Mine.OnMineExplode += PlayTrap_Mine_ExplodeSFX;
            D_Trap_Mine.OnUnitTrap_ConstructedSFX_1 += PlayUnitConstructionSFX_1;
            D_Trap_Mine.OnUnitTrap_ConstructedSFX_2 += PlayUnitConstructionSFX_2;
            //
            D_Trap_AntiShield.OnAntiShieldMineExplode += PlayTrap_AntiShieldMine_ExplodeSFX;
            D_Trap_AntiShield.OnUnitTrap_ConstructedSFX_1 += PlayUnitConstructionSFX_1;
            D_Trap_AntiShield.OnUnitTrap_ConstructedSFX_2 += PlayUnitConstructionSFX_2;
            //
            D_Trap_Binder.OnUnitTrap_ConstructedSFX_1 += PlayUnitConstructionSFX_1;
            D_Trap_Binder.OnUnitTrap_ConstructedSFX_2 += PlayUnitConstructionSFX_2;
            D_Trap_Binder.OnBinderBeep += PlayTrap_Binder_BeepSFX;
            D_Trap_Binder.OnBinderExplode += PlayTrap_Binder_ExplodeSFX;
            //
            D_Trap_GoldGenerator.OnUnitGG_ConstructedSFX_1 += PlayUnitConstructionSFX_1;
            D_Trap_GoldGenerator.OnUnitGG_ActivateSFX_1 += PlayTrap_GoldGenerator_ActivateSFX_1;
            D_Trap_GoldGenerator.OnUnitGG_ActivateSFX_2 += PlayTrap_GoldGenerator_ActivateSFX_2;
            // INGAME GAME END SFX
            Game_End_Handler.OnClick_Ingame_GameWon_SFX += Play_GameWon_SFX;
            Game_End_Handler.OnClick_Ingame_GameOver_SFX += Play_GameOver_SFX;
            // ENEMY SFX:
            Enemy.OnEnemy_Death_SFX += Play_EnemyDeath_SFX;
            // UI-SFX:
            LevelSelection.OnUIClick_Menu_SFX += Play_UI_ClickMenu_SFX;
            MainMenu_Handler.OnUIClick_Menu_SFX += Play_UI_ClickMenu_SFX;
            MainMenu_Handler.OnUIClick_Back_SFX += Play_MainMenu_Back_SFX;
            Levels_Handler.OnUIClick_Menu_SFX += Play_UI_ClickMenu_SFX;
            Levels_Handler.OnUIClick_Ingame_SFX += Play_UI_Click_Ingame_SFX;
            //
            ConstructManager.OnUIClick_UnitSelect_SFX += Play_UI_UnitSelect_SFX;
            LayoutVisibility.OnUIClick_UnitSelect_SFX += Play_UI_UnitSelect_SFX;
            LayoutVisibility.OnClick_UI_UnitsButton_Fold_SFX += Play_UI_UnitsButton_Fold_SFX;
            LayoutVisibility.OnClick_UI_UnitsButton_Unfold_SFX += Play_UI_UnitsButton_Unfold_SFX;
            //
            Audio_Options_Handler.OnUIClick_Menu_SFX += Play_UI_ClickMenu_SFX;
            Main_Menu_Shop_UI.OnClick_UI_Upgrade_SFX += Play_UI_ClickUpgrade_SFX;
            Shop_Category_UI.OnUIClick_Back_SFX += Play_MainMenu_Back_SFX;
            Shop_Category_UI.OnUIClick_Ingame_SFX += Play_UI_Click_Ingame_SFX;
        }

        private void OnDisable()
        {
            //TURRETS (Firing + Constructed):
            D_Unit_Turret.OnUnitTurret_Cannon_Fire -= PlaySoundFX_UnitTurret_Cannon;
            D_Unit_Turret.OnUnitTurret_MissileLauncher_Fire -= PlaySoundFX_UnitTurret_MissileLauncher;
            D_Unit_Turret.OnUnitTurret_AutoTurret_Fire -= PlaySoundFX_UnitTurret_AutoTurret;
            D_Unit_Turret.OnUnitTurret_PlasmaCannon_Fire -= PlaySoundFX_UnitTurret_PlasmaCannon;
            D_Unit_Turret.OnUnitTurret_ConstructedSFX_1 -= PlayUnitConstructionSFX_1;
            D_Unit_Turret.OnUnitTurret_ConstructedSFX_2 -= PlayUnitConstructionSFX_2;
            //
            D_Unit_Turret_LaserBeamer.OnUnitTurret_LaserBeamer_Fire -= PlaySoundFX_UnitTurret_LaserBeamer;
            D_Unit_Turret_LaserBeamer.OnUnitTurret_LaserBeamer_Stop -= StopSoundFX_UnitTurret_LaserBeamer;
            D_Unit_Turret_LaserBeamer.OnUnitTurret_ConstructedSFX_1 -= PlayUnitConstructionSFX_1;
            D_Unit_Turret_LaserBeamer.OnUnitTurret_ConstructedSFX_2 -= PlayUnitConstructionSFX_2;
            //
            D_Unit_Buffer.OnUnitTurret_ConstructedSFX_1 -= PlayUnitConstructionSFX_1;
            D_Unit_Buffer.OnBuffer_IdleSFX -= PlaySoundFX_UnitTurret_Buffer;
            // BULLET IMPACT SFX:
            Bullet.OnBulletImpact_Bullet -= PlayBulletImpact_SFX;
            Bullet.OnBulletImpact_Missile -= PlayMissileImpact_SFX;
            Bullet.OnBulletImpact_BulletAuto -= PlayBulletAutoImpact_SFX;
            Plasma_EFX.OnPlasmaBoomSFX -= PlayPlasmaBoom_SFX;
            // TRAPS SFX:
            D_Trap_Mine.OnMineExplode -= PlayTrap_Mine_ExplodeSFX;
            D_Trap_Mine.OnUnitTrap_ConstructedSFX_1 -= PlayUnitConstructionSFX_1;
            D_Trap_Mine.OnUnitTrap_ConstructedSFX_2 -= PlayUnitConstructionSFX_2;
            //
            D_Trap_AntiShield.OnAntiShieldMineExplode -= PlayTrap_AntiShieldMine_ExplodeSFX;
            D_Trap_AntiShield.OnUnitTrap_ConstructedSFX_1 -= PlayUnitConstructionSFX_1;
            D_Trap_AntiShield.OnUnitTrap_ConstructedSFX_2 -= PlayUnitConstructionSFX_2;
            //
            D_Trap_Binder.OnUnitTrap_ConstructedSFX_1 -= PlayUnitConstructionSFX_1;
            D_Trap_Binder.OnUnitTrap_ConstructedSFX_2 -= PlayUnitConstructionSFX_2;
            D_Trap_Binder.OnBinderBeep -= PlayTrap_Binder_BeepSFX;
            D_Trap_Binder.OnBinderExplode -= PlayTrap_Binder_ExplodeSFX;
            //
            D_Trap_GoldGenerator.OnUnitGG_ConstructedSFX_1 -= PlayUnitConstructionSFX_1;
            D_Trap_GoldGenerator.OnUnitGG_ActivateSFX_1 -= PlayTrap_GoldGenerator_ActivateSFX_1;
            D_Trap_GoldGenerator.OnUnitGG_ActivateSFX_2 -= PlayTrap_GoldGenerator_ActivateSFX_2;
            // INGAME GAME END SFX
            Game_End_Handler.OnClick_Ingame_GameWon_SFX -= Play_GameWon_SFX;
            Game_End_Handler.OnClick_Ingame_GameOver_SFX -= Play_GameOver_SFX;
            // ENEMY SFX:
            Enemy.OnEnemy_Death_SFX -= Play_EnemyDeath_SFX;
            // UI-SFX:
            LevelSelection.OnUIClick_Menu_SFX -= Play_UI_ClickMenu_SFX;
            MainMenu_Handler.OnUIClick_Menu_SFX -= Play_UI_ClickMenu_SFX;
            MainMenu_Handler.OnUIClick_Back_SFX -= Play_MainMenu_Back_SFX;
            Levels_Handler.OnUIClick_Menu_SFX -= Play_UI_ClickMenu_SFX;
            Levels_Handler.OnUIClick_Ingame_SFX -= Play_UI_Click_Ingame_SFX;
            //
            ConstructManager.OnUIClick_UnitSelect_SFX -= Play_UI_UnitSelect_SFX;
            LayoutVisibility.OnUIClick_UnitSelect_SFX -= Play_UI_UnitSelect_SFX;
            LayoutVisibility.OnClick_UI_UnitsButton_Fold_SFX -= Play_UI_UnitsButton_Fold_SFX;
            LayoutVisibility.OnClick_UI_UnitsButton_Unfold_SFX -= Play_UI_UnitsButton_Unfold_SFX;
            //
            Audio_Options_Handler.OnUIClick_Menu_SFX -= Play_UI_ClickMenu_SFX;
            Main_Menu_Shop_UI.OnClick_UI_Upgrade_SFX -= Play_UI_ClickUpgrade_SFX;
            Shop_Category_UI.OnUIClick_Back_SFX -= Play_MainMenu_Back_SFX;
            Shop_Category_UI.OnUIClick_Ingame_SFX -= Play_UI_Click_Ingame_SFX;
        }
        #endregion

        #region Play SFX_Unit_Firing:
        public void PlaySoundFX_UnitTurret_Cannon()
        {
            audioManager.PlayOneShot("Cannon_Fire");
        }
        public void PlaySoundFX_UnitTurret_MissileLauncher()
        {
            audioManager.PlayOneShot("Missile_Fire");
        }
        public void PlaySoundFX_UnitTurret_AutoTurret()
        {
            audioManager.PlayOneShot("Auto_Fire");
        }
        public void PlaySoundFX_UnitTurret_PlasmaCannon()
        {
            audioManager.PlayOneShot("Plasma_Fire");
        }
        public void PlaySoundFX_UnitTurret_Buffer()
        {
            audioManager.PlayOneShot("Buffer_Activate");
        }
        public void PlaySoundFX_UnitTurret_LaserBeamer()
        {
            audioManager.PlayOneShot("LaserBeamer_Fire");
        }
        public void StopSoundFX_UnitTurret_LaserBeamer()
        {
            audioManager.Stop("LaserBeamer_Fire");
        }

        #endregion

        #region Play SFX_Unit_Constructions:
        public void PlayUnitConstructionSFX_1()
        {
            audioManager.PlayOneShot("Unit_Built_1");
        }

        public void PlayUnitConstructionSFX_2()
        {
            audioManager.PlayOneShot("Unit_Built_2");
        }

        #endregion

        #region Impact SFX:
        private void PlayPlasmaBoom_SFX()
        {
            audioManager.PlayOneShot("Plasma_Boom");
        }

        private void PlayBulletImpact_SFX()
        {
            audioManager.PlayOneShot("Bullet_Boom");
        }

        private void PlayMissileImpact_SFX()
        {
            audioManager.PlayOneShot("Missile_Boom");
        }

        private void PlayBulletAutoImpact_SFX()
        {
            audioManager.PlayOneShot("Bullet_Auto_Boom");
        }
        #endregion

        #region Play SFX_Traps:
        public void PlayTrap_Mine_ExplodeSFX()
        {
            audioManager.PlayOneShot("Trap_Boom");
        }
        public void PlayTrap_Binder_BeepSFX()
        {
            audioManager.PlayOneShot("Trap_Beep");
        }

        public void PlayTrap_Binder_ExplodeSFX()
        {
            audioManager.PlayOneShot("Trap_Boom");
        }

        public void PlayTrap_AntiShieldMine_ExplodeSFX()
        {
            audioManager.PlayOneShot("Trap_Boom");
        }

        public void PlayTrap_GoldGenerator_ActivateSFX_1()
        {
            audioManager.PlayOneShot("GoldGenerator_Activate");
        }

        public void PlayTrap_GoldGenerator_ActivateSFX_2()
        {
            audioManager.PlayOneShot("GoldGenerator_Retract");
        }

        #endregion

        #region UI SFX
        private void Play_MainMenu_Back_SFX()
        {
            audioManager.PlayOneShot("UI_Back");
        }
        private void Play_UI_ClickMenu_SFX()
        {
            audioManager.PlayOneShot("UI_Click_Menu");
        }
        private void Play_UI_Click_Ingame_SFX()
        {
            audioManager.PlayOneShot("UI_Click_Ingame");
        }
        private void Play_UI_Popup_SFX()
        {
            audioManager.PlayOneShot("UI_Popup");
        }
        private void Play_UI_ClickError_SFX()
        {
            audioManager.PlayOneShot("UI_ClickError");
        }
        private void Play_UI_ClickUpgrade_SFX()
        {
            audioManager.PlayOneShot("UI_ClickUpgrade");
        }
        private void Play_UI_UnitsButton_Unfold_SFX()
        {
            audioManager.PlayOneShot("UI_UnitsButton_Unfold");
        }
        private void Play_UI_UnitsButton_Fold_SFX()
        {
            audioManager.PlayOneShot("UI_UnitsButton_Fold");
        }
        private void Play_UI_UnitSelect_SFX()
        {
            audioManager.PlayOneShot("UI_TurretSelect");
        }

        #endregion

        #region GameEnd_SFX:
        private void Play_GameWon_SFX()
        {
            audioManager.PlayOneShot("Ingame_GameWon");
        }
        private void Play_GameOver_SFX()
        {
            audioManager.PlayOneShot("Ingame_GameOver");
        }

        #endregion

        #region Enemy SFX:
        private void Play_EnemyDeath_SFX()
        {
            audioManager.PlayOneShot("Enemy_Boom");
        }
        #endregion

        #region Trash Code:
        public void PlayTurretBuiltSFX_1()
        {
            audioManager.PlayOneShot("Unit_Built_1");
        }

        public void PlayTurretBuiltSFX_2()
        {
            audioManager.PlayOneShot("Unit_Built_2");
        }

        public void PlayTurretFireSFX_Cannon()
        {
            audioManager.PlayOneShot("Cannon_Fire");
        }

        public void PlayTurretFireSFX_MissileLauncher()
        {
            audioManager.PlayOneShot("Missile_Fire");
        }

        public void PlayTurretFireSFX_AutoTurret()
        {
            audioManager.PlayOneShot("Auto_Fire");
        }

        public void PlayTurretFireSFX_PlasmaCannon()
        {
            audioManager.PlayOneShot("Plasma_Fire");
        }

        #endregion

    }
}
