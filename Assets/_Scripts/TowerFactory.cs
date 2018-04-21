using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerFactory : MonoBehaviour {

    [SerializeField] int towerLimit = 3;
    [SerializeField] Tower towerPrefab;
    [SerializeField] Transform towerParentTransform;

    List<Tower> towerBuffer = new List<Tower>();

    public void AddTower() {

        int numTowers = towerBuffer.Count;

        if (numTowers < towerLimit)
            InstantiateNewTower();
        else
            print("You are at the Tower Limit");
    }

    public void PickUpTower(TowerZone pickUpZone) {

        print("You Picked up the tower");

        foreach (Tower tower in towerBuffer) {
            if (tower.currentZone == pickUpZone) {
                tower.isPlaced = false;
                tower.gameObject.SetActive(false);
                tower.currentZone.isPlaceable = true;
            }
        }

    }

    public void PlaceExistingTower(TowerZone newSpawnZone) {

        Vector2 spawnPosition = new Vector2(newSpawnZone.transform.position.x, newSpawnZone.transform.position.y + 0.8f);

        foreach (Tower tower in towerBuffer) {
            if (tower.isPlaced == false) {
                tower.isPlaced = true;
                tower.currentZone = newSpawnZone;
                newSpawnZone.isPlaceable = false;
                tower.transform.position = spawnPosition;
                tower.gameObject.SetActive(true);
                break;
            }
        }
    }

    private void InstantiateNewTower() {
        Tower newTower = Instantiate(towerPrefab, gameObject.transform.position, Quaternion.identity);
        newTower.transform.parent = towerParentTransform;
        newTower.gameObject.SetActive(false);

        PlayerMovement player = FindObjectOfType<PlayerMovement>();
        player.isCarrying = true;

        towerBuffer.Add(newTower);
    }
}
