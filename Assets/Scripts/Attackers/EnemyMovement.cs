using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyMovement : MonoBehaviour
{
    Enemy enemy;
    private Transform currentWaypoint;

    [Header("Elements")]
    [SerializeField] private EnemyPaths pathing;
    [SerializeField] private float distanceThreshold = 0.1f; // distance from a waypoint

    void Start()
    {
        enemy = GetComponent<Enemy>();

        InitializePosition();
    }

    void Update()
    {
        if (GamePlay_Manager.GetGameOver() || GamePlay_Manager.GetGameWon())
            return;

        MoveTowardsNextWaypoint();
    }

    private void InitializePosition()
    {
        // set initial position to the first waypoint:
        currentWaypoint = pathing.GetNextWaypoint(currentWaypoint);
        transform.position = currentWaypoint.position;

        SetNextWaypointTarget();
    }

    private void SetNextWaypointTarget()
    {
        // set the next waypoint target:
        currentWaypoint = pathing.GetNextWaypoint(currentWaypoint);
        transform.LookAt(currentWaypoint);
    }

    private void MoveTowardsNextWaypoint()
    {
        transform.position = Vector3.MoveTowards(transform.position, currentWaypoint.position, enemy.GetMovingSpeed() * Time.deltaTime);

        if (Vector3.Distance(transform.position, currentWaypoint.position) < distanceThreshold)
            SetNextWaypointTarget();
    }

}
