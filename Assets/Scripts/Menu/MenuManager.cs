using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void ExitGame(){    
        Application.Quit();
    }

    public void GoToMenu(){
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }
    public void PlayStage1(){
        SceneManager.LoadScene(1);
    }
}
    
