using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCastle : MonoBehaviour {

    [SerializeField] int castleHealth = 10;

    [SerializeField] Text healthText;

    [SerializeField] ParticleSystem castleDestroyedPrefab;

    [SerializeField] AudioClip swordHit;

    private void Start()
    {
        healthText.text = castleHealth.ToString();
    }

    public void DamageCastle(int damage)
    {
        GetComponent<AudioSource>().PlayOneShot(swordHit);

        DecreaseHealth(damage);

        if (castleHealth <= 0)
        {
            Instantiate(castleDestroyedPrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

    private void DecreaseHealth(int damage)
    {
        castleHealth -= damage;
        healthText.text = castleHealth.ToString();
    }
}
