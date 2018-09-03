using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour {

    Dictionary<Vector2Int, Waypoint> worldGrid = new Dictionary<Vector2Int, Waypoint>();

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
        ExploreNeighbours();
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
    
}
