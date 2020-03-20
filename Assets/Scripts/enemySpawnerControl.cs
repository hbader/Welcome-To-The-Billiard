using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enemySpawnerControl : MonoBehaviour
{
    public enum SpawnState { SPAWNING, WAITING, COUNTING };

    [System.Serializable]
    public class Wave
    {
        public string name;
        public GameObject[] monsters;
        public int count;
        public float rate;
    }

    public Transform[] spawnPoints;
    public Wave[] waves;
    public GameObject child;
    private int nextWave = 0;
    private SpawnState state = SpawnState.COUNTING;

    public float timeBetweenWaves = 5f;
    private float waveCountDown;
    private float searchCountdown = 1f;


    int randomSpawnpoint, randomMonster;
    private GameObject monster;
    private GameObject attatchedChild;

    private void Start()
    {
        waveCountDown = timeBetweenWaves;
    }

    private void Update()
    {
        if (state == SpawnState.WAITING)
        {
            Debug.LogError("Waiting Working");
            if (TwentyPercentRemain())
            {
                WaveCompleted();
            }
            else
            {
                return;
            }
        }

        if (waveCountDown <= 0)
        {
            if (state != SpawnState.SPAWNING)
            {
                StartCoroutine(SpawnWave(waves[nextWave]));
            }
        }
        else
        {
            waveCountDown -= Time.deltaTime;
        }
    }

    void WaveCompleted()
    {
        Debug.Log("Wave Completed!");

        state = SpawnState.COUNTING;
        Debug.LogError("State: Counting");
        waveCountDown = timeBetweenWaves;

        if(nextWave+1 > waves.Length - 1)
        {
            nextWave = 0;
            Debug.Log("ALL WAVES COMPLETE! Looping...");
        }
        else
        {
            nextWave++;
        }
    }

    private bool TwentyPercentRemain()
    {
        searchCountdown -= Time.deltaTime;
        if (searchCountdown <= 0f)
        {
            searchCountdown = 1f;
            return (GameObject.FindGameObjectsWithTag("Enemy").Length <= waves[nextWave].count * .2f);
        }
        return false;
    }

    IEnumerator SpawnWave(Wave _wave)
    {
        state = SpawnState.SPAWNING;

        for (int i = 0; i < _wave.count; i++)
        {
            SpawnEnemy(_wave.monsters);
            yield return new WaitForSeconds(1f / _wave.rate);
        }

        state = SpawnState.WAITING;
        Debug.LogError("State Waiting");
        yield break;
    }

    void SpawnEnemy(GameObject[] _enemies)
    {
        randomSpawnpoint = Random.Range(0, spawnPoints.Length);
        randomMonster = Random.Range(0, _enemies.Length);
        monster = Instantiate(_enemies[randomMonster], spawnPoints[randomSpawnpoint].position, Quaternion.identity);
        attatchedChild = Instantiate(child, spawnPoints[randomSpawnpoint].position, Quaternion.identity);

        attatchedChild.transform.parent = monster.transform;
        Debug.LogError("Enemy Spawned");
    }
}

