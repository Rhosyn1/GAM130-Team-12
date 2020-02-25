using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverScript : MonoBehaviour
{
    //also not my best idea :) 
    void Update()
    {
        StartCoroutine(waitTime());
        Application.Quit();
    }


    IEnumerator waitTime()
    {
        yield return new WaitForSeconds(5f);
    }
    

}
