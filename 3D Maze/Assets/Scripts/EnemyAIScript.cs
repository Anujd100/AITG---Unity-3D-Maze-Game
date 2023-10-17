// Patrol.cs
using UnityEngine;
using UnityEngine.AI;
using System.Collections;


public class EnemyAIScript : MonoBehaviour
{
    public NavMeshAgent agent;

    public Transform player;

    public LayerMask whatIsGround, whatIsPlayer;

    public float enemyHealth;

    public float patrolSpeed = 5.0f;
    public float pursuitSpeed = 10.0f;
    public int killEnemyScore;
    private int enemyKills;
    public Transform[] points;
   
    //Patroling
    public Vector3 walkPoint;
    public bool enemyMovementEnabled = true;
    bool walkPointSet;
    public float walkPointRange;

    //Attacking
    public float timeBetweenAttacks;
    bool alreadyAttacked;
    
    //States
    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;

    public GameObject enemyBullet;
    public Transform spawnPoint;
    public float enemyProjectileSpeed;

    private void OnEnable()
    {
        PlayerHealth.OnPlayerDeath += DisableEnemyMovement;
        EndLevelManager.OnLevelCompleted += DisableEnemyMovement;
    }

    private void OnDisable()
    {
        PlayerHealth.OnPlayerDeath -= DisableEnemyMovement;
        EndLevelManager.OnLevelCompleted -= DisableEnemyMovement;
    }

    private void Awake()
    {
        player = GameObject.Find("Player").transform;
        agent = GetComponent<NavMeshAgent>();
    }

    private void Start()
    {
        enemyMovementEnabled = true;
        enemyKills = 0;
}

    private void Update()
    {
        if (!enemyMovementEnabled) return;

        //Check for sight and attack range
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        if (!playerInSightRange && !playerInAttackRange) Patroling();
        if (playerInSightRange && !playerInAttackRange) ChasePlayer();
        if (playerInSightRange && playerInAttackRange) AttackPlayer();

        //Draw the agent's path with a red line
        NavMeshPath path = agent.path;

        for (int i = 0; i < path.corners.Length - 1; i++)
        {
            Debug.DrawLine(path.corners[i], path.corners[i + 1], Color.red);
        }
    }

    private void Patroling()
    {
        if (!walkPointSet) SearchWalkPoint();

        if (walkPointSet)
        {
            agent.speed = pursuitSpeed;
            agent.SetDestination(walkPoint);
        }

        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        //Walkpoint reached
        if (distanceToWalkPoint.magnitude < 1f)
            walkPointSet = false;
    }

    private void SearchWalkPoint()
    {
        int destPoint = Random.Range(0, points.Length - 1);

        walkPoint = new Vector3(points[destPoint].position.x, points[destPoint].position.y, points[destPoint].position.z);

        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
            walkPointSet = true;
    }

    private void ChasePlayer()
    {
        agent.speed = pursuitSpeed;
        agent.SetDestination(player.position);
    }

    private void AttackPlayer()
    {
        //Make sure enemy doesn't move
        agent.SetDestination(transform.position);

        transform.LookAt(player);

        if (!alreadyAttacked) 
        {
            //Attack code
            ShootAtPlayer();
            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }

    void ShootAtPlayer()
    {
        GameObject bulletObj = Instantiate(enemyBullet, spawnPoint.transform.position, spawnPoint.transform.rotation) as GameObject;
        bulletObj.SetActive(true);
        Rigidbody bulletRig = bulletObj.GetComponent<Rigidbody>();
        bulletRig.AddForce(bulletRig.transform.forward * enemyProjectileSpeed);
        Destroy(bulletObj, 1f);
    }

    public void TakeDamage(int damage)
    {
        enemyHealth -= damage;

        if (enemyHealth <= 0) Invoke(nameof(DestroyEnemy), 0.5f);
    }
    
    private void DestroyEnemy()
    {
        Destroy(gameObject);
        PlayerHUD.totalScore += killEnemyScore;
        PlayerHUD.levelScore += killEnemyScore;
        enemyKills++;
    }

    private void ResetAttack()
    {
        alreadyAttacked = false;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, sightRange);
    }

    private void DisableEnemyMovement()
    {
        enemyMovementEnabled = false;
    }

    private void EnableEnemyMovement()
    {
        enemyMovementEnabled = true;
    }
}