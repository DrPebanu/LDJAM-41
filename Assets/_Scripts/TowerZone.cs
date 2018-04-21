using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerZone : MonoBehaviour {

    [SerializeField] TowerFactory towerFactory;

    PlayerMovement player;

    public bool isPlaceable = true;

    private void Start() {
        player = FindObjectOfType<PlayerMovement>();
    }

    private void OnCollisionEnter2D(Collision2D collision) {

        if (isPlaceable && player.isCarrying) {
            towerFactory.AddTower(this);
            player.isCarrying = false;
        }

    }
}
