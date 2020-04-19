using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public enum SpawnState { SPAWNING, WAITING, COUNTING };

   [System.Serializable]
   public class Wave
    {
        public string name;
        public Transform enemy;
        public int count;
        public float rate;

    }

    public Wave[] waves;
    private int nextWave = 0;
    public Transform[] spawnPoints;

    public float timeBetweenWaves = 5f;
    public float waveCountdown;
    

    public float searchCountdown = 1f;

    private SpawnState state = SpawnState.COUNTING;

    public void Start()
    {
        if (spawnPoints.Length == 0)
        {
            Debug.LogError("No Spawn points referenced");
        }
        waveCountdown = timeBetweenWaves;
    }

    void Update()
    {
        if (state == SpawnState.WAITING)
        {
            //check if enemies are alive
            if (!EnemyIsAlive())
            {
                //complete current and begin new round                
                WaveCompleted();                
                //TODO: can add loot/exp/etc
            }
            else
            {
                return;
            }
        }

        if(waveCountdown <= 0)
        {
            if (state != SpawnState.SPAWNING)
            {
                //start spawning
                StartCoroutine( SpawnWave( waves[nextWave] ) );
            }
        }
        else
        {
            waveCountdown -= Time.deltaTime;
        }
    }

    void WaveCompleted()
    {
        Debug.Log("Wave Completed!");

        state = SpawnState.COUNTING;
        waveCountdown = timeBetweenWaves;

        if (nextWave + 1 > waves.Length - 1)
        {
            nextWave = 0;
            Debug.Log("Completed all waves");
            //TODO: Send to complete menu
            //TODO: Add Stat multiplier.
        }
        else
        {
            nextWave++;
        }

        
    }

    bool EnemyIsAlive()
    {
        searchCountdown -= Time.deltaTime;
        if (searchCountdown <= 0f)
        {
            searchCountdown = 1f;
            if (GameObject.FindGameObjectWithTag("Enemy") == null)
            {
                return false;
            }
        }
        
        return true;

    }

    IEnumerator SpawnWave (Wave _wave)
    {
        Debug.Log("Spawning wave: " + _wave.name);

        state = SpawnState.SPAWNING;
        //spawn shit
         for(int i = 0; i <_wave.count; i++)
        {
            SpawnEnemy(_wave.enemy);
            yield return new WaitForSeconds(1f/_wave.rate);
        }

        state = SpawnState.WAITING;

        yield break;
    }

    void SpawnEnemy(Transform _enemy)
    {
        //Spawn Enemy
        Debug.Log("Spawning Enemy: " + _enemy.name);

        
        Transform _sp = spawnPoints[Random.Range(0, spawnPoints.Length)];
        Instantiate(_enemy, _sp.position, _sp.rotation);
        
    }
}
