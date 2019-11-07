using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float speed = 3;
    private int healthPoint;
    private int attackPoint;

    void Start()
    {
        
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, GameObject.Find("Tree").transform.position, Time.deltaTime * speed);
    }

    void Attack()
    {

    }
}
