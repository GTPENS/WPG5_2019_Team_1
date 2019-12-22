using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviourPun
{
    float currentHealth;
    float maxHealth = 200f;
    GameManager gm; 

    void Start()
    {
        currentHealth = maxHealth;
        gm = GameObject.FindObjectOfType(typeof(GameManager)) as GameManager;
    }

    [PunRPC]
    public void TreeAddDamage(float damage)
    {
        currentHealth -= damage;
        gm.healthBar.GetComponent<RectTransform>().sizeDelta = new Vector2((currentHealth / maxHealth) * 100, 20);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
        gm.Lose();
    }
}
