using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float attackPoint;
    public Transform[] moveSpots;
    private int randomSpot;
    private float waitTime;
    public float startWaitTime;

    float currentHealth;
    [SerializeField] private float maxHealth;

    //private int waypointIndex = 0;

    //public Transform[] waypoints;

    void Start()
    {
        waitTime = startWaitTime;
        currentHealth = maxHealth;
        randomSpot = Random.Range(0, moveSpots.Length);
    }

    void Update()
    {
        //transform.position = Vector2.MoveTowards(transform.position, waypoints[EnemySpawner.getSpawnPoint].transform.position, Time.deltaTime * speed);

        //if (transform.position == waypoints[EnemySpawner.getSpawnPoint].transform.position)
        //    waypointIndex += 1;

        //if (waypointIndex == waypoints.Length)
        //    waypointIndex = waypoints.Length;

        //transform.position = Vector2.MoveTowards(transform.position, GameObject.FindGameObjectWithTag(target).transform.position, Time.deltaTime * speed / 3);
        transform.position = Vector2.MoveTowards(transform.position, moveSpots[randomSpot].position, speed * Time.deltaTime);
        if (Vector2.Distance(transform.position, moveSpots[randomSpot].position) < 0.2f)
        {
            if (waitTime <= 0)
            {
                randomSpot = Random.Range(0, moveSpots.Length);
                waitTime = startWaitTime;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }
        
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
