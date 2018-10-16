using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour {

    [SerializeField] Collider enemyCollider;
    [SerializeField] ParticleSystem deathBlood;

    [SerializeField] int healthPoints = 5;

    [SerializeField] ParticleSystem blood;
    [SerializeField] float bloodDuration = 1f;

    // Use this for initialization
    void Start()
    {

    }

    private void OnParticleCollision(GameObject other)
    {

        blood.Play();

        if (healthPoints > 1) {
            healthPoints--;
        }
        else 
        {
            var deathBloodFX = Instantiate(deathBlood, transform.position + new Vector3(0f, 2f, 0f), Quaternion.identity);
            deathBloodFX.Play();
            Destroy(gameObject);
        }

        
    }

 

}
