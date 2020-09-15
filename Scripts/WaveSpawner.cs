using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public static WaveSpawner instance;

    public GameObject waypointsSystems;

    public GameObject [] wayPointMid;
    
    public GameObject[] currentWave;

    public Transform spawnpoint;

    public float currentTime;
    public int counter;
    public bool spawning;

    public int waveCounter;

    public bool isMidtower;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        currentWave = WaveManager.instance.waves[WaveManager.instance.waveNumber];
    }
    private void Update()
    {
        if (spawning) 
        {
            if(waveCounter < currentWave.Length) 
            {
                SpawnWave();
            }
            else 
            {
                spawning = false;
                waveCounter = 0;
                GameManager.instace.isSpawning = false;
                
            }
        }
            
    }
    public void SpawnWave() 
    {
        if (currentTime < counter)
            currentTime += Time.deltaTime;
        else 
        {
            SpawnEnemy();
            currentTime = 0;
        }
    }
    
    public void SpawnEnemy() 
    {
        GameObject enemy = (GameObject)Instantiate(currentWave[waveCounter], spawnpoint.position, spawnpoint.rotation);
        if (isMidtower) 
        {
            int random = Random.Range(0, wayPointMid.Length);
            enemy.GetComponent<EnemyMovement>().waypointParent = wayPointMid[random];
        }
        else 
        {
            enemy.GetComponent<EnemyMovement>().waypointParent = waypointsSystems;
        }
        waveCounter++;
        GameManager.instace.enemySpawnCount++;
    }

}
