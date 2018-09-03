﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour {

    Vector2Int gridPos;
    Vector3 snapPos;

    const int gridSize = 10;

    public int GetGridSize()
    {
        return gridSize;
    }

    public Vector2Int GetGridPos()
    {
        return new Vector2Int(
        Mathf.RoundToInt(transform.position.x / gridSize),
        Mathf.RoundToInt(transform.position.z / gridSize)
        );
        
    }

    public void SetColour(Color colour)
    {
        Transform cubeTop = transform.Find("Quad Top");
        MeshRenderer topMeshRenderer = cubeTop.GetComponent<MeshRenderer>();
        topMeshRenderer.material.color = colour;
    }

}