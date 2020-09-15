using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveManager : MonoBehaviour
{
    public static WaveManager instance;

    //Hard Coded haha sorry sir
    public List<GameObject[]> waves = new List<GameObject[]>();

  
    public GameObject[] wave1;
    public GameObject[] wave2;
    public GameObject[] wave3;
    public GameObject[] wave4;
    public GameObject[] wave5;
    public GameObject[] wave6;
    public GameObject[] wave7;
    public GameObject[] wave8;
    public GameObject[] wave9;
    public GameObject[] wave10;


    public GameObject[] towers;
    public int waveNumber;

    public Text waveNumText;
    // Start is called before the first frame update

    
    void Awake()
    {
        instance = this;

        waves.Add(wave1);
        waves.Add(wave2);
        waves.Add(wave3);
        waves.Add(wave4);
        waves.Add(wave5);
        waves.Add(wave6);
        waves.Add(wave7);
        waves.Add(wave8);
        waves.Add(wave9);
        waves.Add(wave10);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void InitializeNextWave() 
    {
        for (int i = 0; i < towers.Length; i++)
            towers[i].GetComponent<WaveSpawner>().currentWave = waves[waveNumber];
        
    }

    public void UpdateText() 
    {
        waveNumText.text = "Wave " + (waveNumber + 1 )+ " /10";
    }
}
