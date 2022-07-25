using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner_Test : MonoBehaviour
{
    // Objects
    //public TMP_Text waveCountDownText;
    public Transform enemyPrefab;
    public GameObject enemyPrefabGO;
    public Transform spawnPoint;
    // Waves & Timers:
    public float upcomingWaveDelay = 5f;
    private float countDown = 2f;
    private float enemySpawnDelay = 0.5f; // delay in seconds for each enemy to spawn during wave.
    private int waveIndex = 0;
    pathMover_Test pathMover;
    Paths paths;

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

    IEnumerator SpawnWave()
    {
        waveIndex++;
        PlayerStats.Rounds++;

        for (int i = 0; i < waveIndex; i++)
        {
            //SpawnEnemy();
            CreateEnemyObjectWithScript(enemyPrefabGO, pathMover);
            yield return new WaitForSeconds(enemySpawnDelay);
        }

        Debug.Log("Incoming wave");
    }

    private void SpawnEnemy()
    {
        Transform enemyprefabInstance = Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
        //pathMover.enemyCount.Add(enemyprefabInstance);

        //enemyprefabInstance = gameObject.AddComponent(typeof(pathMover_Test)) as pathMover_Test;
        //Enemy_Test ET = gameObject.AddComponent
    }

    void CreateEnemyObjectWithScript (GameObject prefabName, pathMover_Test pathmover)
    {
        enemyPrefabGO = prefabName;

        GameObject prefabIns = Instantiate(prefabName, spawnPoint.position, spawnPoint.rotation);
        prefabIns.AddComponent<pathMover_Test>();
    }

    public void PathFinding()
    {

    }

}
