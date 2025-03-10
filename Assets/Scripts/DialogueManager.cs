using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Ink.Runtime;

/*
 * This script represents a dialogue manager system. It manages active dialogue
 * queues, allowing them to continue and end
*/

public class DialogueManager : MonoBehaviour
{
    //variables
    [Header("Dialogue UI")]
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private TextMeshProUGUI dialogueText;


    private Story currentStory;
    public bool dialogueIsPlaying { get; private set; }

    public bool dialogueComplete = false;

    private static DialogueManager instance;

    //awake checks if a dialogue manager already exists in scene
    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Found more than one Dialogue manager in the scene!");
        }
        instance = this;
    }

    //returns if there is an active instance of the DialogueManager
    public static DialogueManager GetInstance()
    {
        return instance;
    }

    //sets dialogue active to false on start
    private void Start()
    {
        dialogueIsPlaying = false;
        dialoguePanel.SetActive(false);
    }

    //checks if dialogue is playing. If player presses appropriate
    //dialogue button, it continues the dialogue
    private void Update()
    {
        if (!dialogueIsPlaying)
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            ContinueStory();
        }
    }

    //enters the dialogue queue
    public void EnterDialogueMode(TextAsset inkJSON)
    {
        currentStory = new Story(inkJSON.text);
        dialogueIsPlaying = true;
        dialogueComplete = false;
        dialoguePanel.SetActive(true);

        ContinueStory();
    }

    //exits the dialogue queue
    private void ExitDialogueMode()
    {
        Debug.Log("Running");

        dialoguePanel.SetActive(false);
        dialogueIsPlaying = false;
        dialogueText.text = "";
        dialogueComplete = true;
    }

    //continues dialogue
    private void ContinueStory()
    {
        if (currentStory.canContinue)
        {
            dialogueText.text = currentStory.Continue();
        }
        else
        {
            ExitDialogueMode();
        }
    }
}
