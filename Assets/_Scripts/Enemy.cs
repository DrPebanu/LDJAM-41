using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    [SerializeField] int healthPoints = 1;
    [SerializeField] int enemyDamage = 1;
    [SerializeField] int scorePerKill = 1;

    PlayerBase playerBase;

	// Use this for initialization
	void Start () {
        playerBase = FindObjectOfType<PlayerBase>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnParticleCollision(GameObject other) {
        if (healthPoints <= 1)
            KillEnemy(false);
        else 
            healthPoints--;
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        KillEnemy(true);
    }

    private void KillEnemy(bool isWin) {
        if (isWin)
            playerBase.TakeDamage(enemyDamage);
        else
            playerBase.ScorePoints(scorePerKill);

        Destroy(gameObject);
    }
}
