using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour {

    public TowerZone currentZone;
    public bool isPlaced = false;

    [SerializeField] float attackRange = 10f;
    [SerializeField] ParticleSystem projectile;

    [SerializeField] Transform targetEnemy;

	
	// Update is called once per frame
	void Update () {
        SetTargetEnemy();

        if (targetEnemy)
            TestDistance();
        else
            Shoot(false);

	}

    private void TestDistance() {
        float distanceToEnemy = Vector2.Distance(transform.position, targetEnemy.transform.position);
        if (distanceToEnemy <= attackRange) {
            Shoot(true);
            projectile.transform.LookAt(targetEnemy);
        }
        else {
            Shoot(false);
        }
    }

    private void Shoot(bool isActive) {
        var emissionModule = projectile.emission;
        emissionModule.enabled = isActive;

    }

    private void SetTargetEnemy() {
        Enemy[] enemiesInScene = FindObjectsOfType<Enemy>();
        if (enemiesInScene.Length == 0) { return; }

        Transform closestEnemy = enemiesInScene[0].transform;

        foreach (Enemy testEnemy in enemiesInScene) {
            closestEnemy = GetClosest(closestEnemy, testEnemy.transform);
        }

        targetEnemy = closestEnemy;
    }

    private Transform GetClosest(Transform transformA, Transform transformB) {
        float distToA = Vector2.Distance(transform.position, transformA.position);
        float distToB = Vector2.Distance(transform.position, transformB.position);

        if (distToA < distToB)
            return transformA;
        else
            return transformB;
    }
}
