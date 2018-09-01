using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour {

    Dictionary<Vector2Int, Waypoint> worldGrid = new Dictionary<Vector2Int, Waypoint>();

	// Use this for initialization
	void Start () {

        LoadBlocks();
		
	}

    private void LoadBlocks()
    {
        Array waypoints = FindObjectsOfType<Waypoint>();
        foreach(Waypoint waypoint in waypoints)
        {
            Vector2Int gridPos = waypoint.GetGridPos();

            if (worldGrid.ContainsKey(gridPos))
            {
                Debug.LogWarning("Skipping overlapping cube " + waypoint);
            }
            else
            {
                worldGrid.Add(gridPos, waypoint);
            }
        }
        print("Loaded cubes: " + worldGrid.Count);
    }

    // Update is called once per frame
    void Update () {
		
	}
}
