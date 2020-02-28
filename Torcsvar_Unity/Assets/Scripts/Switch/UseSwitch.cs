using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UseSwitch : MonoBehaviour
{
    public Text switchText;
    public Camera playerCamera;

    // Update is called once per frame
    void Update()
    {
        //Use a raycast to see if the player is looking at a switch or not
        if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out RaycastHit hit, 2.5f))
        {
            if (hit.collider.gameObject.name == "Switch")
            {
                switchText.gameObject.SetActive(true);
            }
            else
            {
                switchText.gameObject.SetActive(false);
            }
        }
        else
        {
            switchText.gameObject.SetActive(false);
        }
    }
}
