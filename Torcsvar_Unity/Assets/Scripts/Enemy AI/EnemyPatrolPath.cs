using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrolPath
{
    //public list and instance for EnemyNavMesh script
    public List<Vector3> patrolPoints;

    public EnemyPatrolPath(List<Vector3> path)
    {
        patrolPoints = path;
    }
}
