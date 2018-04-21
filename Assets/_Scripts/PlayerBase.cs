using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBase : MonoBehaviour {

    [SerializeField] int health = 10;

    [SerializeField] Text healthText;
    [SerializeField] Text scoreText;

    int score = 0;

    private void Start() {
        UpdateTextFields();
    }

    private void UpdateTextFields() {
        healthText.text = health.ToString();
        scoreText.text = score.ToString();
    }

    public void TakeDamage(int enemyDamage) {
        if (health <= 1)
            GameOver();

        health -= enemyDamage;
        UpdateTextFields();
    }

    public void ScorePoints(int scoreToAdd) {
        score += scoreToAdd;
        UpdateTextFields();
    }

    private void GameOver() {
        print("You Lost, TO BAD!");
    }
}
