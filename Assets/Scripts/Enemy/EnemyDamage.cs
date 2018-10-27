using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour {

    [SerializeField] int healthPoints = 5;

    [SerializeField] AudioClip arrowImpactSFX;
    [SerializeField] DeathSFXHost deathSFXPrefab;

    [SerializeField] Collider enemyCollider;
    [SerializeField] ParticleSystem deathBlood;

    [SerializeField] ParticleSystem blood;

    Scorekeeper score;

    AudioSource audioSource;

    private void OnParticleCollision(UnityEngine.GameObject other)
    {
        score = FindObjectOfType<Scorekeeper>();

        audioSource = GetComponent<AudioSource>();

        blood.Play();
        audioSource.PlayOneShot(arrowImpactSFX);

        if (healthPoints > 1) {
            healthPoints--;
        }
        else
        {
            score.ScoreIncrease();

            DeathFX();

            Instantiate(deathSFXPrefab, transform.position, Quaternion.identity);

            Destroy(gameObject);
        }


    }

    private void DeathFX()
    {
        var deathBloodFX = Instantiate(deathBlood, transform.position + new Vector3(0f, 2f, 0f), Quaternion.identity);
        deathBloodFX.Play();

        float deathFXDelay = deathBloodFX.main.duration + 0.2f;
        Destroy(deathBloodFX.gameObject, deathFXDelay);
    }

}
