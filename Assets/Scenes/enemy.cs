using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


/// ME HE QUEDADO POR EL 2:32 DELTUTO  https://www.youtube.com/watch?v=UjkSFoLxesw
public class enemy : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform player;
    public LayerMask whatIsGrouns, whatIsPlayer;

    //Patroling
    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;

    //Atacar
    public float timebetweenAttacks;
    bool alreadyAttacked;

    //States
    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;

    private void Awake()
    {
        player = GameObject.Find("Player").transform;
        agent = GetComponent<NavMeshAgent>();

    }
    private void Update()
    {
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        if (!playerInSightRange && !playerInAttackRange) { Patroling(); }
        if (playerInSightRange && !playerInAttackRange) { ChasePlayer(); }
        if (playerInSightRange && playerInAttackRange) { AttackPlayer(); }

    }
    private void Patroling()
    {
        if (!walkPointSet)
        {
            SearchWalkPoint();
        }
    }

    private void SearchWalkPoint()
    {
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

    }


    private void ChasePlayer()
    {

    }

    private void AttackPlayer()
    {

    }

}
