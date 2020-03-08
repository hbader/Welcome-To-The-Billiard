using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawnerControl : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject[] monsters;

    int randomSpawnpoint, randomMonster;
    public static bool spawnAllowed;

    private void Start()
    {
        spawnAllowed = true;
        InvokeRepeating("spawnAnEnemy", 0f, 1f);
    }

    private void spawnAnEnemy()
    {
        if (spawnAllowed)
        {
            randomSpawnpoint = Random.Range(0, spawnPoints.Length);
            randomMonster = Random.Range(0, monsters.Length);
            Instantiate(monsters[randomMonster], spawnPoints[randomSpawnpoint].position, Quaternion.identity);
        }
    }
}

