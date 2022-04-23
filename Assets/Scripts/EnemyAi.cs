using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class EnemyAi : MonoBehaviour
{
    [SerializeField] private float chaseRange = 5.0f;
    [SerializeField] private float turnSpeed = 5.0f;

    private Transform target;
    private NavMeshAgent navMeshAgent;
    private float distanceToTarget = float.MaxValue;
    private bool isProvoked = false;
    private EnemyHealth health = null;

    private void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        health = GetComponent<EnemyHealth>();

        target = FindObjectOfType<PlayerHealth>().transform;
    }

    private void Update()
    {
        if (health.IsDead)
        {
            navMeshAgent.enabled = false;
            enabled = false;
            return;
        }

        distanceToTarget = Vector3.Distance(target.position, transform.position);

        if (isProvoked)
        {
            EngageTarget();
        }
        else if (distanceToTarget <= chaseRange)
        {
            isProvoked = true;
        }
    }

    public void OnDamageTaken()
    {
        isProvoked = true;
    }

    private void EngageTarget()
    {
        FaceTarget();

        if (distanceToTarget > navMeshAgent.stoppingDistance)
        {
            ChaseTarget();
        }
        else
        {
            AttackTarget();
        }
    }

    private void ChaseTarget()
    {
        GetComponent<Animator>().SetTrigger("Move");
        GetComponent<Animator>().SetBool("Attack", false);
        navMeshAgent.SetDestination(target.position);
    }

    private void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position);
        direction.y = 0;
        direction.Normalize();

        Quaternion lookRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * turnSpeed);
    }

    private void AttackTarget()
    {
        GetComponent<Animator>().SetBool("Attack", true);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, chaseRange);
    }
}
