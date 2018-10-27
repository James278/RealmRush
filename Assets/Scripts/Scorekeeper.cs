using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scorekeeper : MonoBehaviour {

    int enemyDeaths = 0;

    [SerializeField] Text scoreText;

	// Use this for initialization
	void Start () {

        scoreText.text = enemyDeaths.ToString();
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ScoreIncrease()
    {
        enemyDeaths++;
        scoreText.text = enemyDeaths.ToString();
    }

}
