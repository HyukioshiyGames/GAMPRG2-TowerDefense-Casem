using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerGhost : MonoBehaviour
{
    public Vector3 worldPosition;

    public Material material;

    public bool canBuild;

    public float price;
    public int index;

    Vector3 buildPosition;

    public Button spawnButton;

    private void Start()
    {
        material.color = Color.red;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) 
        {
            spawnButton.interactable = true;
            spawnButton.gameObject.GetComponent<CannonButton>().isPressed = false;
            Destroy(this.gameObject);
        }
           
        Plane plane = new Plane(Vector3.up, 0);

        float distance;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (plane.Raycast(ray, out distance))
        {
            worldPosition = ray.GetPoint(distance);
        }
        
        this.transform.position = worldPosition;

        if (canBuild) 
        {
            if (Input.GetMouseButtonDown(0)) 
            {
                Instantiate(BuildManager.instance.towers[index], buildPosition, Quaternion.identity);
                spawnButton.interactable = true;
                CoinManager.instance.SubCoins(price);
                spawnButton.gameObject.GetComponent<CannonButton>().isPressed = false;
                BuildManager.instance.IncreasePrice(0);

                Destroy(this.gameObject);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("BuildableArea")) 
        {
            material.color = Color.green;
            canBuild = true;
            buildPosition = other.transform.position;
        }
           
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("BuildableArea")) 
        {
            material.color = Color.red;
            canBuild = false;
        }
            
    }
}
