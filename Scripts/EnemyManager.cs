using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public static EnemyManager instance;
    public int [] enemyHp;
    public int addHealth;

    
    private void Awake()
    {
        instance = this;
    }
   
    public void AddHealth() 
    {
        for(int i = 0; i < enemyHp.Length; i++) 
        {
            enemyHp[i] += 25;
        }
    }

    public int SetHealth(int index) 
    {
        return enemyHp[index];
    }
}
