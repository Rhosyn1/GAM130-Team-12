using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPickup : MonoBehaviour
{
    //When player is near object, player presses a button to pick up.

    public GameObject Key;

    private bool boolKey = false;

    void start()
    {
        pressButton();
    }

    //picking up the item after pressing Q.
    public void pressButton()
    {
        Debug.Log("Enters function");
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (Key.CompareTag("Key"))
            {
                Debug.Log("Picked up key");
                boolKey = true;
            }
        }
       // else
        ///{
          //  Debug.Log("Object not picked up");
       // }
    }
}
