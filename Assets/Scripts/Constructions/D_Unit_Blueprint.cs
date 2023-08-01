using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class D_Unit_Blueprint // dont want this script as MonoBehaviour, because we don't want it as a component in unity. We don't need to attach this to any game object.
{                              // but we definitely do want to be able to see the fields here inside the inspector. therefore we are going to mark this as system.serializable
                               // and that way, Unity will save and load the value inside of this class for us, and that means that they are visible in the inspector, therefore we can edit them.
    public string unitName;
    public GameObject prefab;
    public int cost;

    public int GetSellAmount()
    {
        return cost / 2;
    }


}
