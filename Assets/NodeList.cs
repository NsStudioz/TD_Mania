using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeList : MonoBehaviour
{
    
    [SerializeField] static List<Node> nodes = new List<Node>();
    [SerializeField] public static bool isUnitsPanelOpen = false;

    void Start()
    {
        OnStart_SyncAndAddAllNodeChildsToList();
    }

    void Update()
    {
        if (isUnitsPanelOpen && PlayerStats.Gold >= PlayerStats.notEnoughGoldThreshold) 
        { 
            CheckNodeAvailabilityAndSetEffect(); 
        }
        else if (isUnitsPanelOpen && PlayerStats.Gold < PlayerStats.notEnoughGoldThreshold)
        {
            NodesUnavailable();
        }
        else
        { 
            DisableNodeEffects(); 
        }    
    }
    //------------------------------------------------------------------------------------------------------------------------
    private void OnStart_SyncAndAddAllNodeChildsToList()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            nodes.Add(transform.GetChild(i).GetComponent<Node>());
        }
    }

    public static void CheckNodeAvailabilityAndSetEffect()
    {
        foreach(Node node in nodes)
        {
            if (node.GetNodeAvailability() == null)
            {
                node.OnTurretChoice_EnableNodeEffect();
            }
            else
            {
                node.OnTurretUnchoice_DisableNodeEffect();
            }
        }
    }

    public static void DisableNodeEffects()
    {
        foreach (Node node in nodes)
        {
            node.OnTurretUnchoice_DisableNodeEffect();
        }
    }

    public static void NodesUnavailable() // not enough gold
    {
        foreach (Node node in nodes)
        {
            node.NodesUnavailable();
        }
    }
}

/*    public void OnGoldAmount_SetNodeColorAndEffect_New()
    {
        foreach(Node node in nodes) 
        {
            node.OnGoldAmount_SetNodeColorAndEffect();
        }
    }*/