using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCastle : MonoBehaviour {

    [SerializeField] int castleHealth = 10;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

      
		
	}

    public void DecreaseHealth()
    {
        castleHealth--;

        if (castleHealth <= 0)
        {
            print("Castle is destroyed");
            Destroy(gameObject);
        }
    }

}
