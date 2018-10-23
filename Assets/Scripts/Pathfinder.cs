using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour {

    Dictionary<Vector2Int, Waypoint> worldGrid = new Dictionary<Vector2Int, Waypoint>();
    Queue<Waypoint> queue = new Queue<Waypoint>();

    Waypoint searchCenter;

    bool isRunning = true;

    [SerializeField] List<Waypoint> path = new List<Waypoint>();

    [SerializeField] Waypoint startPoint, endPoint;

    Vector2Int[] directions = {
       Vector2Int.up,
       Vector2Int.left,
       Vector2Int.right,
       Vector2Int.down
    };

    public List<Waypoint> GetPath()
    {
        if (path.Count == 0)
        {
            LoadBlocks();
            ColourStartAndEnd();
            BreadthFirstSearch();
            CreatePath();
        }
            return path;
        
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

    private void BreadthFirstSearch()
    {
        queue.Enqueue(startPoint);
        while (queue.Count >= Mathf.Epsilon && isRunning)
        {
            searchCenter = queue.Dequeue();
            searchCenter.isExplored = true;

            HaltIfEndPointFound();
            ExploreNeighbours();
        }
        print("Outside of algorithm");
    }

    void HaltIfEndPointFound()
    {
        if (searchCenter == endPoint)
        {
            print("EndPoint found. Get outta here!");
            isRunning = false;
        }
    }

    private void ExploreNeighbours()
    {
        if (!isRunning)
        {
            return;
        }
        foreach (Vector2Int direction in directions)
        {
            Vector2Int neighbour = searchCenter.GetGridPos() + direction;

            if (worldGrid.ContainsKey(neighbour))
            {
                QueueNewNeighbours(neighbour);
            }
            else
            {
                // do nothing
            }
        }
    }

    private void QueueNewNeighbours(Vector2Int neighbour)
    {
        if (worldGrid[neighbour].isExplored || queue.Contains(worldGrid[neighbour]))
        {
            return;
        }
        else
        {
            queue.Enqueue(worldGrid[neighbour]);
            worldGrid[neighbour].exploredFrom = searchCenter;
            
        }
        
    }

    private void CreatePath()
    {
        SetAsPath(endPoint);

        Waypoint previous = endPoint.exploredFrom;

        while (previous != startPoint)
        {
            SetAsPath(previous);
            previous = previous.exploredFrom;
        }

        SetAsPath(startPoint);
        path.Reverse();
    }

    void SetAsPath (Waypoint waypoint)
    {
        path.Add(waypoint);
        waypoint.isPlaceable = false;
    }

}
