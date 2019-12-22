using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviourPun
{
    public float weaponDamage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Enemy enemy = collision.gameObject.GetComponent<Enemy>();

        if (collision.gameObject.tag == "Wall")
        {
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "RedFire")
        {
            enemy.photonView.RPC("AddDamage", RpcTarget.All, weaponDamage);
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "BlueFire")
        {
            enemy.photonView.RPC("AddDamage", RpcTarget.All, weaponDamage);
            Destroy(gameObject);
        }
        
        if (collision.gameObject.tag == "BlackFire")
        {
            enemy.photonView.RPC("AddDamage", RpcTarget.All, weaponDamage);
            Destroy(gameObject);
        }
        
        if (collision.gameObject.tag == "WhiteFire")
        {
            enemy.photonView.RPC("AddDamage", RpcTarget.All, weaponDamage);
            Destroy(gameObject);
        }
    }
}
