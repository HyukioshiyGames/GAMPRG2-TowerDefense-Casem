using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoreMain : MonoBehaviour
{
    public static CoreMain instance;

    public int coreHp;
    public int coreMaxHp;

    public HealthBarScript healthBar;

    public int damage;
    // Start is called before the first frame update

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        coreHp = coreMaxHp;
        healthBar.SetMaxHealth(coreHp);
        healthBar.SetHealth(coreHp);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage() 
    {
        coreHp -= damage;
        healthBar.SetHealth(coreHp);

        if (coreHp <= 0)
            GameManager.instace.gameOver = true;
    }
}
