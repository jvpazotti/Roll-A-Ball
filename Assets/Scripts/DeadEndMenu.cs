using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeadEndMenu : MonoBehaviour
{
    public void RestartGame()
    {
        SceneManager.LoadScene("Minigame");  // Replace with your game scene name
    }

    public void QuitGame()
    {
         Application.Quit();  
    }
}

