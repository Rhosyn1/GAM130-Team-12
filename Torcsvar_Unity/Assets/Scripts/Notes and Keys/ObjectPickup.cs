﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ObjectPickup : MonoBehaviour
{
    //When player is near object, player presses a button to pick up.

    public GameObject playerCamera;

    public int countKeys;

    public Text pickUpText;
    public Text pickUpNote;

    private Image image;

    public GameObject roomDoor;


    //picking up the item (key) after pressing E.
    public void Update()
    {
        //using Raycast to find the key object in front of the camera up to 2.5m away.
        if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out RaycastHit hit, 2.5f))
        {
            //if the tag on the object is equal to Key then text appears.
            if (hit.transform.CompareTag("Key"))
            {
                pickUpText.gameObject.SetActive(true);
                //if E is pressed then object is destroyed and the bool is turned to true.
                if (Input.GetKeyDown(KeyCode.E))
                {
                    countKeys++;
                    Destroy(hit.transform.gameObject);
                }
            }
            else
            {
                pickUpText.gameObject.SetActive(false);
            }
            //looking for the tag note.
            if (hit.transform.CompareTag("Note"))
            {
                image = hit.transform.gameObject.GetComponentInChildren<Image>(true);
                Debug.Log(image);
                //displaying text so that the player knows which key to press.
                if (!image.gameObject.activeSelf)
                {
                    pickUpNote.gameObject.SetActive(true);
                }
                if (Input.GetKeyDown(KeyCode.E))
                {
                    //enabling canvas so that the note displays.
                    //press E to enable/disable the note image.
                    if (!image.gameObject.activeSelf)
                    {
                        image.gameObject.SetActive(true);
                        pickUpNote.gameObject.SetActive(false);
                    }
                    else if (image.gameObject.activeSelf)
                    {
                        image.gameObject.SetActive(false);
                    }
                    
                }
            }
            //sets image and note text to inactive
            else
            {
                pickUpNote.gameObject.SetActive(false);
                if (image != null)
                {
                    image.gameObject.SetActive(false);
                }
                
            }                   
            
            //if all 5 keys have been collected then door opens.
            if (hit.transform.CompareTag("Door"))
            {
                if (countKeys == 5)
                {
                    Destroy(roomDoor);
                    Destroy(hit.transform.gameObject);
                }
            }

            if (hit.transform.CompareTag("Heart"))
            {
                pickUpText.gameObject.SetActive(true);
                if (Input.GetKeyDown(KeyCode.E))
                {
                    SceneManager.LoadScene(2);
                }
            }
        }
        else
        {
            pickUpNote.gameObject.SetActive(false);
            pickUpText.gameObject.SetActive(false);
        }
    }
}
