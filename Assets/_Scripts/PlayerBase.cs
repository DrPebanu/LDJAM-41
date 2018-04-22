using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBase : MonoBehaviour {

    [SerializeField] int health = 10;

    [SerializeField] Text healthText;
    [SerializeField] Text scoreText;

    [SerializeField] GameOver gameOver;

    [SerializeField] SpriteRenderer baseMesh;


    [SerializeField] Sprite base6Fires;
    [SerializeField] Sprite base5Fires;
    [SerializeField] Sprite base4Fires;
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

        switch (towersInScene) {
            case 0:
                baseMesh.sprite = base6Fires; 
                break;
            case 1:
                baseMesh.sprite = base5Fires;
                break;
            case 2:
                baseMesh.sprite = base4Fires;
                break;
            case 3:
                baseMesh.sprite = base3Fires;
                break;
            case 4:
                baseMesh.sprite = base2Fires;
                break;
            case 5:
                baseMesh.sprite = base1Fires;
                break;
            case 6:
                baseMesh.sprite = baseNoFires;
                break;
        }
    }

    private void UpdateTextFields() {
        healthText.text = health.ToString();
        scoreText.text = score.ToString();
    }

    public void TakeDamage(int enemyDamage) {
        if (health <= 1)
            gameOver.StartGameOver();

        health -= enemyDamage;
        UpdateTextFields();
    }

    public void ScorePoints(int scoreToAdd) {
        score += scoreToAdd;
        UpdateTextFields();
    }

}
