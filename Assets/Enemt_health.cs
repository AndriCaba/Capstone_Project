using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemt_health : MonoBehaviour
{
   public float maxHealth = 100f;
    private float currentHealth;
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
