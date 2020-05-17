using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void GoToGame()
    {
       SceneManager.LoadScene("Game");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
