    using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CannonButton : MonoBehaviour
{
    
    public float price;

    public Button button;
    public int towerIndex;
    public int priceIndex;

    public bool isPressed;
    private void Start()
    {
        button = GetComponent<Button>();
    }

    private void Update()
    {
        price = BuildManager.instance.prices[priceIndex];
        if (CoinManager.instance.coins >= price && !isPressed)
            button.interactable = true;
        else
            button.interactable = false;
    }
    public void BuildCannon() 
    {
        GameObject ghost = (GameObject)Instantiate(BuildManager.instance.towerGhosts[towerIndex], Input.mousePosition, Quaternion.identity);
        ghost.GetComponent<TowerGhost>().spawnButton = button;
        ghost.GetComponent<TowerGhost>().price = price;
        ghost.GetComponent<TowerGhost>().index = towerIndex;
        //button.interactable = false;
        isPressed = true;

    }




}
