using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverScript : MonoBehaviour
{
    // Update is called once per frame
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
