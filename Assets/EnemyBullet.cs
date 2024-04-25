using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
 private Rigidbody bulletRB;
    public float speed = 10f;
    public float damage = 40f;

    void Start()
    {
        // Get the Rigidbody component on the same GameObject
        bulletRB = GetComponent<Rigidbody>();

        // Set the velocity of the Rigidbody to move forward
        bulletRB.velocity = transform.forward * speed;

        // Destroy the bullet after 2 seconds
        Destroy(this.gameObject, 2);
    }

    void OnTriggerEnter(Collider hitInfo)
    {
        Debug.Log(hitInfo.name);
        PlayerHealthbar enemy = hitInfo.GetComponent<PlayerHealthbar>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage);
        }

        Destroy(gameObject);
    }
}
