using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour {

    [SerializeField] Collider enemyCollider;

    [SerializeField] int healthPoints = 5;

    [SerializeField] GameObject blood;
    [SerializeField] float bloodDuration = 1f;

    // Use this for initialization
    void Start()
    {

    }

    private void OnParticleCollision(GameObject other)
    {

     //   Destroy(other);
        StartCoroutine(toggleBlood());

        if (healthPoints > 1) {
            healthPoints--;
        }
        else 
        {
            Destroy(gameObject);
        }

        
    }

    IEnumerator toggleBlood()
    {
        blood.SetActive(true);
        yield return new WaitForSeconds(bloodDuration);
        blood.SetActive(false);
    }

}
