using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrolPath
{
    public List<Vector3> patrolPoints;

    public EnemyPatrolPath(List<Vector3> path)
    {
        patrolPoints = path;
    }
}
