using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    [Range(1f, 60f)]
    [SerializeField] float secondsBetweenSpawns = 2f;

    [SerializeField] Transform enemyParent;

    public EnemyMovement enemyPrefab;

    // Use this for initialization
    void Start()
    {
        
        SpawnEnemy();

        StartCoroutine(enemySpawner());

    }

    void SpawnEnemy()
    {
        var newEnemy = Instantiate(enemyPrefab, transform.position, Quaternion.Euler(new Vector3(0, 180f, 0)));
        newEnemy.transform.parent = enemyParent;
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
