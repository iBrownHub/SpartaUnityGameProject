using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
    public Transform enemyPrefab;
    public Transform spawnPoint;
    public Text waveCountdownText;
    public Text waveIndexText;
    public Text currencyText;
    public static int currency = 100;
    public float timeBetweenWaves = 4f;
    private float countdown = 3f;
    public static int waveIndex = 0;
    private int enemyCount = 5;

    private void Update()
    {
        if (countdown <= 0)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves * waveIndex;
        }
        countdown -= Time.deltaTime;
        waveCountdownText.text = Mathf.Floor(countdown + 1).ToString();
        waveIndexText.text = waveIndex.ToString();
        currencyText.text = currency.ToString();
    }

    IEnumerator SpawnWave()
    {
        waveIndex++;
        Enemy.waveIndexToHealth = waveIndex;
        for (int i = 0; i < waveIndex*enemyCount; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(0.5f);
        }
    }

    private void SpawnEnemy()
    {
        Instantiate(enemyPrefab,spawnPoint.position, spawnPoint.rotation);
    }
}
