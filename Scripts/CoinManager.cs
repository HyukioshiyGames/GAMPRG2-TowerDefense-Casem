using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinManager : MonoBehaviour
{
    public static CoinManager instance;

    public float coins;
    public int coinReward;
    public int coinIncrement;

    public Text coinUI;

    private void Awake()
    {
        instance = this;
    }
    
    void Start()
    {
       coinUI.text = "" + coins;
    }


    public void AddCoins(float coin)
    {
        coins += coin;
        coinUI.text = "" + coins;
    }

    public void SubCoins(float coin) 
    {
        coins -= coin;
        coinUI.text = "" + coins;
    }

    public void IncreaseDrop() 
    {
        coinReward += coinIncrement;
    }
}
