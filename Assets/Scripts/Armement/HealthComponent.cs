using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthComponent : MonoBehaviour
{
    [SerializeField]
    private int maxHealth = 1000;

    private float currentHealth;

    public void Start()
    {
        currentHealth = maxHealth;
    }
    public void TakeDamage(float damageAmount)
    {
        currentHealth -= damageAmount;
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
            print("la cible n'a plus de vie elle a été détruite");
        }
        else
        {
           print($"la cible s'est pris du dégât il reste {currentHealth} points de vie");
        }
    }
}

