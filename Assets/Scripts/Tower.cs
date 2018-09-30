using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour {

    [SerializeField] Transform targetEnemy;
    [SerializeField] Transform tower;

    private void Start()
    {

    }

    // Update is called once per frame
    void Update () {


        tower.LookAt(targetEnemy);
        
        
        
    }
}
