using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyNavMesh : MonoBehaviour
{
    public Transform target;
    private NavMeshAgent agent;

    public List<Vector3> patrol;

    private EnemyPatrolPath patrolPath;

    private EnemyPatrolPath currentPatrol;
    private int currentPoint;

    public WindowScript windowSmashed;
    //setting the current point to 0 if path is null.
    void Start()
    {
        patrolPath = new EnemyPatrolPath(patrol);

        agent = GetComponent<NavMeshAgent>();
        if (patrolPath != null)
        {
            currentPatrol = patrolPath;
            currentPoint = 0;
        }
    }

   
    void Update()
    {
        //setting points for enemy
        if (currentPatrol != null)
        {
            agent.SetDestination(currentPatrol.patrolPoints[currentPoint]);

            if (Vector3.Distance(transform.position, currentPatrol.patrolPoints[currentPoint]) <= 2f)
            {
                currentPoint++;
                if (currentPoint > currentPatrol.patrolPoints.Count - 1)
                {
                    currentPoint = 0;
                }
            }
        }

        //if the enemy is within a certain distance from player then follow the player
        if (Vector3.Distance(transform.position, target.transform.position) <= 10f)
        {
            agent.SetDestination(target.transform.position);
        }

        if (agent.hasPath)
        {
            Debug.Log("has path");
        }
    }
}
