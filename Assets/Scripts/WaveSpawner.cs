using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class WaveSpawner : MonoBehaviour
{

    // transform:
    public Transform enemyPrefab;
    public Transform spawnPoint;
    // Waves & Timers:
    public float upcomingWaveDelay = 5f;
    private float countdown = 2f;
    private float enemySpawnDelay = 0.5f; // delay in seconds for each enemy to spawn on wave
    private int waveIndex = 0;
    //
    public TMP_Text waveCountdownText;

    void Update()
    {
        if(countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countdown = upcomingWaveDelay;
        }

        countdown -= Time.deltaTime;

        waveCountdownText.text = Mathf.Round(countdown).ToString(); // round to the nearest whole number;
    }

    IEnumerator SpawnWave()
    {
        waveIndex++;

        for(int i = 0; i < waveIndex; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(enemySpawnDelay);
        }

        Debug.Log("Incoming Wave!");
    }

    private void SpawnEnemy()
    {
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}
