using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paths : MonoBehaviour
{
    /*    public Transform GetToNextWaypoint(Transform currentWaypoint)
        {
            if(currentWaypoint == null)
            {
                return transform.GetChild(0);
            }

            if (currentWaypoint.GetSiblingIndex() < transform.childCount - 1)
            {
                return transform.GetChild(currentWaypoint.GetSiblingIndex() + 1);
            }
            else
            {
                return transform.GetChild(0);
            }

        }*/

    public Transform GetToNextWaypoint(Transform currentWaypoint)
    {
        if (currentWaypoint == null)
        {
            return transform.GetChild(0);
        }

        if (currentWaypoint.GetSiblingIndex() < transform.childCount - 1)
        {
            return transform.GetChild(currentWaypoint.GetSiblingIndex() + 1);
        }

        return transform.GetChild(0); // return first child index.

    }

}
