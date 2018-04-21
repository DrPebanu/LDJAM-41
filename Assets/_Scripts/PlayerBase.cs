using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBase : MonoBehaviour {

    [SerializeField] int health = 10;

    public void TakeDamage(int enemyDamage) {
        if (health <= 1)
            GameOver();

        health--;
    }

    public void ScorePoints(int scoreToAdd) {

    }

    private void GameOver() {
        print("You Lost, TO BAD!");
    }
}
