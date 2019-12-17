using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float attackPoint;

    float currentHealth;
    [SerializeField] private float maxHealth;

    //private int waypointIndex = 0;

    //public Transform[] waypoints;

    void Start()
    {
        currentHealth = maxHealth;
    }

    void Update()
    {
        //transform.position = Vector2.MoveTowards(transform.position, waypoints[EnemySpawner.getSpawnPoint].transform.position, Time.deltaTime * speed);

        //if (transform.position == waypoints[EnemySpawner.getSpawnPoint].transform.position)
        //    waypointIndex += 1;

        //if (waypointIndex == waypoints.Length)
        //    waypointIndex = waypoints.Length;

        transform.position = Vector2.MoveTowards(transform.position, GameObject.FindGameObjectWithTag("Hit").transform.position, Time.deltaTime * speed / 3);

        
    }

    public void addDamage(float damage)
    {
        currentHealth -= damage;
        if(currentHealth <= 0 )
        {
            Die();
        }
    }
    
    void Die()
    {
        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Tree")
        {
            HealthBar hurtTree = collision.gameObject.GetComponent<HealthBar>();
            hurtTree.addDamage(attackPoint);
        }
    }
    
}
