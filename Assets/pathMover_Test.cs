using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pathMover_Test : MonoBehaviour
{
    public float movingSpeed = 2f;

    [SerializeField] public List<Transform> waypoints;
    //public Paths paths;
    private Transform currentWaypoint;
    //public WaveSpawner_Test waveSpawner;
    //public Transform enemyPath;
    //public Enemy_Test[] enemies;
    //public Enemy_Test enemy;
    public int waypointIndex = 0;
    public int moveSpeed = 2;

    private void Awake()
    {
        
    }

    void Start()
    {
        transform.position = waypoints[waypointIndex].transform.position;
    }

    private void Update()
    {
        if (waypointIndex <= waypoints.Count - 1)
        {
            var targetPosition = waypoints[waypointIndex].transform.position;
            var movementThisFrame = moveSpeed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, movementThisFrame);

            if (transform.position == targetPosition)
            {
                waypointIndex++;
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }


    // ---------------------------------------------------------------------------------------------------------------------------------------------------------------------



    // ---------------------------------------------------------------------------------------------------------------------------------------------------------------------

    /*        private void Awake()
            {
                if (paths == null) { return; }
            }*/

    /*        void Start()
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

    /*    public void Initialize(Paths paths)
        {
            this.paths = paths;
        }*/



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
