using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public Enemy enemyPrefab;
    public WaveEnemySO waveData;
    public List<Path> allPath;
    public List<EnemySO> allData;

    public float timeCurrent = 0;
    public int waveIndex = 0;
    public WaveEnemy waveCurrent;
    public WaveEnemy waveNext;

    private void Start()
    {
        waveCurrent = waveData.waves[0];
        waveNext = waveData.waves[1];

        SpawnWave(waveCurrent);
    }
    private void Update()
    {
        if (waveNext == null) return;
        if (timeCurrent > waveNext.TimeSpawn)
        {
            waveCurrent = waveNext;
            SpawnWave(waveCurrent);

            if (waveIndex + 1 >= waveData.waves.Count)
            {
                waveNext = null;
                return;
            }
            waveNext = waveData.waves[waveIndex + 1];
            waveIndex = waveIndex + 1;
        }
        timeCurrent += Time.deltaTime;
    }

    private void SpawnWave(WaveEnemy data)
    {
        StartCoroutine(SpawnEnemyIE(data));
    }

    private IEnumerator SpawnEnemyIE(WaveEnemy data)
    {
        for (int i = 0; i < data.Amount; i++)
        {
            Enemy enemy = Instantiate(enemyPrefab);
            enemy.movement.SetPath(allPath[Random.Range(0, allPath.Count)]);
            enemy.SetData(allData[Random.Range(0, allData.Count)]);
            enemy.Init();
            yield return new WaitForSeconds(0.2f);
        }
    }
}
