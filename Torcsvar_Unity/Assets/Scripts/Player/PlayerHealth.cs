using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float health = 10f;
    public float resetAfterDeathTime = 5f;
    public AudioClip deathClip;

    private Animator anim;
    private PlayerCharacterController playerMovement;
    private HashIDs hash;
    private LastPlayerSighting lastPlayerSighting;
    private bool playerDead;

    void Awake()
    {
        anim = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerCharacterController>();
        hash = GameObject.FindGameObjectWithTag(Tags.gameManager).GetComponent<HashIDs>();
        lastPlayerSighting = GameObject.FindGameObjectWithTag(Tags.gameManager).GetComponent<LastPlayerSighting>();
    }

    void Update()
    {
        if(health <= 0f) 
        {
            if (!playerDead) 
            {
                IsPlayerDying();
            }
            else 
            {
                PlayerIsDead();
            }
        }
    }

    void IsPlayerDying() 
    {
        playerDead = true;
        anim.SetBool(hash.deadBool, true);
        AudioSource.PlayClipAtPoint(deathClip, transform.position);
    }

    void PlayerIsDead() 
    {
        if (anim.GetCurrentAnimatorStateInfo(0).fullPathHash == hash.dyingState) 
        {
            anim.SetBool(hash.deadBool, false);
        }

        anim.SetFloat(hash.speedFloat, 0f);
        playerMovement.enabled = false;
        lastPlayerSighting.position = lastPlayerSighting.resetPosition;
    }

    public void DamageTaken() 
    {
        { }
    }
}
