using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))] // our EnemyMovement component will not work without Enemy Component.
public class EnemyMovement_Test : MonoBehaviour
{
    private Enemy enemy;

    public Transform target;
    public int wavepointIndex = 0;

    void Start()
    {
        target = target.GetChild(wavepointIndex);

        enemy = GetComponent<Enemy>();

        transform.position = target.transform.position; // pursuing the first waypoint with the index of zero to be equal to target.
    }

    void Update()
    {
        Vector3 dir = target.transform.position - transform.position;
        transform.Translate(dir.normalized * enemy.movingSpeed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, target.transform.position) <= 0.1f)
        {
            MoveToNextWaypoint();
        }

        enemy.movingSpeed = enemy.startSpeed;

    }

    private void MoveToNextWaypoint()
    {
        if (wavepointIndex == target.childCount - 1) // if reached the destination.
        {
            EndPath();
            return;
        }

        wavepointIndex++;
        transform.position = target.transform.position;
    }

    /*    private void MoveToNextWaypoint()
        {
            if (Vector3.Distance(transform.position, target.position) < 0.1f) // if reached the destination.
            {
                wavepointIndex++;
                transform.position = target.GetChild(wavepointIndex).transform.position;
                *//*            EndPath();
                            return;*//*
            }


        }*/

    private void EndPath()
    {
        PlayerStats.Lives--;

        Destroy(gameObject);
    }

}
