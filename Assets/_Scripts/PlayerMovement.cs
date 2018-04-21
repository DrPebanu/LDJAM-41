using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public bool isCarrying = false;

    //[SerializeField] float runSpeed = 5f;
    //[SerializeField] float jumpSpeed = 5f;
    //[SerializeField] float fallMultiplier = 2.5f;
    //[SerializeField] float lowJumpMultiplier = 2f;

    [SerializeField] TowerFactory towerFactory;

    [SerializeField] float turnSpeed = 100f;
    [SerializeField] float mainBoost = 100f;

    [SerializeField] AudioClip mainEngine;

    bool playerHasHorizontalSpeed;


    AudioSource audioSource;
    Rigidbody2D myRigidBody;

    private void Start() {
        audioSource = GetComponent<AudioSource>();
        myRigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update() {
        //Run();
        //FlipSprite();
        // Jump();
        Turn();
        Boost();
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
        // Destroy(gameObject);
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
        // Particles Stop
    }

    private void ApplyThrust() {
        myRigidBody.AddRelativeForce(Vector2.up * mainBoost * Time.deltaTime);
        if (!audioSource.isPlaying) {
            audioSource.PlayOneShot(mainEngine);
        }
        // Particles Play
    }



    //private void Jump() { // Using better Jump

    //    if (Input.GetButtonDown("Jump") && myRigidBody.velocity.y == 0f) {
    //        myRigidBody.AddForce(Vector2.up * jumpSpeed, ForceMode2D.Impulse);

    //    }

    //    if (myRigidBody.velocity.y < Mathf.Epsilon)
    //        myRigidBody.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
    //    else if (myRigidBody.velocity.y > Mathf.Epsilon)
    //        myRigidBody.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;

    //}

    //private void Run() {
    //    float controlThrow = Input.GetAxis("Horizontal");
    //    Vector2 playerVelocity = new Vector2(controlThrow * runSpeed, myRigidBody.velocity.y);
    //    myRigidBody.velocity = playerVelocity;

    //    playerHasHorizontalSpeed = Mathf.Abs(myRigidBody.velocity.x) > Mathf.Epsilon;
    //}

    //private void FlipSprite() {


    //    if (playerHasHorizontalSpeed)
    //        transform.localScale = new Vector2(Mathf.Sign(myRigidBody.velocity.x), 1f);
    //}
}
