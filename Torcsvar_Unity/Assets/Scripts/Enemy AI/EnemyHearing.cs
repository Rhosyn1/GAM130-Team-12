using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyHearing : MonoBehaviour
{
    public GameObject Player;
    public AudioSource audioSource;

    private NavMeshAgent Agent;
    private Transform Target;
    private float distancePlayer;
    public bool playerHeard;

    public float[] hearingRange = new float[] { 10.0f, 16.0f, 22.0f, 28.0f, 34.0f, 40.0f };

    //hearing range of the enemy.
    void GetDistance()
    {
        distancePlayer = Vector3.Distance(this.gameObject.transform.position, Player.transform.position);
    }

    //Checks the player is within a certain distance, and is making enough noise to be heard.
    void Alert()
    {
        UpdateRange();
        if (distancePlayer <= hearingRange[0] && audioSource.volume >= 0.1f && !playerHeard)
        {
            playerHeard = true;
        }
        else if (distancePlayer <= hearingRange[1] && audioSource.volume >= 0.2f && !playerHeard)
        {
            playerHeard = true;
        }
        else if (distancePlayer <= hearingRange[2] && audioSource.volume >= 0.3f && !playerHeard)
        {
            playerHeard = true;
        }
        else if (distancePlayer <= hearingRange[3] && audioSource.volume >= 0.5f && !playerHeard)
        {
            playerHeard = true;
        }
        else if (distancePlayer <= hearingRange[4] && audioSource.volume >= 0.8f && !playerHeard)
        {
            playerHeard = true;
        }
        else if (audioSource.volume >= 1.0f && !playerHeard)
        {
            playerHeard = true;
        }
        else
        {
            playerHeard = false;
        }
    }

    //This function will increase the enemy's hearing range as the player collects more keys.
    private void UpdateRange()
    {
        GameObject thePlayer = GameObject.Find("Player");
        ObjectPickup objectScript = thePlayer.GetComponent<ObjectPickup>();
        if (objectScript.keyReset == 1)
        {
            for (int distance = 0; distance < 6; distance++)
            {
                hearingRange[distance] += 3.0f;
                objectScript.keyReset = 0;
            }
        }
    }

    //Enemy will be set to follow the player once playerHeard is true.
    void Update()
    {
        GetDistance();
        Alert();

        if (playerHeard)
        {
            GameObject theEnemy = GameObject.Find("Enemy");
            EnemyNavMesh navMesh = theEnemy.GetComponent<EnemyNavMesh>();
            navMesh.agent.SetDestination(navMesh.target.transform.position);
        }
    }
}
