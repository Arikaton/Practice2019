using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] List<WaveConfig> waveConfigs;
    [SerializeField] int startingWave = 0;
    [SerializeField] bool looping = false;

    IEnumerator Start()
    {
        do
        {
            yield return StartCoroutine(SpawnAllWave());
        } while (looping);
    }

    private IEnumerator SpawnAllWave()
    {
        for (int waveCount = startingWave; waveCount < waveConfigs.Count; waveCount++)
        {
            var currentWave = waveConfigs[waveCount];
            yield return StartCoroutine(SpawnAllEnemiesInWave(currentWave));
        }
    }

    private IEnumerator SpawnAllEnemiesInWave(WaveConfig wave)
    {
        for (int i = 0; i < wave.GetNumberOfEnemies(); i++)
        {
            var newEnemy = Instantiate(wave.GetEnemyPrefab(),
                        wave.GetWayPoints()[0].transform.position,
                        Quaternion.identity);
            newEnemy.GetComponent<EnemyPathing>().SetWaveConfig(wave);
            yield return new WaitForSeconds(wave.GetTimeBetweenSpawns());
        }
    }
}
