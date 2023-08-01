using UnityEngine;

public class ShopManager : MonoBehaviour
{
    // Turrets:
    [SerializeField] D_Unit_Blueprint d_Unit_Turret_Standard;
    [SerializeField] D_Unit_Blueprint d_Unit_Turret_MissileLauncher;
    [SerializeField] D_Unit_Blueprint d_Unit_Turret_WideBeamer;
    [SerializeField] D_Unit_Blueprint d_Unit_Turret_LaserBeamer;
    [SerializeField] D_Unit_Blueprint d_Unit_Turret_StandardAuto;
    [SerializeField] D_Unit_Blueprint d_Unit_Turret_AntiShield_Standard;
    [SerializeField] D_Unit_Blueprint d_Unit_Turret_AntiShield_StandardAuto;
    [SerializeField] D_Unit_Blueprint d_Unit_Turret_AntiShield_ShieldDestroyer;
    [SerializeField] D_Unit_Blueprint d_Unit_Turret_Buffer;
    // Traps:
    [SerializeField] D_Unit_Blueprint d_Unit_Trap_Mine;
    [SerializeField] D_Unit_Blueprint d_Unit_Trap_Binder;
    [SerializeField] D_Unit_Blueprint d_Unit_Trap_GoldGenerator;
    [SerializeField] D_Unit_Blueprint d_Unit_Trap_AntiShieldMine;


    public void SelectTurretStandard()
    {
        ConstructManager.instance.SelectTurretToBuild(d_Unit_Turret_Standard);
    }

    public void SelectTurretMissileLauncher()
    {
        ConstructManager.instance.SelectTurretToBuild(d_Unit_Turret_MissileLauncher);
    }

    public void SelectTurretWideBeamer()
    {
        ConstructManager.instance.SelectTurretToBuild(d_Unit_Turret_WideBeamer);
    }
    public void SelectTurretLaserBeamer()
    {
        ConstructManager.instance.SelectTurretToBuild(d_Unit_Turret_LaserBeamer);
    }
    public void SelectTurretStandardAuto()
    {
        ConstructManager.instance.SelectTurretToBuild(d_Unit_Turret_StandardAuto);
    }
    public void SelectTurretAntiShieldStandard()
    {
        ConstructManager.instance.SelectTurretToBuild(d_Unit_Turret_AntiShield_Standard);
    }
    public void SelectTurretAntiShieldStandardAuto()
    {
        ConstructManager.instance.SelectTurretToBuild(d_Unit_Turret_AntiShield_StandardAuto);
    }
    public void SelectTurretAntiShieldShieldDestroyer()
    {
        ConstructManager.instance.SelectTurretToBuild(d_Unit_Turret_AntiShield_ShieldDestroyer);
    }
    public void SelectTurretBuffer()
    {
        ConstructManager.instance.SelectTurretToBuild(d_Unit_Turret_Buffer);
    }
    public void SelectTrapMine()
    {
        ConstructManager.instance.SelectTurretToBuild(d_Unit_Trap_Mine);
    }
    public void SelectTrapBinder()
    {
        ConstructManager.instance.SelectTurretToBuild(d_Unit_Trap_Binder);
    }
    public void SelectTrapGoldGenerator()
    {
        ConstructManager.instance.SelectTurretToBuild(d_Unit_Trap_GoldGenerator);
    }
    public void SelectTrapAntiShieldMine()
    {
        ConstructManager.instance.SelectTurretToBuild(d_Unit_Trap_AntiShieldMine);
    }

}
