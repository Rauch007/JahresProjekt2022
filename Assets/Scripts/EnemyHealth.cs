using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth;
    int currentHealth;
    public ParticleSystem bloodparticle;
    
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        //Debug.Log("damage");
        currentHealth -= damage;

        if(currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        //Debug.Log("Death");       
        bloodparticle.transform.position = gameObject.transform.position;
        bloodparticle.Play();
        Destroy(gameObject);

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
