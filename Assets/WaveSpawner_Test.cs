using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner_Test : MonoBehaviour
{
    // Objects
    //public TMP_Text waveCountDownText;
    public Transform enemyPrefab;
    public Transform spawnPoint;
    // Waves & Timers:
    public float upcomingWaveDelay = 5f;
    private float countDown = 2f;
    private float enemySpawnDelay = 0.5f; // delay in seconds for each enemy to spawn during wave.
    private int waveIndex = 0;

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
            SpawnEnemy();
            yield return new WaitForSeconds(enemySpawnDelay);
        }

        Debug.Log("Incoming wave");
    }

    private void SpawnEnemy()
    {
        Transform enemyprefabInstance = Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }

}
