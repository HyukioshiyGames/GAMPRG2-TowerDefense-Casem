using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildManager : MonoBehaviour
{
    public int canonDamage;
    public int canonIncrement;

    public static BuildManager instance;
    public GameObject [] towers;
    public GameObject [] towerGhosts;

    public float[] prices;

    public float priceIncrement;

    public Text cannonPrice;
    private void Awake()
    {
        instance = this;
    }
   

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        cannonPrice.text = "" + prices[0];
    }

    public void IncreasePrice(int priceIndex) 
    {
        prices[priceIndex] += priceIncrement;
    }

    public void IncreaseCanonDamage()
    {
        canonDamage += canonIncrement;
    }
}
