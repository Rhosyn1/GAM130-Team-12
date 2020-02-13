using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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
