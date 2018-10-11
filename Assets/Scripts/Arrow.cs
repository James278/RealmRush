using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour {

    // Parameters of each tower
    [SerializeField] Transform arrowDirection;
    [SerializeField] float attackRange = 5f;
    [SerializeField] ParticleSystem theArrow;

    // States of each tower
    Transform targetEnemy;

    float distanceToEnemy;

    // Use this for initialization
    void Start () {

		
	}
	
	// Update is called once per frame
	void Update () {

        SetTargetEnemy();

        if (targetEnemy)
        {
            arrowDirection.LookAt(targetEnemy);
            ToggleFiring();
        }
        else
        {
            Shoot(false);
        }

    }

    void SetTargetEnemy()
    {
        var sceneEnemies = FindObjectsOfType<EnemyDamage>();
        if (sceneEnemies.Length <= 0)
        {
            return;
        }

        Transform closestEnemy = sceneEnemies[0].transform;

        foreach (EnemyDamage testEnemy in sceneEnemies)
        {
            closestEnemy = GetClosest(closestEnemy, testEnemy.transform);
        }

        targetEnemy = closestEnemy;

    }

    private Transform GetClosest(Transform transformA, Transform transformB)
    {
        var distanceToA = Vector3.Distance(transform.position, transformA.position);
        var distanceToB = Vector3.Distance(transform.position, transformB.position);

        if (distanceToA < distanceToB)
        {
            return transformA;
        }
        return transformB;
    }

    private void ToggleFiring()
    {
        distanceToEnemy = Vector3.Distance(targetEnemy.position, transform.position);

        if (distanceToEnemy <= attackRange)
        {
            Shoot(true);
        }
        else
        {
            Shoot(false);
        }
    }

    private void Shoot(bool isActive)
    {
        var emissionModule = theArrow.emission;
        emissionModule.enabled = isActive;
    }

}
