using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerFactory : MonoBehaviour {

    [Range(3, 6)]
    [SerializeField] int towerMax = 4;

    [SerializeField] Tower towerPrefab;
    [SerializeField] Transform towerParentTransform;

    Queue<Tower> towerQueue = new Queue<Tower>();

    public void AddTower(Waypoint baseWaypoint)
    {
        int numOfTowers = towerQueue.Count; 

        if (numOfTowers < towerMax)
        {
            PlaceTower(baseWaypoint);
        }
        else
        {
            MoveTower(baseWaypoint);
        }
    }

    private void PlaceTower(Waypoint baseWaypoint)
    {
        var newTower = Instantiate(towerPrefab, baseWaypoint.transform.position + new Vector3(5f, 0f, 10f), Quaternion.identity);
        newTower.transform.parent = towerParentTransform;

        newTower.baseWaypoint = baseWaypoint;
        baseWaypoint.isPlaceable = false;

        towerQueue.Enqueue(newTower);

        print(towerQueue.Count);
    }

    private void MoveTower(Waypoint newBaseWaypoint)
    {
        var oldTower = towerQueue.Dequeue();

        oldTower.baseWaypoint.isPlaceable = true; // free up the block that has been left behind
        newBaseWaypoint.isPlaceable = false;
        
        oldTower.baseWaypoint = newBaseWaypoint;

        oldTower.transform.position = newBaseWaypoint.transform.position + new Vector3(5f, 0f, 10f);

        towerQueue.Enqueue(oldTower); // put oldTower back on top, or at start of the queue
        
        print(towerQueue.Count);
    }
}
