using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowScript : MonoBehaviour
{
    public GameObject windowLight;
    public bool isSmashed = false;

    public void Smash()
    {
        if (isSmashed == false)
        {
            isSmashed = true;
            windowLight.gameObject.SetActive(true);
        }
    }
}
