using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    [SerializeField] float secondsBetweenSpawns = 2f;

    public EnemyMovement enemyPrefab;

    // Use this for initialization
    void Start () {

        SpawnEnemy();

        StartCoroutine(enemySpawner());
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void SpawnEnemy()
    {
        Instantiate(enemyPrefab, transform.position, Quaternion.identity);
    }

    IEnumerator enemySpawner()
    {
        while (true) // WHY: true is forever
        {
            yield return new WaitForSeconds(secondsBetweenSpawns);
            SpawnEnemy();
        }
    }

}
