using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour {

    Dictionary<Vector2Int, Waypoint> worldGrid = new Dictionary<Vector2Int, Waypoint>();
    Queue<Waypoint> queue = new Queue<Waypoint>();

    [SerializeField] bool isRunning = true;

    [SerializeField] Waypoint startPoint, endPoint;

    Vector2Int[] directions = {
       Vector2Int.up,
       Vector2Int.left,
       Vector2Int.right,
       Vector2Int.down
    };

    // Use this for initialization
    void Start () {

        LoadBlocks();
        ColourStartAndEnd();
        Pathfind();
        //ExploreNeighbours();
	}

    private void LoadBlocks()
    {
        Array waypoints = FindObjectsOfType<Waypoint>();
        foreach(Waypoint waypoint in waypoints)
        {
            var gridPos = waypoint.GetGridPos();

            if (worldGrid.ContainsKey(gridPos))
            {
                Debug.LogWarning("Skipping overlapping cube " + waypoint);
            }
            else
            {
                worldGrid.Add(gridPos, waypoint);
                
            }
        }
    }

    private void ColourStartAndEnd()
    {
        startPoint.SetColour(Color.white);

        endPoint.SetColour(Color.green);
    }

    private void ExploreNeighbours()
    {
        foreach (Vector2Int direction in directions) 
        {
            Vector2Int neighbours = startPoint.GetGridPos() + direction;

            try
            {
                worldGrid[neighbours].SetColour(Color.cyan);
            }
            catch
            {
                print ("No neighbours found at " + neighbours);
            }
        }
    }

    private void Pathfind()
    {
        queue.Enqueue(startPoint);
        while (queue.Count >= Mathf.Epsilon && isRunning)
        {
            Waypoint searchCenter = queue.Dequeue();
            print("Searching from " + searchCenter);

            HaltIfEndPointFound(searchCenter);
        }
        print("Outside of algorithm");
    }

    void HaltIfEndPointFound(Waypoint searchCenter)
    {
        if (searchCenter == endPoint)
        {
            print("EndPoint found. Get outta here!");
            isRunning = false;
        }
    }

}
