using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviourPun
{
    public float weaponDamage;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Enemy hurtEnemy = collision.gameObject.GetComponent<Enemy>();

        if (collision.gameObject.tag == "Wall")
        {
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "RedFire")
        {
            hurtEnemy.photonView.RPC("AddDamage", RpcTarget.All, weaponDamage);
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "BlueFire")
        {
            hurtEnemy.photonView.RPC("AddDamage", RpcTarget.All, weaponDamage);
            Destroy(gameObject);
        }
        
        if (collision.gameObject.tag == "BlackFire")
        {
            photonView.RPC("AddDamage", RpcTarget.All, weaponDamage);
            Destroy(gameObject);
        }
        
        if (collision.gameObject.tag == "WhiteFire")
        {
            photonView.RPC("AddDamage", RpcTarget.All, weaponDamage);
            Destroy(gameObject);
        }
    }
}
