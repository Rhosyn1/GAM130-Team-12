using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyDealDamage : MonoBehaviour
{
    public int playerHealth;
    public GameObject playerObject;

    void Update()
    {
        //dealing damage to player health, if player dies then new scene is loaded.
        if (Vector3.Distance(transform.position, playerObject.transform.position) <= 2f)
        {
            playerHealth--;
            if (playerHealth <= 0)
            {
                SceneManager.LoadScene(2);
            }
        }
    }


}
