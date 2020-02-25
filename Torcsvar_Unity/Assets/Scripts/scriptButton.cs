using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

//a very small script
public class scriptButton : MonoBehaviour
{
    public void playButton()
    {
        SceneManager.LoadScene(1);
    }
    
    public void quitButton()
    {
        Application.Quit();
    }
}
