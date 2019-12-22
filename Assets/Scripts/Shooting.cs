using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviourPun
{
    public float bulletForce = 20f;
    public GameObject bulletPrefabs;
    public AudioSource musicSource;
    public AudioClip shootFx;
    public Transform firePoint;

    private void Start()
    {
        musicSource.clip = shootFx;
    }
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            photonView.RPC("Shoot", RpcTarget.All);
        }
    }

    [PunRPC]
    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefabs, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
        musicSource.Play();
        Destroy(bullet, 0.2f);
    }
}
