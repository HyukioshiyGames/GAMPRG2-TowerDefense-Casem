using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarScript : MonoBehaviour
{
    public Slider slider;

    public bool inWorldSpace;
    //public GameObject cam;

    public void SetHealth(int amountHealth) 
    {
        slider.value = amountHealth;
    }

    public void SetMaxHealth(int amountHealth) 
    {
        slider.maxValue = amountHealth;
        slider.value = amountHealth;
    }

    public void LateUpdate()
    {
        if(inWorldSpace)
            this.transform.LookAt(Camera.main.transform);
    }
}
