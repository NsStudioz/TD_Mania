using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pathMover_Test : MonoBehaviour
{
    public float movingSpeed = 2f;

    
    //public Paths paths;
    private Transform currentWaypoint;
    public WaveSpawner_Test thisPaths;
    public Transform enemyPath;
    //public Enemy_Test[] enemies;
    //public Enemy_Test enemy;
    public int waypointIndex;
    

    //public List<Enemy_Test> enemyCount = new List<Enemy_Test>();
    //public List<Transform> enemyCount = new List<Transform>();
    /*    Enemy_Test enemy_test;
        Waypoints_New waypoints_New;
        private Transform target;
        public int waypointIndex;
        public float movingSpeed = 0.5f;

        private void Start()
        {
            waypointIndex = 0;

            enemy_test = GetComponent<Enemy_Test>();

            target = Waypoints_New.waypoints_new[0];
        }

        private void Update()
        {
            Vector3 dir = target.position - transform.position;
            transform.Translate(dir.normalized * movingSpeed * Time.deltaTime, Space.World);

            if (Vector3.Distance(transform.position, target.position) <= 0.1f)
            {
                MoveToNextWaypoint();
            }

        }


        private void MoveToNextWaypoint()
        {
            if (waypointIndex == Waypoints_New.waypoints_new.Length - 1) // if reached the destination.
            {
                EndPath();
                return;
            }

            waypointIndex++;
            target = Waypoints_New.waypoints_new[waypointIndex];
        }

        private void EndPath()
        {
            Destroy(gameObject);
        }*/


    // ---------------------------------------------------------------------------------------------------------------------------------------------------------------------

    /*    void Start()
        {
            foreach (Transform e in enemyCount)
            {

                if (e == null)
                {
                    return;
                }

                currentWaypoint = paths.GetToNextWaypoint(currentWaypoint);
                e.transform.position = currentWaypoint.position;

            }

        }

        void Update()
        {
            foreach (Transform e in enemyCount)
            {

                enemyCount.Add(e);

                if (e.transform.position == null)
                {
                    return;
                }

                e.transform.position = Vector3.MoveTowards(e.transform.position, currentWaypoint.position, movingSpeed * Time.deltaTime);

                if (Vector3.Distance(e.transform.position, currentWaypoint.position) <= 0.1f)
                {
                    currentWaypoint = paths.GetToNextWaypoint(currentWaypoint);
                }
            }

        }*/

    // ---------------------------------------------------------------------------------------------------------------------------------------------------------------------

        private void Awake()
        {
            if (thisPaths == null) { return; }
        }

        void Start()
        {
            currentWaypoint = thisPaths.GetToNextWaypoint(currentWaypoint);
            transform.position = currentWaypoint.position;
        }

        void Update()
        {
            transform.position = Vector3.MoveTowards(transform.position, currentWaypoint.position, movingSpeed * Time.deltaTime);

            if (Vector3.Distance(transform.position, currentWaypoint.position) <= 0.1f)
            {
                currentWaypoint = thisPaths.GetToNextWaypoint(currentWaypoint);
            }

        }

    // ---------------------------------------------------------------------------------------------------------------------------------------------------------------------
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
