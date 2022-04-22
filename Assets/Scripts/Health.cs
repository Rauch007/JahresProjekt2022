using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public int maxHealth = 5;
    int currentHealth;
    public ParticleSystem slimeparticle;

    public Image health1;
    public Image health2;
    public Image health3;
    public Image health4;
    public Image health5;

    public Sprite healthFull;
    public Sprite healthEmpty;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Damage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Die();
        }

        //Update Healthbar
        switch(currentHealth)
        {
            case 5:
                health1.sprite = healthFull;
                break;

            case 4:
                health2.sprite = healthFull;
                health1.sprite = healthEmpty;
                break;

            case 3:
                health3.sprite = healthFull;
                health2.sprite = healthEmpty;
                break;
            case 2:
                health4.sprite = healthFull;
                health3.sprite = healthEmpty;
                break;

            case 1:
                health5.sprite = healthFull;
                health4.sprite = healthEmpty;

                break;
            case 0:
                health5.sprite = healthEmpty;
                break;

        }
    }

    void Die()
    {
        //Debug.Log("Death");       
        slimeparticle.transform.position = gameObject.transform.position;
        slimeparticle.Play();
        Destroy(gameObject);
    }
}
