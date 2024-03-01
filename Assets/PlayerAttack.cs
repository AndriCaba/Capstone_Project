using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{

    public float attackRange = 1.5f; // Range of the attack
    public int attackDamage = 100; // Damage dealt per attack
    public LayerMask enemyLayer; // Layer containing the enemy objects
    private Transform player;




    //fire script 
    public Transform firepoint;
    public Transform bulletParent;
    public GameObject bulletPrefab;
    public SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
     void Update()
    {
       
    }

    public void Attack()
    {

        
        Shoot();

    }
    void Shoot()
    {



        Instantiate(bulletPrefab, firepoint.position, Quaternion.identity);

    }
}

