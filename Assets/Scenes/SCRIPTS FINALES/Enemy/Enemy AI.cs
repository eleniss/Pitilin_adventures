using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{

    public NavMeshAgent agent;
    public Transform player;
    public LayerMask whatIsGround;
    public LayerMask whatIsPlayer;

    public float health;

    // Para Patroling
    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRage;

    // Para Attacking
    public float timeBetweenAttacks;
    bool alreadyAttacked;
    public GameObject AtaqueEnemigo;

    // States
    public float sightRange;
    public float attackRange;
    public bool playerInSightRange;
    public bool playerInAttackRange;

    private void Awake()
    {
        player = GameObject.Find("Player").transform;
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame

    void Update()
    {
        // Vemos si el player està en Sight o Attack Range
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);

        if (!playerInSightRange && !playerInAttackRange) Patroling();
        if (playerInSightRange && !playerInAttackRange) ChasePlayer();
        if (playerInSightRange && playerInAttackRange) AttackPlayer();
    }

    private void Patroling()
    {
        if (!walkPointSet)
        {
            SearchWalkPoint();
        }

        if (walkPointSet)
        {
            agent.SetDestination(walkPoint);
        }

        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        // Si la distancia es < 1
        if (distanceToWalkPoint.magnitude < 1f)
        {
            walkPointSet = false;
            // Automaticamete buscará uno nuevo
        }
    }

    private void SearchWalkPoint()
    {
        // Calculamos un punto random en el range
        float randomZ = Random.Range(-walkPointRage, walkPointRage);
        float randomX = Random.Range(-walkPointRage, walkPointRage);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        // Mirar si el punto random encontrado está en el mapa
        if (Physics.Raycast(walkPoint, -transform.up, 200f, whatIsGround))
        {
            walkPointSet = true;
        }
    }

    private void ChasePlayer()
    {
        agent.SetDestination(player.position);
    }

    private void AttackPlayer()
    {
        // Nos aseguramos de que el enemy no se mueve
        agent.SetDestination(transform.position);

        agent.velocity = Vector3.zero; // Atura l'agent immediatament

        transform.LookAt(player);

        if (!alreadyAttacked)
        {
            // Attack code here
            /*Rigidbody rb = Instantiate(projectile, transform.position, Quaternion.identity).GetComponent<Rigidbody>();
            rb.AddForce(transform.forward * 32f, ForceMode.Impulse);
            rb.AddForce(transform.up * 8f, ForceMode.Impulse);
            */
            // Calcula la direcció cap al player
            Vector3 targetPosition = player.position;
            //targetPosition.y += 1.0f; // Apunta una mica més amunt (cap al centre del player)

            // Direcció cap al jugador
            Vector3 direction = (targetPosition - transform.position).normalized;

            // Instancia el projectil i llança'l
            Rigidbody rb = Instantiate(AtaqueEnemigo, transform.position, Quaternion.identity).GetComponent<Rigidbody>();
            rb.AddForce(direction * 200f, ForceMode.Impulse); // Ajusta la força segons sigui necessari


            // 
            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }

    private void ResetAttack()
    {
        alreadyAttacked = false;
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Invoke(nameof(DestroyEnemy), 0.5f);
        }
    }

    private void DestroyEnemy()
    {
        Destroy(gameObject);
    }
}
