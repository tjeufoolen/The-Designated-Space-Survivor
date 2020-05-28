using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject Menu = null;
    public bool GameIsPaused = false;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            if (GameIsPaused) Resume();
            else Pause();
        }
    }

    public void Resume()
    {
        Menu.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    public void Pause()
    {
        Menu.SetActive(true);
        Time.timeScale = 0;
        GameIsPaused = true;
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
        Resume();
    }
}
