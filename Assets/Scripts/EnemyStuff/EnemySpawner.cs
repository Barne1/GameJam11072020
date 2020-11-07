using System;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    private int activeEnemies;
    private int amountOfEnemies;
    private float spawnCountdown = 1f;

    private void Start()
    {
    }

    private void Update()
    {
        if (TimeToSpawn() && activeEnemies < 5) //lmao hard code
        {
            SpawnEnemies();
        }
    }

    private void SpawnEnemies()
    {
        Debug.Log("Lmao spawning");
        ObjectPool.Instance.SpawnFromPool("Enemy", transform.position, Quaternion.identity);
        activeEnemies++;

    }

     bool TimeToSpawn()
    {
        spawnCountdown -= Time.deltaTime;
        if (spawnCountdown <= 0f)
        {
            spawnCountdown = 1f;
            return true;
        }
        return false;
    }
}