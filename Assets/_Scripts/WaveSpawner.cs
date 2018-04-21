using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour {

    [SerializeField] Transform[] spawnPoints;

    [Range(0.1f, 60f)]
    [SerializeField] float secondsBetweenSpawns = 2f;
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] Transform enemyParentTransform;

    int numOfSpawnedEnemies = 0;

    // Use this for initialization
    void Start() {
        StartCoroutine(SpawnEnemy());
    }

    private IEnumerator SpawnEnemy() {

        while (true) { // Forever
            GameObject newEnemy = Instantiate(enemyPrefab, spawnPoints[0].position, Quaternion.identity);
            newEnemy.transform.parent = enemyParentTransform;

            numOfSpawnedEnemies++;

            yield return new WaitForSeconds(secondsBetweenSpawns);
        }

    }
}
