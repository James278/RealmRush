using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawner : MonoBehaviour
{

    [Range(1f, 60f)]
    [SerializeField] float secondsBetweenSpawns = 2f;
    [SerializeField] int enemyCount = 0;

    [SerializeField] Transform enemyParent;

    [SerializeField] Text scoreText;

    public EnemyMovement enemyPrefab;

    // Use this for initialization
    void Start()
    {

        scoreText.text = enemyCount.ToString();

        SpawnEnemy();
        StartCoroutine(enemySpawner());

    }

    void SpawnEnemy()
    {
        var newEnemy = Instantiate(enemyPrefab, transform.position, Quaternion.Euler(new Vector3(0, 180f, 0)));
        newEnemy.transform.parent = enemyParent;

        IncreaseScore();

    }

    IEnumerator enemySpawner()
    {
        while (true) // WHY: true is forever
        {
            yield return new WaitForSeconds(secondsBetweenSpawns);
            SpawnEnemy();
        }
    }
    private void IncreaseScore()
    {
        enemyCount++;
        scoreText.text = enemyCount.ToString();
    }

}
