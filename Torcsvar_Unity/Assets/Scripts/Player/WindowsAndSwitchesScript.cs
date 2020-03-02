using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WindowsAndSwitchesScript : MonoBehaviour
{
    public GameObject playerCamera;
    public Text uiText;
    public Text switchText;

    // Update is called once per frame
    void Update()
    {
        //Use a raycast to see if the player is looking at a window or not
        if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out RaycastHit hit, 2.5f))
        {
            if (hit.collider.gameObject.name == "Window" && hit.collider.gameObject.GetComponent<WindowScript>().isSmashed == false)
            {
                uiText.gameObject.SetActive(true);
                if (Input.GetKeyDown(KeyCode.E))
                {
                    hit.collider.gameObject.GetComponent<WindowScript>().Smash();
                }
            }
            else
            {
                uiText.gameObject.SetActive(false);
            }

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
            uiText.gameObject.SetActive(false);
            switchText.gameObject.SetActive(false);
        }


    }
}
