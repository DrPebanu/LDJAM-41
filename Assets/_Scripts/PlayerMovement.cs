﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour {

    public bool isCarrying = false;

    [SerializeField] Sprite isCarryingSprite;
    [SerializeField] Sprite isNotCarryingSprite;
    [SerializeField] TowerFactory towerFactory;

    [SerializeField] float turnSpeed = 100f;
    [SerializeField] float mainBoost = 100f;

    [SerializeField] AudioClip mainEngine;

    AudioSource audioSource;
    Rigidbody2D myRigidBody;

    private void Start() {
        audioSource = GetComponent<AudioSource>();
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
            KillPlayer();
        else if (collisionTag == "Start")
            HandPlayerNewTower();

    }

    private void HandPlayerNewTower() {
        if (isCarrying)
            print("You can only carry one tower at a time");
        else
            towerFactory.AddTower();
    }

    private void KillPlayer() {
        print("You are dead fool!");
        SceneManager.LoadScene(0);
    }

    private void Turn() {
        myRigidBody.angularVelocity = 0f; // Remove rotation due to physics
        float xThrow = Input.GetAxis("Horizontal");
        float rotationThisFrame = xThrow * turnSpeed * Time.deltaTime;

        transform.Rotate(-Vector3.forward * rotationThisFrame);
    }

    private void Boost() {

        if (Input.GetButton("Jump")) // Can thrust while rotating
            ApplyThrust();
        else
            StopApplyingThrust();
    }

    private void StopApplyingThrust() {
        audioSource.Stop();
    }

    private void ApplyThrust() {
        myRigidBody.AddRelativeForce(Vector2.up * mainBoost * Time.deltaTime);
        if (!audioSource.isPlaying) {
            audioSource.PlayOneShot(mainEngine);
        }
    }
}
