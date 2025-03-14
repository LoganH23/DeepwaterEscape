using TMPro.Examples;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI;
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
        pauseMenuUI.SetActive(true);
        Cursor.lockState = CursorLockMode.None; // Unlock the cursor so that buttons can be clicked
        Cursor.visible = true; // Makes the cursor visible
        Time.timeScale = 0f; // Freeze the game
        isPaused = true;
    }

    public void ResumeGame()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f; // Unfreeze the game
        Cursor.lockState = CursorLockMode.Locked; //Lock the cursor
        Cursor.visible = false; // Makes the cursor invisible
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

