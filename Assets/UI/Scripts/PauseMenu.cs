using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu2 : MonoBehaviour
{
    public GameObject PauseManager;
    private bool isPaused = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
                ResumeGame();
            else
                PauseGame();
        }
    }

    public void PauseGame()
    {
        PauseManager.SetActive(true);
        Time.timeScale = 0f; // Freeze the game
        isPaused = true;
    }

    public void ResumeGame()
    {
        PauseManager.SetActive(false);
        Time.timeScale = 1f; // Unfreeze the game
        isPaused = false;
    }

    public void QuitGame()
    {
        Time.timeScale = 1f; // Ensure time resumes
        Application.Quit();
    }

    public void GoToHome()
    {
        Time.timeScale = 1f; // Ensure time resumes
        SceneManager.LoadScene("Main"); // Change this to your main menu scene name
    }
}

