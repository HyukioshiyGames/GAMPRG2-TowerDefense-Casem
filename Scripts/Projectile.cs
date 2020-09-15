using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public GameObject target;

    public float movementSpeed;
    public int damage;

    float dist;
    private void Update()
    {
        damage = BuildManager.instance.canonDamage;
        if (target != null) 
        {
            dist = Vector3.Distance(this.transform.position, target.transform.position);
            if (dist > 1)
                this.transform.position = Vector3.MoveTowards(this.transform.position, target.transform.position, movementSpeed * Time.deltaTime * 10f);
            else 
            {
                target.GetComponent<EnemyMovement>().TakeDamage(damage); 
                Destroy(this.gameObject);
            }
        }
        else
            Destroy(this.gameObject);
    }

   
}
