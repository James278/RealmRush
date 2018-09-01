using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

    [SerializeField] List<Waypoint> path;

    [Range(0f, 10f)]
    [SerializeField] float timeBetweenMovement = 1f;

	// Use this for initialization
	void Start ()
    {

        StartCoroutine(MoveEnemy());

    }

    // Update is called once per frame
    void Update () {

      
		
	}

    IEnumerator MoveEnemy()
    {
        foreach (Waypoint waypoint in path)
        {
            this.transform.position = waypoint.transform.position + new Vector3(5f, 0f, 10f);
            yield return new WaitForSeconds(timeBetweenMovement);
        }
    }

}
