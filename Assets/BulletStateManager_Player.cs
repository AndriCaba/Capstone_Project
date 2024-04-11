using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletStateManager_Player : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    public float damage = 40;

    private GameObject target;
    private Rigidbody bulletRB;

    void Start()
    {
        bulletRB = GetComponent<Rigidbody>();

        // Find all objects with the "Selectable" tag
        GameObject[] targets = GameObject.FindGameObjectsWithTag("Selectable");

        if (targets.Length > 0)
        {
            // Find the nearest target
            target = FindNearestTarget(targets);

            if (target != null)
            {
                // Calculate the direction from the bullet's position to the nearest target's position
                Vector3 moveDir = (target.transform.position - transform.position).normalized;

                // Set the velocity of the Rigidbody to move towards the nearest target
                bulletRB.velocity = moveDir * speed;

                // Note: If you want the bullet to rotate towards the target, you can use LookRotation
                bulletRB.rotation = Quaternion.LookRotation(moveDir);

                // Destroy the bullet after 3 seconds
                Destroy(this.gameObject, 3);
            }
            else
            {
                Debug.LogError("Failed to find the nearest target.");
            }
        }
        else
        {
            Debug.LogError("No objects with the tag 'Selectable' found.");
        }
    }

    void OnTriggerEnter(Collider hitInfo)
    {
        Enemt_health enemy = hitInfo.GetComponent<Enemt_health>();

        Debug.Log(hitInfo.name);
        enemy.TakeDamage(damage);
        if (enemy != null)
        {
            
             enemy.TakeDamage(damage);
        }
        else{
                 Debug.LogError("Collider hitInfo is null!");
            

        }
        Destroy(this.gameObject);
        
    }

    GameObject FindNearestTarget(GameObject[] targets)
    {
        GameObject nearestTarget = null;
        float nearestDistance = Mathf.Infinity;

        foreach (GameObject target in targets)
        {
            float distance = Vector3.Distance(transform.position, target.transform.position);

            if (distance < nearestDistance)
            {
                nearestTarget = target;
                nearestDistance = distance;
            }
        }

        return nearestTarget;
    }
}
