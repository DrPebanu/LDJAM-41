using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour {

    [Range(0.1f, 60f)]
    [SerializeField] float secondsBetweenSpawns = 2f;


    [SerializeField] GameObject enemyPrefab;
    [SerializeField] Transform enemyParentTransform;

    int numOfSpawnedEnemies = 0;

    private IEnumerator SpawnEnemy() {
        while (true) {
            GameObject newEnemy = Instantiate(enemyPrefab, gameObject.transform.position, Quaternion.identity);
            newEnemy.transform.parent = enemyParentTransform;

            numOfSpawnedEnemies++;

            yield return new WaitForSeconds(secondsBetweenSpawns);

        }


    }

    private void OnEnable() {
        StartCoroutine(SpawnEnemy());
    }
}
