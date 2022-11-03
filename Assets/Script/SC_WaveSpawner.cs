using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_WaveSpawner : MonoBehaviour
{
    [Header("Waves options")]
    [SerializeField] private Transform enemyPrefab;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private float timeBetweenWaves = 5f;
    [SerializeField] private float timer = 2f;
    [SerializeField] private int waveIndex = 0;


    void Update()
    {
        if(timer <= 0)
        {
            StartCoroutine(SpawnWave());
            timer = timeBetweenWaves;
        }

        timer -= Time.deltaTime;
    }

    IEnumerator SpawnWave()
    {
        Debug.Log("Invocation d'une nouvelle vague de méchants");
        waveIndex++;
        for (int i = 0; i < waveIndex; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(0.5f);
        }
    }

    void SpawnEnemy()
    {
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}
