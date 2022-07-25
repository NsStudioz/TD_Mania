using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoints_New : MonoBehaviour
{

    [SerializeField] public static Transform[] waypoints_new;

    void Awake()
    {
        waypoints_new = new Transform[transform.childCount];

        for (int i = 0; i < waypoints_new.Length; i++)
        {
            waypoints_new[i] = transform.GetChild(i);
        }
    }
}
