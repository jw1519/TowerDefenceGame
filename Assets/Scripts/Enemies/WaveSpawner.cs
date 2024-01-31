using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public Transform enemyPrefab;
    public float timeBetweenWaves = 5f;
    private float countdown = 2f;
    public int WaveNumber = 0;
    public Transform Spawnpoint;
    public Transform Enemy;

    private void Update()
    {
        if (countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
        }
        countdown -= Time.deltaTime;
    }

    IEnumerator SpawnWave()
    {
        for (int i = 0; i < WaveNumber; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(1f);
        }
        WaveNumber++;
    }
    void SpawnEnemy()
    {
        Instantiate(enemyPrefab, Spawnpoint.position, Spawnpoint.rotation);
        enemyPrefab.transform.SetParent(Enemy);
    }
    //SpawnFromPool("Enemy", pawnpoint.position, Quaternion.identity);
}
