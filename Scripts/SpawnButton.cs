using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SpawnButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnWave() 
    {
        GameManager.instace.waveStarted = true;
        this.GetComponent<Button>().interactable = false;
        GameManager.instace.enemySpawnCount = 0;
        GameManager.instace.enemyDied = 0;
    }
}
