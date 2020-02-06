using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WindowBreaking : MonoBehaviour
{
    public GameObject playerCamera;
    public Text uiText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Use a raycast to see if the player is looking at a window or not
        if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out RaycastHit hit, 2.5f))
        {
            if (hit.collider.gameObject.name == "Window")
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
        }
        else
        {
            uiText.gameObject.SetActive(false);
        }


    }
}
