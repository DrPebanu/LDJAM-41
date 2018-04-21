using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour {

    [SerializeField] float movementSpeed = 1f;
    [SerializeField] bool walkingRight = true;

    Rigidbody2D myRigidBody;


    private void Start() {
        myRigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update () {

        MoveEnemy();
        Physics2D.IgnoreLayerCollision(8, 9, true);

	}

    private void OnCollisionEnter2D(Collision2D collision) {
        string collisionTag = collision.gameObject.tag;

        if (collisionTag == "EnemyStopper")
            walkingRight = false;
    }

    private void MoveEnemy() {
        Vector2 enemyVelocity = new Vector2(movementSpeed, myRigidBody.velocity.y);

        if (walkingRight)
            myRigidBody.velocity = enemyVelocity;
        else
            myRigidBody.velocity = -enemyVelocity;

    }
}
