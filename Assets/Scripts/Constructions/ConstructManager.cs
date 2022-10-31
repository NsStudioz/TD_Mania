using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstructManager : MonoBehaviour
{

    public static ConstructManager instance;
    private D_Unit_Blueprint defUnitToBuild;
/*    public GameObject buildEffects;
    public GameObject sellEffects;*/
    //
    private Node turret_SelectedNode;
    [SerializeField] NodeUI nodeUI;

    AudioManager audioManager;

    void Awake()
    {
        if (instance != null)
        {
            Debug.Log("Something went wrong. there are more than 1 buildmanagers in the game!");
            return;
        }

        instance = this;
    }

    private void Start()
    {
        GameObject forAudioManager = GameObject.Find("Audio_Manager");
        audioManager = forAudioManager.GetComponent<AudioManager>();
    }

    // called a property. we only allow it to actually get something from this variable, if its not equal to null, then the state is true and we can build.
    public bool CanBuild { get { return defUnitToBuild != null; } } 

    // called a property. we only allow it to actually get something from this variable, if we have enough money, then the state is true and we can build.
    public bool HasGold { get { return PlayerStats.Gold >= defUnitToBuild.cost; } }

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
        audioManager.PlayOneShot("UI_TurretSelect");
        defUnitToBuild = turretBlueprint;
        DeselectNode();
    }

    public void DeselectNode()
    {
        turret_SelectedNode = null;
        nodeUI.Hide();
    }

    public D_Unit_Blueprint GetDefUnitToBuild()
    {
        return defUnitToBuild;
    }

}
