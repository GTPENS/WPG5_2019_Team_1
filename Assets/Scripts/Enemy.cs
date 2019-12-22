using Photon.Pun;
using Photon.Pun.UtilityScripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviourPun
{
    [SerializeField] float speed;
    [SerializeField] float attackPoint;
    [SerializeField] float maxHealth;
    float currentHealth;
    float waitTime;
    float startWaitTime;
    int randomSpot;

    public Transform[] moveSpots;
    public Animator animator;

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
        transform.position = Vector2.MoveTowards(transform.position, moveSpots[randomSpot].position, (speed / 10) * Time.deltaTime);
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

    [PunRPC]
    public void AddDamage(float damage)
    {
        currentHealth -= damage;
        if(currentHealth <= 0 )
        {
            Die();
        }
    }

    void Die()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            GameManager.enemyDefeated++;
            PhotonNetwork.Destroy(gameObject);
        }
        Debug.Log("Enemy Defeated : " + GameManager.enemyDefeated.ToString());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Tree")
        {
            Debug.Log("Attack");
            InvokeRepeating("Attack", 1.0f, 1.0f);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Tree")
        {
            animator.SetBool("Hit",false);
        }
    }

    private void Attack()
    {
        animator.SetBool("Hit",true);

        Tree tree = GameObject.FindObjectOfType(typeof(Tree)) as Tree;
        tree.photonView.RPC("TreeAddDamage", RpcTarget.All, attackPoint);
    }
}
