using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class WaveSpawner : MonoBehaviour
{

    [Header("Objects:")]
    //public TMP_Text waveCountDownText;
    //[SerializeField] TMP_Text masterTimer_Text;
    [SerializeField] Transform enemyPrefab;
    [SerializeField] Transform spawnPoint;

    [Header("Waves:")]
    [SerializeField] int waveIndex = 0;
    [SerializeField] int enemiesPerWave = 10; // for enemy spawner static type.

    [Header("Timers:")]
    [SerializeField] float masterTimer = 30f;
    //
    [SerializeField] float countDown = 2f;         // during beginning of game:
    [SerializeField] float upcomingWaveDelay = 5f; // wave spawn cooldown.
    [SerializeField] float enemySpawnDelay = 0.5f; // delay in seconds for each enemy to spawn during a single wave.

    [Header("Spawner Types:")]
    [SerializeField] bool EnemySpawner_Single = false;
    [SerializeField] bool EnemySpawner_Static = false;
    [SerializeField] bool EnemySpawner_Incrementer = false;

    void Update()
    {
        if(!EnemySpawner_Single & !EnemySpawner_Static && !EnemySpawner_Incrementer)
        {
            return;
        }

        if (countDown == 0f)
        {
            if (EnemySpawner_Single)
            {
                StartCoroutine(SpawnWave_Single());
            }

            else if (EnemySpawner_Static)
            {
                StartCoroutine(SpawnWave_Static());
            }

            else if(EnemySpawner_Incrementer)
            {
                StartCoroutine(SpawnWave_Incrementer());
            }

            countDown = upcomingWaveDelay;
        }

        countDown -= Time.deltaTime;

        countDown = Mathf.Clamp(countDown, 0f, Mathf.Infinity);

        //waveCountDownText.text = string.Format("{0:00.00}", countDown); // convert to actual watch like, real world time format.
    }

    IEnumerator SpawnWave_Incrementer()
    {
        waveIndex++;
        PlayerStats.Rounds++;

        for(int i = 0; i< waveIndex; i++)
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

    // new Enemy Spawner Functions:
    IEnumerator SpawnWave_Static()
    {
        for (int i = 0; i < enemiesPerWave; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(enemySpawnDelay);
        }  
    }

    IEnumerator SpawnWave_Single()
    {
        SpawnEnemy();
        yield return null;
    }



    #region Backup:
/*            if (countDown == 0f)
            {
                StartCoroutine(SpawnWave());
                countDown = upcomingWaveDelay;
            }

            countDown -= Time.deltaTime;

            countDown = Mathf.Clamp(countDown, 0f, Mathf.Infinity);*/

            //waveCountDownText.text = string.Format("{0:00.00}", countDown); // convert to actual watch like, real world time format.
    #endregion
}
