using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerFactory : MonoBehaviour {

    [SerializeField] int towerLimit = 3;
    [SerializeField] Tower towerPrefab;
    [SerializeField] Transform towerParentTransform;

    Queue<Tower> towerBuffer = new Queue<Tower>();
    Vector2 spawnPosition;

    public void AddTower(TowerZone spawnZone) {

        int numTowers = towerBuffer.Count;
        spawnPosition = new Vector2(spawnZone.transform.position.x, spawnZone.transform.position.y + 0.8f);

        if (numTowers < towerLimit)
            InstantiateNewTower(spawnZone);
        else
            MoveExistingTower(spawnZone);
    }

    private void MoveExistingTower(TowerZone newSpawnZone) {

        Tower oldTower = towerBuffer.Dequeue();

        oldTower.currentZone.isPlaceable = true;
        newSpawnZone.isPlaceable = false;
        oldTower.currentZone = newSpawnZone;

        oldTower.transform.position = spawnPosition;

        towerBuffer.Enqueue(oldTower);
    }

    private void InstantiateNewTower(TowerZone spawnZone) {
        Tower newTower = Instantiate(towerPrefab, spawnPosition, Quaternion.identity);
        newTower.transform.parent = towerParentTransform;

        spawnZone.isPlaceable = false;
        newTower.currentZone = spawnZone;
        towerBuffer.Enqueue(newTower);
    }
}
