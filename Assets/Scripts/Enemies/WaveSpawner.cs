using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WaveSpawner : MonoBehaviour
{
    public Transform enemyPrefab;
    public float timeBetweenWaves = 5f;
    private float countdown = 4f;
    public int WaveNumber = 0;
    public Transform Spawnpoint;
    public Transform EndPoint;
    public Transform enemy;

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
            yield return new WaitForSeconds(10f);
        }
        WaveNumber++;
    }
    void SpawnEnemy()
    {
        GameObject spawnedEnemy = EnemyPool.instance.SpawnFromPoolEnemy("Enemy", Spawnpoint.position, Quaternion.identity); //change for different enemies
        spawnedEnemy.GetComponent<NavMeshAgent>().enabled = true;
        spawnedEnemy.transform.SetParent(enemy);
        spawnedEnemy.GetComponent<NavMeshAgent>().destination = EndPoint.position;
    }

}
