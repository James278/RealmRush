using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

    [Range(0f, 10f)]
    [SerializeField] float timeBetweenMovement = 1;

    [SerializeField] int timeBetweenAttack = 3;

    [SerializeField] List<Waypoint> enemyPath;

    public PlayerCastle playerCastle;

    // Use this for initialization
    void Start ()
    {
        playerCastle = FindObjectOfType<PlayerCastle>();

        Pathfinder pathfinder = UnityEngine.GameObject.Find("World").GetComponent<Pathfinder>();
        enemyPath = pathfinder.GetPath();

        StartCoroutine(MoveEnemy(enemyPath));

    }

    IEnumerator MoveEnemy(List<Waypoint> path)
    {

        foreach (Waypoint waypoint in path)
        {
            this.transform.position = waypoint.transform.position + new Vector3(5f, 0f, 10f);
            yield return new WaitForSeconds(timeBetweenMovement);
        }

        StartCoroutine(DamageCastle());

    }

    IEnumerator DamageCastle()
    {
        while (true)
        {
            playerCastle.DecreaseHealth(1);
            yield return new WaitForSeconds(timeBetweenAttack);
        }
    }

}
