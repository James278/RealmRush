using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCastle : MonoBehaviour {

    [SerializeField] int castleHealth = 10;

    [SerializeField] Text healthText;

    private void Start()
    {
        healthText.text = castleHealth.ToString();
    }

    public void DecreaseHealth(int damage)
    {

        castleHealth -= damage;
        healthText.text = castleHealth.ToString();

        if (castleHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

}
