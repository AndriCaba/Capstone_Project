using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthbar : MonoBehaviour
{
 public float maxHealth = 100f;
    public float currentHealth;
    public Healthbar_script healthbar;

    void Start()
    {
        currentHealth = maxHealth;
        healthbar.SetMaxHealth(maxHealth);
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        healthbar.SetHealth(currentHealth , maxHealth);
       
    }
}
