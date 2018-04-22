using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour {

    public bool isCarrying = false;

    [SerializeField] Sprite isCarryingSprite;
    [SerializeField] Sprite isNotCarryingSprite;
    [SerializeField] TowerFactory towerFactory;
    [SerializeField] GameOver gameOver;

    [SerializeField] float turnSpeed = 100f;
    [SerializeField] float mainBoost = 100f;

    Rigidbody2D myRigidBody;

    private void Start() {
        myRigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update() {
        Turn();
        Boost();
        CheckIfCarrying();
    }

    private void CheckIfCarrying() {

        SpriteRenderer playerRenderer = GetComponentInChildren<SpriteRenderer>();

        if (isCarrying)
            playerRenderer.sprite = isCarryingSprite;
        else
            playerRenderer.sprite = isNotCarryingSprite;
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        string collisionTag = collision.gameObject.tag;

        if (collisionTag == "Enemy")
            gameOver.StartGameOver();
        else if (collisionTag == "Start")
            HandPlayerNewTower();

    }

    private void HandPlayerNewTower() {
        if (isCarrying)
            print("You can only carry one tower at a time");
        else
            towerFactory.AddTower();
    }


    private void Turn() {
        myRigidBody.angularVelocity = 0f;
        float xThrow = Input.GetAxis("Horizontal");
        float rotationThisFrame = xThrow * turnSpeed * Time.deltaTime;

        transform.Rotate(-Vector3.forward * rotationThisFrame);
    }

    private void Boost() {

        if (Input.GetButton("Jump"))
            myRigidBody.AddRelativeForce(Vector2.up * mainBoost * Time.deltaTime);
    }
}
