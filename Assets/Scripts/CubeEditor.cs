using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[SelectionBase]
[RequireComponent(typeof(Waypoint))]
public class CubeEditor : MonoBehaviour {

    Waypoint waypoint;

    private void Awake()
    {
        waypoint = GetComponent<Waypoint>();
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        SnapCubeToGrid();

        UpdateLabel();

    }

    private void SnapCubeToGrid()
    {
        int gridSize = waypoint.GetGridSize();

        transform.position = new Vector3(
            waypoint.GetGridPos().x,
            0, 
            waypoint.GetGridPos().y); // still the z position
    }

    private void UpdateLabel()
    {
        int gridSize = waypoint.GetGridSize();

        TextMesh textMesh = gameObject.GetComponentInChildren<TextMesh>();
        string cubeLabel = waypoint.GetGridPos().x / 
                           gridSize + "," +    
                           waypoint.GetGridPos().y / 
                           gridSize;

        textMesh.text = cubeLabel;

        gameObject.name = "Cube: " + cubeLabel;
    }
}
