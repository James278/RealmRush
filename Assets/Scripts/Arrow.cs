using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour {

    [SerializeField] Transform targetEnemy;
    [SerializeField] Transform arrowDirection;
    [SerializeField] float attackRange = 5f;
    [SerializeField] ParticleSystem theArrow;

    float distanceToEnemy;

    // Use this for initialization
    void Start () {

		
	}
	
	// Update is called once per frame
	void Update () {

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
