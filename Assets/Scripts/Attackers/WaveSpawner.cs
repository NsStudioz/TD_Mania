using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class WaveSpawner : MonoBehaviour
{

    [Header("Objects:")]
    [SerializeField] private Transform enemyPrefab;
    [SerializeField] private Transform spawnPoint;

    [Header("Waves:")]
    [SerializeField] private int waveIndex = 0;
    [SerializeField] private int enemiesPerWave = 10; // for enemy spawner static type.

    [Header("Timers:")]
    [SerializeField] private float countDown = 2f;         // during beginning of game:
    [SerializeField] private float upcomingWaveDelay = 5f; // wave spawn cooldown.
    [SerializeField] private float enemySpawnDelay = 0.5f; // delay in seconds for each enemy to spawn during a single wave.

    [Header("Spawner Types:")]
    [SerializeField] private bool EnemySpawner_Single = false;
    [SerializeField] private bool EnemySpawner_Static = false;
    [SerializeField] private bool EnemySpawner_Incrementer = false;

    void Update()
    {
        if(GamePlay_Manager.GetGameOver() || GamePlay_Manager.GetGameWon())
            return;

        if(!EnemySpawner_Single & !EnemySpawner_Static && !EnemySpawner_Incrementer)
            return;


        if (countDown == 0f)
        {
            HandleSpawning();

            countDown = upcomingWaveDelay;
        }

        countDown -= Time.deltaTime;

        countDown = Mathf.Clamp(countDown, 0f, Mathf.Infinity);
    }

    private void HandleSpawning()
    {
        if (EnemySpawner_Single)
            StartCoroutine(SpawnWave_Single());
        else if (EnemySpawner_Static)
            StartCoroutine(SpawnWave_Static());
        else if (EnemySpawner_Incrementer)
            StartCoroutine(SpawnWave_Incrementer());
    }

    private void SpawnEnemy()
    {
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }

    // increments amount of enemies by 1 each wave:
    IEnumerator SpawnWave_Incrementer()
    {
        waveIndex++;

        for(int i = 0; i< waveIndex; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(enemySpawnDelay);
        }
    }

    // Spawns X amount of enemies per wave:
    IEnumerator SpawnWave_Static()
    {
        for (int i = 0; i < enemiesPerWave; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(enemySpawnDelay);
        }  
    }

    // Spawns a single enemy per wave:
    IEnumerator SpawnWave_Single()
    {
        SpawnEnemy();
        yield return null;
    }

}
