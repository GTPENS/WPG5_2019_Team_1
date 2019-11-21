using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private int healthPoint;
    [SerializeField] private int attackPoint;

    //public Transform[] waypoints;
    //private int waypointIndex;

    void Start()
    {
       // waypointIndex = EnemySpawner.getSpawnPoint;
    }

    void Update()
    {
        //transform.position = Vector2.MoveTowards(transform.position, waypoints[waypointIndex].transform.position, Time.deltaTime * speed);

        //if (transform.position == waypoints[waypointIndex].transform.position)
        //    waypointIndex += 1;

        //if (waypointIndex == waypoints.Length)
        //    waypointIndex = waypoints.Length;

        transform.position = Vector2.MoveTowards(transform.position, GameObject.Find("Tree").transform.position, Time.deltaTime * speed / 2);
    }

    void Attack()
    {

    }
}
