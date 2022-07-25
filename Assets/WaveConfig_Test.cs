using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveConfig_Test : MonoBehaviour
{

    [SerializeField] GameObject enemyPrefab;
    //[SerializeField] float enemySpeed;

    Enemy_Test enemyTest;
    //Waypoints_New newWaypointPath;

    //public Transform target;

    //
    [SerializeField] private Paths paths;
    private Transform currentWaypoint;

/*    private void Start()
    {
        enemyTest = GetComponent<Enemy_Test>();

        target = newWaypointPath.waypoints[0];
    }*/

/*    private void Update()
    {
        Vector3 dir = target.position - enemyPrefab.transform.position;
        transform.Translate(dir.normalized * enemyTest.movingSpeed * Time.deltaTime, Space.World);

        if (Vector3.Distance(enemyPrefab.transform.position, target.position) <= 0.1f)
        {
            MoveToNextWaypoint();
        }

        enemyTest.movingSpeed = enemyTest.startSpeed;
    }

    public void MoveToNextWaypoint()
    {
        if (enemyTest.waypointIndex >= newWaypointPath.waypoints.Length - 1) // if reached the destination.
        {
            EndPath();
            return;
        }

        enemyTest.waypointIndex++;
        enemyPrefab.transform.position = target.transform.position;
    }

    private void EndPath()
    {
        PlayerStats.Lives--;

        Destroy(gameObject);
    }*/


    // tests:
/*    public Transform GetToNextWaypoint(Transform currentWaypoint)
    {
        return currentWaypoint;
    }*/

    void Start()
    {
        currentWaypoint = paths.GetToNextWaypoint(currentWaypoint);
        enemyPrefab.transform.position = currentWaypoint.position;

        currentWaypoint = paths.GetToNextWaypoint(currentWaypoint);
    }

    void Update()
    {
        enemyPrefab.transform.position = Vector3.MoveTowards(enemyPrefab.transform.position, currentWaypoint.position, enemyTest.movingSpeed * Time.deltaTime);
        if(Vector3.Distance(enemyPrefab.transform.position, currentWaypoint.position) < 0.1f)
        {
            currentWaypoint = paths.GetToNextWaypoint(currentWaypoint);
        }
    }

}
