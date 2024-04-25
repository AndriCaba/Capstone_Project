using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy_Attack : MonoBehaviour
{
    public float fireRate = 1f;
    private float nextFireTime = 0f;

    public GameObject bulletPrefab;
    public Transform bulletParent;

    private Animator animator;
    public float rotationSpeed;
    private Transform player;

    private NavMeshAgent agent;

    public Transform Player;
  
    public LayerMask whatIsGround, whatIsPlayer;

    //Patroling
    public Vector3 walkPoint;
    public bool walkPointSet;
    public float walkPointRange;

    //Attack Player
    public float timeBetweenAttacks;
    bool alreadyAttacked;

    //States
    public bool isDead;
    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;

    //Special
    public Material green, red, yellow;
    public GameObject projectile;

    void Start()
    {
        player = GameObject.Find("Player").transform;
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (!isDead)
        {
            //Check if Player in sight range
            playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);

            //Check if Player in attack range
            playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

            if (!playerInSightRange && !playerInAttackRange) 
            {
                Patroling();
            }
            if (playerInSightRange && !playerInAttackRange) 
            {
                ChasePlayer();
            }
            if (playerInAttackRange && Time.time >= nextFireTime) 
            {
                Shoot();
                nextFireTime = Time.time + 1f / fireRate; // Update next fire time
            }
        }
    }

    void Patroling()
    {
        if (isDead) return;

        if (!walkPointSet) 
        {
            SearchWalkPoint();
        }

        //Calculate direction and walk to Point
        if (walkPointSet)
        {
            agent.SetDestination(walkPoint);
            Vector3 direction = walkPoint - transform.position;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), rotationSpeed * Time.deltaTime);
        }

        //Calculates DistanceToWalkPoint
        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        //Walkpoint reached
        if (distanceToWalkPoint.magnitude < 1f)
        {
            walkPointSet = false;
        }

        GetComponent<MeshRenderer>().material = green;
    }

    void ChasePlayer()
    {
        if (isDead) return;

        agent.SetDestination(player.position);
        GetComponent<MeshRenderer>().material = yellow;
    }

    private void SearchWalkPoint()
    {
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(walkPoint, -transform.up, 2, whatIsGround))
        {
            walkPointSet = true;
        }
    }

    void Shoot()
    {
        if (isDead) return;

        // Make sure enemy doesn't move
        agent.SetDestination(transform.position);
        transform.LookAt(player);
    
        Instantiate(bulletPrefab, bulletParent.position, Quaternion.identity);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, sightRange);
    }
}
