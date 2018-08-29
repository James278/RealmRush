using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[SelectionBase]
public class CubeEditor : MonoBehaviour {

    [Range(1f, 20f)]
    [SerializeField] float gridSize = 10f;

    TextMesh textMesh;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        Vector3 snapPos;

        snapPos.x = Mathf.RoundToInt(transform.position.x / gridSize) * gridSize;
        snapPos.z = Mathf.RoundToInt(transform.position.z / gridSize) * gridSize;

        textMesh = gameObject.GetComponentInChildren<TextMesh>();
        string cubeLabel = snapPos.x / gridSize + "," + snapPos.z / gridSize;
        textMesh.text = snapPos.x / gridSize + "," + snapPos.z / gridSize;

        gameObject.name = "Cube: " + cubeLabel;

        transform.position = new Vector3(snapPos.x, 0, snapPos.z);
		
	}
}
