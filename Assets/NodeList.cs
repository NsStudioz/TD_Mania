using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeList : MonoBehaviour
{
    
    [SerializeField] private List<Node> nodes = new List<Node>();
    [SerializeField] private bool isUnitsPanelOpen = false;

    void Start()
    {
        OnStart_SyncAndAddAllNodeChildsToList();
    }

    private void OnEnable()
    {
        LayoutVisibility.OnUIClick_SetNodeEffectOn += SetBoolOn;
        LayoutVisibility.OnUIClick_SetNodeEffectOff += SetBoolOff;
    }
    private void OnDisable()
    {
        LayoutVisibility.OnUIClick_SetNodeEffectOn -= SetBoolOn;
        LayoutVisibility.OnUIClick_SetNodeEffectOff -= SetBoolOff;
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
    // Set Bools:
    private void SetBoolOn()
    {
        isUnitsPanelOpen = true;
    }

    private void SetBoolOff()
    {
        isUnitsPanelOpen = false;
    }

    //------------------------------------------------------------------------------------------------------------------------
    private void OnStart_SyncAndAddAllNodeChildsToList()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            nodes.Add(transform.GetChild(i).GetComponent<Node>());
        }
    }

    private void CheckNodeAvailabilityAndSetEffect()
    {
        foreach(Node node in nodes)
        {
            if (!node.GetNodeAvailability())
            {
                node.OnTurretChoice_EnableNodeEffect();
            }
            else
            {
                node.OnTurretUnchoice_DisableNodeEffect();
            }
        }
    }

    private void DisableNodeEffects()
    {
        foreach (Node node in nodes)
        {
            node.OnTurretUnchoice_DisableNodeEffect();
        }
    }

    private void NodesUnavailable() // not enough gold
    {
        foreach (Node node in nodes)
        {
            if (!node.GetNodeAvailability()) { node.NodesUnavailable(); }      
        }
    }
}

//Old methods: 
/*private void CheckNodeAvailabilityAndSetEffect()
{
    foreach (Node node in nodes)
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
}*/


/*    public void OnGoldAmount_SetNodeColorAndEffect_New()
    {
        foreach(Node node in nodes) 
        {
            node.OnGoldAmount_SetNodeColorAndEffect();
        }
    }*/