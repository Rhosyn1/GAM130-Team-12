using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectPickup : MonoBehaviour
{
    //When player is near object, player presses a button to pick up.

    public GameObject playerCamera;

    private bool boolKey = false;

    public Text pickUpText;

    //picking up the item after pressing E.
    public void Update()
    {
        //using Raycast to find the key object in front of the camera up to 10m away.
        if (Physics.Raycast(playerCamera.transform.position, Vector3.forward, out RaycastHit hit, 10.0f))
        {
            //if the tag on the object is equal to Key then text appears.
            if (hit.transform.CompareTag("Key"))
            {
                pickUpText.gameObject.SetActive(true);
                //if E is pressed then object is destroyed and the bool is turned to true.
                if (Input.GetKeyDown(KeyCode.E))
                {
                    boolKey = true;
                    Destroy(hit.transform.gameObject);
                }
            }
        }
        else
        {
            //disabling the text if the key is gone.
            pickUpText.gameObject.SetActive(false);
        }
    }
}
