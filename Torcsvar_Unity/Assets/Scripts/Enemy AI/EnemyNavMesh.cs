using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyNavMesh : MonoBehaviour
{
    public enum EnemyState
    {
        walking,
        followingSound,
        chasing,
        looking
    };

    public Transform target;
    private NavMeshAgent agent;

    public List<Vector3> patrol;

    private EnemyPatrolPath patrolPath;

    private EnemyPatrolPath currentPatrol;
    private int currentPoint;

    private Vector3 soundLocation;

    [SerializeField]
    private float hearingDistance = 20f;

    //animations
    private Animator anim;

    public EnemyState enemyState;
    void Start()
    {
        patrolPath = new EnemyPatrolPath(patrol);

        agent = GetComponent<NavMeshAgent>();

        if (patrolPath != null)
        {
            currentPatrol = patrolPath;
            currentPoint = 0;
        }

        anim = GetComponent<Animator>();
        anim.SetBool("walkBool", true);
        enemyState = EnemyState.walking;
    }

    private void Update()
    {
        anim.SetBool("crawlBool", false);
        //setting points for enemy
        if (currentPatrol != null && enemyState != EnemyState.followingSound)
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
            anim.SetBool("crawlBool", true);
            agent.SetDestination(target.transform.position);
            enemyState = EnemyState.chasing;
        }

        //checking if followsound is equal to true and enemy is less than or equals to 2m from the soundlocation then followingsound is equal to false and enemy begins patroling again. 
        if (enemyState == EnemyState.followingSound && Vector3.Distance(gameObject.transform.position, soundLocation) <= 2f)
        {
            anim.SetBool("lookTrigger", true);
            enemyState = EnemyState.looking;
        }
    }

    public void ReachedSoundDestination()
    {
        anim.SetBool("lookTrigger", false);
        enemyState = EnemyState.walking;
    }

    public void ReactToSound(Vector3 source)
    {
        //Looking for colliders within a sphere from the player up to the hearing distance already set.
        Collider[] collidersFound = Physics.OverlapSphere(source, hearingDistance);

        //going through all the colliders found in list
        foreach (Collider coll in collidersFound)
        {
            //if an object within hearing distance has the tag enemy then enemy goes to the source.
            if (coll.gameObject.CompareTag("Enemy"))
            {
                agent.SetDestination(source);
                UpdateHearingStatus(source);
                break;
            }
        }
    }

    //updates the status of following and location
    public void UpdateHearingStatus(Vector3 location)
    {
        enemyState = EnemyState.followingSound;
        soundLocation = location;
    }
}
