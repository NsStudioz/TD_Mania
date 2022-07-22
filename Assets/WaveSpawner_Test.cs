using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner_Test : MonoBehaviour
{
    // Objects
    public Transform enemyPrefab;
    public Transform spawnPoint;
    // Waves & Timers:
    public float upcomingWaveDelay = 5f;
    private float countDown = 2f;
    private float enemySpawnDelay = 0.5f; // delay in seconds for each enemy to spawn during wave.
    private int waveIndex = 0;

    public static Transform[] waypoints;
            
    void Awake()
    {
        waypoints = new Transform[transform.childCount];

        for (int i = 0; i < waypoints.Length; i++)
        {
            waypoints[i] = transform.GetChild(i);
        }
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
    }

    IEnumerator SpawnWave()
    {
        waveIndex++;
        PlayerStats.Rounds++;

        for (int i = 0; i < waveIndex; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(enemySpawnDelay);
        }

        Debug.Log("Incoming wave");
    }
    private void SpawnEnemy()
    {
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}
