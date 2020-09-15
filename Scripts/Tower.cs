using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public GameObject projectile;
    public Transform spawnPoint; 

    public float attackSpeed;
    public float current;

    public float damage;

    public List<GameObject> enemyInRange;

    public GameObject target;

    public bool isAttacking;
    public bool rotatable;

    // Update is called once per frame
    void Update()
    {
        if (enemyInRange.Count > 0)
            target = enemyInRange[0];
        else
            target = null;

        if (target != null) 
        {
            isAttacking = true;
            if(rotatable)
                this.transform.LookAt(target.transform);
        }
        else 
        {
            if (enemyInRange.Count > 0)
                enemyInRange.RemoveAt(0);
            else
                isAttacking = false;
        }
           

        if (isAttacking) 
        {
            if (current < attackSpeed)
                current += Time.deltaTime;
            else 
            {
                Attack();
                current = 0;
            }

        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
            enemyInRange.Add(other.gameObject);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Enemy"))
            enemyInRange.Remove(other.gameObject);
    }


    public void Attack() 
    {
        GameObject proj = (GameObject)Instantiate(projectile, spawnPoint.position, spawnPoint.rotation);
        proj.GetComponent<Projectile>().target = target;
    }
}
