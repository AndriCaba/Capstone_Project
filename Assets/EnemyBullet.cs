using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    private Rigidbody bulletRB;
    private GameObject target;
    public float speed = 10f;
    public float damage = 40f;



    void Start()
    {
        // Get the Rigidbody component on the same GameObject
        bulletRB = GetComponent<Rigidbody>();

        // Find the player using the tag "Player"
        target = GameObject.FindGameObjectWithTag("Player_Hitbox");

        if (target != null)
        {
            // Calculate the direction to the target
            Vector3 moveDir = (target.transform.position - transform.position).normalized;

            // Set the velocity of the Rigidbody to move towards the target
            bulletRB.velocity = moveDir * speed;

            // Note: If you want the bullet to rotate towards the target, you can use LookRotation
            bulletRB.rotation = Quaternion.LookRotation(moveDir);

            // Destroy the bullet after 2 seconds
            Destroy(this.gameObject, 2);
        }
        else
        {
            Debug.LogError("Player not found! Make sure the player has the tag 'Player'");
        }

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
