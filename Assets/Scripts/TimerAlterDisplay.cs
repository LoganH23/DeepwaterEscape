using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class TimerAlterDisplay : MonoBehaviour
{
    [Tooltip("Time limit in seconds.")]
    public float timeLimit = 10f;
    private float curTimeRemaining; // Internal counter for time remaining
    [Tooltip("When is the timer going to end?")]
    public float endTime = 0f;
    public bool timerRunning = false; // Is the timer actually ticking? Must be triggered from an object.
    // private bool isVisible = true; // Unused as of now.
    public TextMeshProUGUI timerText; // The textmeshpro object that will hold the timer text

    // Start is called before the first frame update
    void Start()
    {
        timerRunning = false; // Timer has to be triggered manually in-game
        curTimeRemaining = timeLimit; // Update internal counter to match max time limit
    }
    // Update is called once per frame
    void Update()
    {
        if (timerRunning)
        {
            if (curTimeRemaining > endTime)
            {
                curTimeRemaining -= Time.deltaTime;
                DisplayTime(curTimeRemaining);
            }
            else
            {
                timerRunning = false; // timer doesn't run when it's out
                curTimeRemaining = 0;
                timerText.text = string.Format("00:00");
                SceneManager.LoadScene("Scene_SubTimeout"); // Send them to gameover screen
            }
        }
    }
    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;
        float minutes = Mathf.FloorToInt(timeToDisplay / 60); //2
        float seconds = Mathf.FloorToInt(timeToDisplay % 60); //10
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds); // Format timer text to be good.
    }
}
