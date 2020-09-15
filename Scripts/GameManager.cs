using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    public static GameManager instace;

    public GameObject confetti;
    public GameObject winText;

    public GameObject dragon;
    public GameObject loseText;

    public int waveCounter;
    public int maxWaveCount;

    public int enemySpawnCount;
    public int enemyDied;

    public float enemySpeed;

    public GameObject[] spawners;

    public float spawnTime;
    public float counter;

    public bool isSpawning;
    public bool incremented;
    public bool waveStarted;

    public bool difficultyIncreased;
    public int waveIndex;

    public bool gameOver;

    public Button spawnButton;
    private void Awake()
    {
        instace = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 4;
    }

    // Update is called once per frame
    void Update()
    {


        if (!gameOver) 
        {
            if (!isSpawning && waveStarted)
            {
                if (waveCounter < maxWaveCount)
                {
                    if (counter < spawnTime)
                        counter += Time.deltaTime;
                    else
                    {
                        counter = 0;
                        isSpawning = true;
                        SpawnEnemies();
                    }
                }

            }

            if (enemySpawnCount == enemyDied && enemySpawnCount != 0 && enemyDied != 0)
            {
                if (!difficultyIncreased && WaveManager.instance.waveNumber < 10)
                {
                    spawnButton.interactable = true;
                    difficultyIncreased = true;
                    EnemyManager.instance.AddHealth();
                    BuildManager.instance.IncreaseCanonDamage();
                    CoinManager.instance.IncreaseDrop();

                    if (!incremented && waveStarted)
                    {

                        WaveManager.instance.waveNumber++;
                        WaveManager.instance.InitializeNextWave();
                        WaveManager.instance.UpdateText();
                        incremented = true;
                        waveStarted = false;
                    }
                    waveCounter = 0;
                    print("HA");
                }

                if (WaveManager.instance.waveNumber == 10)
                {
                    confetti.SetActive(true);
                    Time.timeScale = 1;
                    winText.SetActive(true);

                }

            }
        }
        else 
        {
            Time.timeScale = 1;
            dragon.SetActive(true);
            loseText.SetActive(true);

            if (Input.GetMouseButtonDown(0))
                SceneManagerScript.instance.GoToSpecificScene(0);
        }
    }

    public void SpawnEnemies() 
    {
        
        incremented = false;
        difficultyIncreased = false;
        for (int i = 0; i < spawners.Length; i++) 
        {
            spawners[i].GetComponent<WaveSpawner>().spawning = true;
        }
        waveCounter++;
    
    }
}
