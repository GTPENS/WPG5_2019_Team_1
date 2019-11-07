using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D myBody;
    public float speed;
    Vector2 moveVelocity;

    public GameObject crossHair;
    public Animator animator;
    private void Start()
    {
        myBody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        animator.SetFloat("Vertical", Input.GetAxis("Vertical"));
        Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        moveVelocity = moveInput.normalized * speed;
    }

    private void FixedUpdate()
    {
        myBody.MovePosition(myBody.position + moveVelocity * Time.fixedDeltaTime);
    }

}
