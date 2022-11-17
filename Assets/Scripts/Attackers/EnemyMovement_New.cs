using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement_New : MonoBehaviour
{
    Enemy enemy;
    private Transform currentWaypoint;

    [SerializeField] EnemyPaths pathing;

    [SerializeField] float distanceThreshold = 0.1f; // distance from a waypoint

    void Start()
    {
        enemy = GetComponent<Enemy>();

        // set initial position to the first waypoint:
        currentWaypoint = pathing.GetNextWaypoint(currentWaypoint);
        transform.position = currentWaypoint.position;

        // set the next waypoint target:
        currentWaypoint = pathing.GetNextWaypoint(currentWaypoint);
        transform.LookAt(currentWaypoint);
    }

    void Update()
    {
        if (GamePlay_Manager.GetGameOver() || GamePlay_Manager.GetGameWon())
        {
            return;
        }

        transform.position = Vector3.MoveTowards(transform.position, currentWaypoint.position, enemy.movingSpeed * Time.deltaTime);
        if (Vector3.Distance(transform.position, currentWaypoint.position) < distanceThreshold)
        {
            currentWaypoint = pathing.GetNextWaypoint(currentWaypoint);
            transform.LookAt(currentWaypoint);
        }

        enemy.movingSpeed = enemy.startSpeed;
    }



}
