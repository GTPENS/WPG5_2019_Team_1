using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody2D projectile;

    private Rigidbody2D rb;
    private float speed = 300;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Rigidbody2D bullet = Instantiate(projectile, transform.position, Quaternion.identity) as Rigidbody2D;
            bullet.GetComponent<Rigidbody2D>().AddForce(transform.forward * 10);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(x, y);
        rb.velocity = movement * speed * Time.deltaTime;
    }
}
