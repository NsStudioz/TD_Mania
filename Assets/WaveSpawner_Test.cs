using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class WaveSpawner_Test : MonoBehaviour
{
    // Objects
    //public TMP_Text waveCountDownText;
    
    //
    public Transform enemyPrefab;
    public GameObject enemyPrefabGO;
    private GameObject[] enemiesPrefabInstances;
    public Transform spawnPoint;
    // Waves & Timers:
    public float upcomingWaveDelay = 5f;
    private float countDown = 2f;
    private float enemySpawnDelay = 0.5f; // delay in seconds for each enemy to spawn during wave.
    private int waveIndex = 0;
    pathMover_Test pathMover;
    public string enemyTag = "Attackers";

    // testings!:
    //public Paths paths;
    //public pathMover_Test pathMover_test;
    private Transform currentWaypoint;
    //public List<Transform> wayPoints = new List<Transform>();
    //public List<GameObject> wayPointsGOList = new List<GameObject>();
    //public List<GameObject> enemyTransformsList = new List<GameObject>();
    //public List<GameObject> enemyTransformsList = new List<GameObject>();

    public Transform GetWaveSpawnerTransform()
    {
        return transform;
    }

    void Start()
    {
        
    }

    void Update()
    {

        if (countDown == 0f)
        {
            StartCoroutine(SpawnWave());
            countDown = upcomingWaveDelay;
        }

        countDown -= Time.deltaTime;

        countDown = Mathf.Clamp(countDown, 0f, Mathf.Infinity);

        //waveCountDownText.text = string.Format("{0:00.00}", countDown); // convert to actual watch like, real world time format.
    }

/*    private void BlaUpdateNew()
    {
        foreach(GameObject enemy in enemyTransformsList)
        {
            GameObject target = wayPointsGOList[0];
            int waypointIndex = 0;

            Vector3 dir = target.transform.position - enemy.transform.position;

            transform.Translate(dir.normalized * 0.5f * Time.deltaTime, Space.World);

            if (Vector2.Distance(enemy.transform.position, target.transform.position) <= 0.1f)
            {
                if (waypointIndex >= wayPoints.Count - 1)
                {
                    Destroy(enemy.gameObject);
                    enemyTransformsList.Remove(enemy);
                }
                else
                {
                    waypointIndex++;
                    target.transform.position = wayPoints[waypointIndex].position;
                }
            }


        }
    }

    private void BlaUpdate()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);

        foreach (GameObject enemy in enemies)
        {
            Transform countedEnemy = enemy.transform;
            countedEnemy = GetComponent<Transform>();

            Transform target = wayPoints[0];
            int waypointIndex = 0;

            Vector3 dir = target.position - countedEnemy.transform.position;

            transform.Translate(dir.normalized * 0.5f * Time.deltaTime, Space.World);

            if (Vector2.Distance(countedEnemy.transform.position, target.position) <= 0.1f)
            {
                if(waypointIndex >= wayPoints.Count - 1)
                {
                    Destroy(countedEnemy.gameObject);
                }
                else
                {
                    waypointIndex++;
                    target.position = wayPoints[waypointIndex].position;
                }
            }
        }
    }*/


    IEnumerator SpawnWave()
    {
        waveIndex++;
        PlayerStats.Rounds++;

        for (int i = 0; i < waveIndex; i++)
        {
            //SpawnEnemy();
            CreateEnemyObjectWithScript(enemyPrefabGO, pathMover);
            //enemyTransformsList.Add(enemyPrefabGO);

            yield return new WaitForSeconds(enemySpawnDelay);
        }

        Debug.Log("Incoming wave");
    }

    private void SpawnEnemy()
    {
        Transform enemyprefabInstance = Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);

    }

    void CreateEnemyObjectWithScript (GameObject prefabName, pathMover_Test pathmover)
    {
        //enemyPrefabGO = prefabName;

        //GameObject prefabIns = Instantiate(prefabName, spawnPoint.position, spawnPoint.rotation);
        var prefabIns = Instantiate(prefabName, spawnPoint.position, spawnPoint.rotation);
        pathmover.waypoints.Add(transform);



        //prefabIns.AddComponent<pathMover_Test>();
    }

    public void CheckEnemyandAssignTransform()
    {

    }

    public void PrefabInstanceNavTracking()
    {

        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        GameObject enemyInstance = null;

        foreach (GameObject enemy in enemies)
        {
            enemyInstance = enemy;
            var prefabTransform = GetComponent<Transform>();
            enemyInstance.transform.position = prefabTransform.transform.position;

            //enemyInstance.AddComponent<pathMover_Test>();
            //currentWaypoint = paths.GetToNextWaypoint(currentWaypoint);

            if (enemyInstance == null)
            {
                return;
            }

            //enemyInstance.transform.position = currentWaypoint.position;

            enemyInstance.transform.position = Vector3.MoveTowards(enemyInstance.transform.position, currentWaypoint.position, 0.2f * Time.deltaTime);

            if (Vector3.Distance(transform.position, currentWaypoint.position) <= 0.1f)
            {
                //currentWaypoint = paths.GetToNextWaypoint(currentWaypoint);
            }

        }

    }

    // Testing purposes:


}
