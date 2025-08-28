using UnityEngine;
using UnityEngine.AI;

public class ChaseAI : MonoBehaviour
{
    public Transform player;
    public Transform[] waypoints;
    private NavMeshAgent agent;
    private int currentWaypoint = 0;
    private bool chasing = false;

    public float chaseDistance = 8f; // detection radius

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        PatrolToNextWaypoint();
    }

    private void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (distanceToPlayer < chaseDistance)
        {
            chasing = true;
            agent.SetDestination(player.position);
        }
        else
        {
            if (chasing)
            {
                chasing = false;
                PatrolToNextWaypoint();
            }

            if (!agent.pathPending && agent.remainingDistance < 0.5f)
            {
                PatrolToNextWaypoint();
            }
        }
    }

    private void PatrolToNextWaypoint()
    {
        if (waypoints.Length == 0) return;

        agent.SetDestination(waypoints[currentWaypoint].position);
        currentWaypoint = (currentWaypoint + 1) % waypoints.Length;
    }
}