using System;
using UnityEngine;

public class ConstructManager : MonoBehaviour
{

    public static ConstructManager instance;

    [Header("Elements")]
    [SerializeField] NodeUI nodeUI;
    //
    private D_Unit_Blueprint defUnitToBuild;
    private Node turret_SelectedNode;
    // Events:
    public static event Action OnUIClick_UnitSelect_SFX;

    void Awake() => InitializeSingletonInstance();

    private void OnEnable()
    {
        ShopManager.OnTurretSelectedToBuild += SelectTurretToBuild;
    }

    private void OnDisable()
    {
        ShopManager.OnTurretSelectedToBuild -= SelectTurretToBuild;

    }

    private void InitializeSingletonInstance()
    {
        if (instance != null)
        {
            Debug.Log("Something went wrong. there are more than 1 buildmanagers in the game!");
            return;
        }
        instance = this;
    }

    // getter only property. If not null then the state is true and we can build.
    public bool CanBuild { get { return defUnitToBuild != null; } }

    // getter only property. If we have enough money then the state is true and we can build.
    public bool HasGold { get { return PlayerStats.Gold >= defUnitToBuild.cost; } }

    public D_Unit_Blueprint GetDefUnitToBuild()
    {
        return defUnitToBuild;
    }

    public void Turret_SelectNode(Node node) // function that works when we click on a built turret.
    {
        if (turret_SelectedNode == node)
        {
            DeselectNode();
            return;
        }

        turret_SelectedNode = node;
        defUnitToBuild = null; // either have a turret to build or a turret to upgrade

        nodeUI.SetTarget(node);
    }

    public void SelectTurretToBuild(D_Unit_Blueprint turretBlueprint) // on turret create
    {
        OnUIClick_UnitSelect_SFX?.Invoke();
        defUnitToBuild = turretBlueprint;
        DeselectNode();
    }

    public void DeselectNode()
    {
        turret_SelectedNode = null;
        nodeUI.Hide();
    }

}