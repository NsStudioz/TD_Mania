using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletOrganizer : MonoBehaviour
{

    public List<GameObject> bulletList;

    private void Awake()
    {
        bulletList = new List<GameObject>();
    }

}
