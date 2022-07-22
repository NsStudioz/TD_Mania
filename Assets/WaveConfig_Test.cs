using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveConfig_Test : MonoBehaviour
{

    [SerializeField] GameObject pathPrefab;

    public List<Transform> GetWaypoints()
    {
        var waveWaypoints = new List<Transform>();
        foreach (Transform child in pathPrefab.transform)
        {
            waveWaypoints.Add(child);
        }
        return waveWaypoints;
    }

}
