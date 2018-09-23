using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour {

    [SerializeField] Transform targetEnemy;
    [SerializeField] Transform tower;

    ParticleSystem arrows;

    private void Start()
    {
        arrows = GetComponentInChildren<ParticleSystem>();
    }

    // Update is called once per frame
    void Update () {


        tower.LookAt(targetEnemy);
        
        
        
    }
}
