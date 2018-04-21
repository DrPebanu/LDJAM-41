using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour {

    [SerializeField] float movementSpeed = 1f;

    Transform playerBase;
    Rigidbody2D myRigidBody;
    BoxCollider2D playerCollider;
    

    private void Start() {
        playerBase = FindObjectOfType<PlayerBase>().transform;
        myRigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update () {
        myRigidBody.position = Vector2.MoveTowards(myRigidBody.position, playerBase.position, movementSpeed / 100);
        Physics2D.IgnoreLayerCollision(8, 9, true);
	}
}
