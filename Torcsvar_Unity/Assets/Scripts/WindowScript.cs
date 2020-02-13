using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowScript : MonoBehaviour
{
    public GameObject windowLight;
    public bool isSmashed = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Smash()
    {
        if (isSmashed == false)
        {
            isSmashed = true;
            windowLight.gameObject.SetActive(true);
        }
    }
}
