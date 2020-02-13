using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHearing : MonoBehaviour
{
    public GameObject Player;
    
    private float distancePlayer;
    private bool playerHeard;

    //hearing range of the enemy.
    void GetDistance()
    {
        distancePlayer = Vector3.Distance(this.gameObject.transform.position, Player.transform.position);
    }

    //Checks the player is within a certain distance, and is making enough noise.
    void Alert()
    {
        if (distancePlayer <= 10.0f && !playerHeard)
        {
            playerHeard = true;
        }

        if (distancePlayer > 10.0f && playerHeard)
        {
            playerHeard = false;
        }
    }

    //Enemy will be set to follow the player once playerHeard is true.
    void Update()
    {
        GetDistance();
        Alert();

        if (playerHeard)
        {
            //this.gameObject.GetComponent<EnemyNavMesh>().Update();
            throw new System.NotImplementedException();
        }
    }
}
