using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

public class SC_WaveSpawner : MonoBehaviour
{
    [Header("Waves options")]
    [SerializeField] private Transform enemyPrefab;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private TMP_Text waveTimerText;
    [Tooltip("Always make sure the time betweens wave is rounded at 0.5")]
    [TextArea] public string waveTextTip;
    //[InspectorTextArea] public string waveTip2;
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
        waveTimerText.text = Mathf.Round(timer).ToString(); // Round better to Floor, cause 30 fps unity, too fast for this
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
