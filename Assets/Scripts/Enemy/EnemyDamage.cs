using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour {

    [SerializeField] Collider enemyCollider;
    [SerializeField] ParticleSystem deathBlood;

    [SerializeField] int healthPoints = 5;

    [SerializeField] ParticleSystem blood;

    private void OnParticleCollision(UnityEngine.GameObject other)
    {

        blood.Play();

        if (healthPoints > 1) {
            healthPoints--;
        }
        else 
        {
            var deathBloodFX = Instantiate(deathBlood, transform.position + new Vector3(0f, 2f, 0f), Quaternion.identity);
            deathBloodFX.Play();

            float deathFXDelay = deathBloodFX.main.duration + 0.2f;

            Destroy(deathBloodFX.gameObject, deathFXDelay);
            Destroy(gameObject);
        }

        
    }

 

}
