using UnityEngine;
using UnityEngine.AI;

public class PatrolAI : MonoBehaviour
{
    public Transform[] waypoints;
    private int currentWaypoint = 0;
    private NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        if (waypoints.Length > 0)
        {
            agent.destination = waypoints[currentWaypoint].position;
        }
    }

    void Update()
    {
        if (!agent.pathPending && agent.remainingDistance < 0.5f)
        {
            currentWaypoint = (currentWaypoint + 1) % waypoints.Length;
            agent.destination = waypoints[currentWaypoint].position;
        }
    }
}
