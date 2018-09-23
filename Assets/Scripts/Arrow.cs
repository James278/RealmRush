using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour {

    [SerializeField] Transform targetEnemy;
    [SerializeField] Transform thisArrow;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        thisArrow.LookAt(targetEnemy);
		
	}
}
