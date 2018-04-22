using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBase : MonoBehaviour {

    [SerializeField] int health = 10;

    [SerializeField] Text healthText;
    [SerializeField] Text scoreText;

    [SerializeField] SpriteRenderer baseMesh;

    [SerializeField] Sprite base3Fires;
    [SerializeField] Sprite base2Fires;
    [SerializeField] Sprite base1Fires;
    [SerializeField] Sprite baseNoFires;

    int score = 0;
    [SerializeField] int towersInScene;

    private void Start() {
        UpdateTextFields();
    }

    private void Update() {
        towersInScene = FindObjectOfType<TowerFactory>().GetNumOfTowers();

        if (towersInScene == 0)
            baseMesh.sprite = base3Fires;
        else if (towersInScene == 1)
            baseMesh.sprite = base2Fires;
        else if (towersInScene == 2)
            baseMesh.sprite = base1Fires;
        else if (towersInScene == 3)
            baseMesh.sprite = baseNoFires;

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
