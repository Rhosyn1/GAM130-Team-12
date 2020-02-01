using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyNavMesh : MonoBehaviour
{
    public Transform target;
    private NavMeshAgent agent;

    public EnemyPatrolPath patrolPath;

    private EnemyPatrolPath currentPatrol;
    private int currentPoint;

    // Start is called before the first frame update
    void Start()
    {
        currentPatrol = new EnemyPatrolPath(new List<Vector3>()
        {
            new Vector3(20, 1, 44),
            new Vector3(20, 1, -1),
            new Vector3(-9, 1, -1),
            new Vector3(-9, 1, 44)
        });

        agent = GetComponent<NavMeshAgent>();
        if (patrolPath != null)
        {
            currentPatrol = patrolPath;
            currentPoint = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
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
        else
        {
            agent.SetDestination(target.position);
        }
    }
}
