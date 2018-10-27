using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathSFXHost : MonoBehaviour {

    [SerializeField] AudioClip DeathSFX;

	// Use this for initialization
	void Start () {

        GetComponent<AudioSource>().PlayOneShot(DeathSFX);
        Destroy(gameObject, 2f);
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
