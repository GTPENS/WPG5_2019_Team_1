using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody2D rigidbody;
    Camera cam;
    Vector2 movement;
    Vector2 mousePos;

    public Animator animator;

    private void Awake()
    {
        cam = Camera.main;
    }

    private void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
    }

    private void FixedUpdate()
    {
        rigidbody.MovePosition(rigidbody.position + movement * moveSpeed * Time.fixedDeltaTime);
        Vector2 lookDir = mousePos - rigidbody.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        rigidbody.rotation = angle;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("RedFire"))
        {
            Debug.Log("Collide");

            Physics2D.IgnoreCollision(
                collision.collider,
                GameObject.FindGameObjectWithTag("RedFire").GetComponent<Collider2D>(),
                true);
        }

        //if (collision.collider.tag == "BlueFire")
        //{
        //    Physics2D.IgnoreCollision(
        //        collision.collider,
        //        GameObject.FindGameObjectWithTag("BlueFire").GetComponent<Collider2D>(),
        //        true);
        //}

        //if (collision.collider.tag == "BlackFire")
        //{
        //    Physics2D.IgnoreCollision(
        //        collision.collider,
        //        GameObject.FindGameObjectWithTag("BlackFire").GetComponent<Collider2D>(),
        //        true);
        //}

        //if (collision.collider.tag == "WhiteFire")
        //{
        //    Physics2D.IgnoreCollision(
        //        collision.collider,
        //        GameObject.FindGameObjectWithTag("WhiteFire").GetComponent<Collider2D>(),
        //        true);
        //}

        //if (collision.collider.tag == "Bullet")
        //{
        //    Physics2D.IgnoreCollision(
        //        collision.collider,
        //        GameObject.FindGameObjectWithTag("Bullet").GetComponent<Collider2D>(),
        //        true);
        //}
    }
}