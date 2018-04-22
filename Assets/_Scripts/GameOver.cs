using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {

    [SerializeField] GameObject player;
    [SerializeField] GameObject towers;
    [SerializeField] GameObject enemies;
    [SerializeField] GameObject spawners;

    Animator animator;
    bool gameIsOver = false;

	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();
	}

    private void Update() {
        if (Input.GetKey(KeyCode.R) && gameIsOver) {
            SceneManager.LoadScene(0);
        }
    }

    public void StartGameOver() {

        animator.SetTrigger("GameOver");
        player.SetActive(false);
        towers.SetActive(false);
        enemies.SetActive(false);
        spawners.SetActive(false);
        gameIsOver = true;

    }
}
