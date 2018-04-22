using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateSpawns : MonoBehaviour {

    [SerializeField] WaveSpawner[] spawners;
    [SerializeField] float spawnerActiveTime = 5f;
    [SerializeField] float timeBetweenWaves = 2f;

    // Use this for initialization
    void Start () {

        Invoke("StartSpawning", 5f);
	}

    private void StartSpawning() {
 
            StartCoroutine(ActivateWaveSpawner());
    }

    private IEnumerator ActivateWaveSpawner() {

        while (true) {
            int randomSpawn1 = UnityEngine.Random.Range(0, spawners.Length - 1);
            int randomSpawn2 = UnityEngine.Random.Range(0, spawners.Length - 1);

            while (randomSpawn1 == randomSpawn2) {
                print("Same Spawn");
                randomSpawn2 = UnityEngine.Random.Range(0, spawners.Length - 1);
            }

            print("Activating spawns " + randomSpawn1 + " and " + randomSpawn2);
            spawners[randomSpawn1].gameObject.SetActive(true);
            spawners[randomSpawn2].gameObject.SetActive(true);

            print("Waiting " + spawnerActiveTime + " seconds");
            yield return new WaitForSeconds(spawnerActiveTime);

            print("Deactivating spawners");
            DeactivateWaveSpawner(randomSpawn1, randomSpawn2);

            print("Waiting " + timeBetweenWaves + " seconds");
            yield return new WaitForSeconds(timeBetweenWaves);
            print("End");
        }

    }

    private void DeactivateWaveSpawner(int spawner1, int spawner2) {
        spawners[spawner1].gameObject.SetActive(false);
        spawners[spawner2].gameObject.SetActive(false);
    }
}
