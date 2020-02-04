using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyDealDamage : MonoBehaviour
{
    public int playerHealth;
    public GameObject playerObject;
    // Start is called before the first frame update
    void Start()
    {
  
    }

    // Update is called once per frame
    void Update()
    {
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
