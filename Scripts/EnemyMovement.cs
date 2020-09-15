using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EnemyMovement : MonoBehaviour
{
    public GameObject particleEffect;

    public int hp;
    public int maxHp;
    public int enemyIndex;

    public GameObject waypointParent;

    public List <Transform> waypoints;
    public Transform target;

    int currentWaypoint;

    public float movementSpeed;
    public float dist;

    public int coinReward;

    public HealthBarScript healthBar;

    private void Start()
    {
        hp = EnemyManager.instance.SetHealth(enemyIndex);
        SetWaypoints();

        currentWaypoint = -1;
        SetTarget();

        maxHp = hp;
        healthBar.SetMaxHealth(maxHp);

        coinReward = CoinManager.instance.coinReward;
    }

    private void Update()
    {
        if(target != null) 
        {
            dist = Vector3.Distance(this.transform.position, target.position);
            if (dist <= 1f)
            {
                SetTarget();
            }
            else
            {
                this.transform.position = Vector3.MoveTowards(this.transform.position, target.position, movementSpeed * Time.deltaTime * 10f);
                this.transform.LookAt(target);
            }
        }

       
    }

    public void SetTarget() 
    {
        currentWaypoint++;

        if (currentWaypoint <= waypoints.Count)
            target = waypoints[currentWaypoint];
        else
            target = null;
    }

    public void SetWaypoints() 
    {
        int childCount = waypointParent.transform.childCount;

        for (int i = 0; i < childCount; i++) 
        {
            waypoints.Add(waypointParent.transform.GetChild(i));
        }
            
    }

    public void TakeDamage(int damage) 
    {
        hp -= damage;
        if (hp <= 0) 
        {
            Destroy(this.gameObject);
            CoinManager.instance.AddCoins(coinReward);
            GameManager.instace.enemyDied++;
            Instantiate(particleEffect, this.transform.position + Vector3.up * 15f, new Quaternion(-90f,0f,0f,0f));
        }
        else
            healthBar.SetHealth(hp);
           
    }
}
