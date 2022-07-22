using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))] // our EnemyMovement component will not work without Enemy Component.
public class EnemyMovement_Test : MonoBehaviour
{
    private Enemy enemy;

    public Transform target;
    public int wavepointIndex = 0;

    Waypoints_New waypoints_new;

    void Start()
    {
        enemy = GetComponent<Enemy>();

        target = target.GetChild(wavepointIndex);
        //target = waypoints_new.waypoints[wavepointIndex]; // pursuing the first waypoint with the index of zero to be equal to target.
    }

    void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * enemy.movingSpeed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, target.position) <= 0.1f)
        {
            MoveToNextWaypoint();
        }

        enemy.movingSpeed = enemy.startSpeed;

    }

    private void MoveToNextWaypoint()
    {
        if (wavepointIndex >= target.childCount) // if reached the destination.
        {
            EndPath();
            return;
        }

        wavepointIndex++;
        target = target.GetChild(wavepointIndex);
    }

    private void EndPath()
    {
        PlayerStats.Lives--;

        Destroy(gameObject);
    }
}
