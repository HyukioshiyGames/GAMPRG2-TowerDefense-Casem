using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildSpot : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseOver()
    {
        this.GetComponent<MeshRenderer>().material.shader = Shader.Find("Self-Illumin/Outlined Diffuse");
        print("Over");
    }

    private void  OnMouseExit()
    {
        this.GetComponent<MeshRenderer>().material.shader = Shader.Find("Diffuse");
    }
}
