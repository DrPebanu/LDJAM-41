using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    [SerializeField] float runSpeed = 5f;
    [SerializeField] float jumpSpeed = 5f;
    [SerializeField] float fallMultiplier = 2.5f;
    [SerializeField] float lowJumpMultiplier = 2f;


    bool playerHasHorizontalSpeed;

    Rigidbody2D myRigidBody;

    private void Start() {
        myRigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate() {
        Run();
        FlipSprite();
        Jump();
    }

    private void Jump() { // Using better Jump

        if (Input.GetButtonDown("Jump") && myRigidBody.velocity.y == 0f) {
            myRigidBody.AddForce(Vector2.up * jumpSpeed, ForceMode2D.Impulse);

        }

        if (myRigidBody.velocity.y < Mathf.Epsilon)
            myRigidBody.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        else if (myRigidBody.velocity.y > Mathf.Epsilon)
            myRigidBody.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;

    }

    private void Run() {
        float controlThrow = Input.GetAxis("Horizontal");
        Vector2 playerVelocity = new Vector2(controlThrow * runSpeed, myRigidBody.velocity.y);
        myRigidBody.velocity = playerVelocity;

        playerHasHorizontalSpeed = Mathf.Abs(myRigidBody.velocity.x) > Mathf.Epsilon;
    }

    private void FlipSprite() {


        if (playerHasHorizontalSpeed)
            transform.localScale = new Vector2(Mathf.Sign(myRigidBody.velocity.x), 1f);
    }
}
