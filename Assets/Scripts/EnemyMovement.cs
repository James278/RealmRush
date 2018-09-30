using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

    [Range(0f, 10f)]
    [SerializeField] int timeBetweenMovement = 1;

	// Use this for initialization
	void Start ()
    {
        Pathfinder pathfinder = GameObject.Find("World").GetComponent<Pathfinder>();
        List<Waypoint> enemyPath = pathfinder.GetPath();

        StartCoroutine(MoveEnemy(enemyPath));

    }

    // Update is called once per frame
    void Update () {

      
		
	}

    IEnumerator MoveEnemy(List<Waypoint> path)
    {
        foreach (Waypoint waypoint in path)
        {
            this.transform.position = waypoint.transform.position + new Vector3(5f, 0f, 10f);
            yield return new WaitForSeconds(timeBetweenMovement);
        }
    }

}
