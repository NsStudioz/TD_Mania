using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyMove_Test : MonoBehaviour
{

    //private Paths paths;
    private Enemy_Test enemyConfig;
/*    public WaveSpawner_Test waveSpawner;
    public Transform currentWaypoint;*/
    //public int waypointIndex;

    private string waveSpawnerTag = "WaveSpawner";
    private float range = 3f;
    //
    public Paths paths;
    //public Transform target;
    public int waypointIndex = 0;


    private void Start()
    {
        transform.position = paths.waypoints[waypointIndex].transform.position;
    }

    private void Update()
    {
        if (waypointIndex >= paths.waypoints.Count - 1) // if reached the destination.
        {
            Destroy(gameObject);
            return;
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, paths.waypoints[waypointIndex].transform.position, enemyConfig.movingSpeed * Time.deltaTime);

            if (Vector3.Distance(transform.position, paths.waypoints[waypointIndex].position) <= 0.1f)
            {
                waypointIndex++;
                transform.position = paths.waypoints[waypointIndex].transform.position;
            }
        }

    }

    private void NewStart()
    {
        GameObject[] waveSpawners = GameObject.FindGameObjectsWithTag(waveSpawnerTag);

        float shortestSpawnerDistance = Mathf.Infinity;
        GameObject nearestWaveSpawner = null;

        foreach (GameObject spawner in waveSpawners)
        {
            float distanceToSpawner = Vector3.Distance(transform.position, spawner.transform.position); // set the distance to enemy.

            if (distanceToSpawner < shortestSpawnerDistance)
            {
                shortestSpawnerDistance = distanceToSpawner;
                nearestWaveSpawner = spawner;
            }
        }

        if (nearestWaveSpawner != null && shortestSpawnerDistance <= range)
        {

            //waveSpawner = nearestWaveSpawner.GetComponent<WaveSpawner_Test>();
/*            currentWaypoint = waveSpawner.GetToNextWaypoint(currentWaypoint);
            transform.position = currentWaypoint.position;*/
            //currentWaypoint = nearestWaveSpawner.transform;
        }
        //else { currentWaypoint = null; }

    }


    /*    void Start()
        {
            currentWaypoint = paths.GetToNextWaypoint(currentWaypoint);
            transform.position = currentWaypoint.position;
        }

        void Update()
        {
            transform.position = Vector3.MoveTowards(transform.position, currentWaypoint.position, movingSpeed * Time.deltaTime);

            if (Vector3.Distance(transform.position, currentWaypoint.position) <= 0.1f)
            {
                currentWaypoint = paths.GetToNextWaypoint(currentWaypoint);
            }

        }*/
}
