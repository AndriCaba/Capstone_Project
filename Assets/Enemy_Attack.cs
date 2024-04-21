using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Enemy_Attack : MonoBehaviour
{
    // public Transform[] waypoints;
    // public float patrolSpeed = 2f;
    // public float chaseSpeed = 5f;
    // public float lineOfSight = 5f;
    // public float shootingRange = 3f;
    public float fireRate = 1f;


    public GameObject bulletPrefab;
    public Transform bulletParent;


    private Animator animator;
    public float rotationSpeed;
    private Transform player;




    private int currentWaypointIndex = 0;
    private float nextFireTime;

/// -------Insert code -------
public NavMeshAgent agent;

    public Transform Player;
    // public GameObject gun;

    //Stats
    // public int health;

    //Check for Ground/Obstacles
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

/// -------------



    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Hit").transform;
        animator = GetComponent<Animator>();
    }

    private void Awake()
    {
       player = GameObject.Find("Player").transform; 
        agent = GetComponent<NavMeshAgent>();
    }
    void Update()
    {
        // float distanceFromPlayer = Vector3.Distance(player.position, transform.position);



        // if (distanceFromPlayer < lineOfSight && distanceFromPlayer > shootingRange)
        // {
        //     // Chase the player
            
     
        //     ChasePlayer();
         
        // }
        // else if (distanceFromPlayer <= shootingRange && nextFireTime < Time.time)
        // {
        //     // Chase the player
          
          
        //     ChasePlayer();

        //     // Shoot
        //     Shoot();
        //     nextFireTime = Time.time + fireRate;
        // }
        // else
        // {

        //     // Patrol between waypoints
        //     animator.SetBool("IsMoving", false);
        //     Patrol();
        // }


        //---- insert new code -----//

         if (!isDead)
        {
            //Check if Player in sightrange
            playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);

            //Check if Player in attackrange
            playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

            if (!playerInSightRange && !playerInAttackRange) Patroling();
            if (playerInSightRange && !playerInAttackRange) ChasePlayer();
            if (playerInAttackRange && playerInSightRange) Shoot();
        }
    }

    void Patroling()
    {
        // Move towards the current waypoint
        // transform.position = Vector3.MoveTowards(transform.position, waypoints[currentWaypointIndex].position, patrolSpeed * Time.deltaTime);

        // // Check if the enemy has reached the current waypoint
        // if (Vector3.Distance(transform.position, waypoints[currentWaypointIndex].position) < 0.1f)
        // {
        //     // Move to the next waypoint
        //     currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;
        // }

         //---- insert new code -----//

          if (isDead) return;

        if (!walkPointSet) SearchWalkPoint();

        //Calculate direction and walk to Point
        if (walkPointSet){
            agent.SetDestination(walkPoint);

            //Vector3 direction = walkPoint - transform.position;
            //transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), 0.15f);
        }

        //Calculates DistanceToWalkPoint
        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        //Walkpoint reached
        if (distanceToWalkPoint.magnitude < 1f)
            walkPointSet = false;

        GetComponent<MeshRenderer>().material = green;
    }

    void ChasePlayer()
    {
        // // Move towards the player
        // animator.SetBool("IsMoving", true);
       
        // transform.position    = Vector3.MoveTowards(transform.position, player.position, chaseSpeed * Time.deltaTime);
        
         //---- insert new code -----//
          if (isDead) return;

        agent.SetDestination(player.position);

        GetComponent<MeshRenderer>().material = yellow;
    }
     private void SearchWalkPoint()
    {
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(walkPoint,-transform.up, 2,whatIsGround))
        walkPointSet = true;
    }

    void Shoot()
    {


        Instantiate(bulletPrefab, bulletParent.position, Quaternion.identity);

         //---- insert new code -----//
    }

        // private void AttackPlayer(){

        // if (isDead) return;

        // //Make sure enemy doesn't move
        // agent.SetDestination(transform.position);

        // transform.LookAt(player);

        // if (!alreadyAttacked){

        //     //Attack
        //     Rigidbody rb = Instantiate(projectile, transform.position, Quaternion.identity).GetComponent<Rigidbody>();

        //     rb.AddForce(transform.forward * 32f, ForceMode.Impulse);
        //     rb.AddForce(transform.up * 8, ForceMode.Impulse);

        //     alreadyAttacked = true;
        //     Invoke("ResetAttack", timeBetweenAttacks);
        // }

        // GetComponent<MeshRenderer>().material = red;



        // }
        //   private void ResetAttack()
        // {
        // if (isDead) return;

        // alreadyAttacked = false;
        // }

    private void OnDrawGizmosSelected()
    {
        // Gizmos.color = Color.green;
        // Gizmos.DrawWireSphere(transform.position, lineOfSight);
        // Gizmos.DrawWireSphere(transform.position, shootingRange);


        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, sightRange);
    }
}
