using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviourPun
{
    [SerializeField] private float speed;
    [SerializeField] private float attackPoint;
    public Transform[] moveSpots;
    private int randomSpot;
    private float waitTime;
    public float startWaitTime;

    float currentHealth;
    [SerializeField] private float maxHealth;

    void Start()
    {
        waitTime = startWaitTime;
        currentHealth = maxHealth;
        randomSpot = Random.Range(0, moveSpots.Length);
    }

    void Update()
    {
        photonView.RPC("EnemyMovement", RpcTarget.All);
    }
    
    [PunRPC]
    private void EnemyMovement()
    {
        //transform.position = Vector2.MoveTowards(transform.position, moveSpots[randomSpot].position, 
        //    (speed / 10) * Time.deltaTime);
        transform.position = GameObject.Find("Tree").transform.position;
        //if (Vector2.Distance(transform.position, moveSpots[randomSpot].position) < 0.2f)
        //{
        //    if (waitTime <= 0)
        //    {
        //        randomSpot = Random.Range(0, moveSpots.Length);
        //        waitTime = startWaitTime;
        //    }
        //    else
        //    {
        //        waitTime -= Time.deltaTime;
        //    }
        //}
    }

    [PunRPC]
    public void AddDamage(float damage)
    {
        currentHealth -= damage;
        if(currentHealth <= 0 )
        {
            photonView.RPC("Die", RpcTarget.All);
        }
    }

    [PunRPC]
    void Die()
    {
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Tree")
        {
            Debug.Log("Tabrak");
        }
    }
}
