using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
 * This script handles object collection. It is attached to an object
 * that the player should be able to collect. A UI element will display
 * upon collection. When the given 'pick-up' button is clicked, the object
 * is destroyed and the UI element is set inactive
*/
public class ObjectPickup : MonoBehaviour
{
    //variables
    [SerializeField] private GameObject pickupPrompt;
    private bool promptOn;
    public AudioSource pickUp;
    public GameObject alarm;

    [SerializeField] private TextAsset inkJson;

    //initially set prompt to false
    private void Start()
    {
        pickupPrompt.SetActive(false);
        promptOn = false;
        //alarm.SetActive(false);
    }

    private void Update()
    {
        if(promptOn == true && Input.GetKeyDown(KeyCode.E))
        {
            alarm.SetActive(true);

            //check if level 1
            if (SceneManager.GetActiveScene().name == "1.Submarine")
            {
                //set items in level manager

                GameObject levelManager = GameObject.Find("LevelManager");

                if (this.gameObject.tag == "Button")
                {
                    alarm.SetActive(true);

                    //levelManager.GetComponent<TimerAlterDisplay>().timerRunning = true;
                    StartCoroutine(countdownDialogue());
                    //levelManager.GetComponent<LevelOneManager>().turnOnObjects();
                }
                else
                {
                    pickUp.Play();
                    if (!levelManager.GetComponent<LevelOneManager>().getItem1())
                    {
                        levelManager.GetComponent<LevelOneManager>().setItem1();
                    }
                    else if (!levelManager.GetComponent<LevelOneManager>().getItem2())
                    {
                        levelManager.GetComponent<LevelOneManager>().setItem2();
                    }
                    else if (!levelManager.GetComponent<LevelOneManager>().getItem3())
                    {
                        levelManager.GetComponent<LevelOneManager>().setItem3();
                    }

                    Destroy(this.gameObject, 1);
                }
                
            }

            
            promptOn = false;
            pickupPrompt.SetActive(false);
            GetComponent<Renderer>().enabled = false;
        }
    }

    //activates prompt on entry
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            pickupPrompt.SetActive(true);
            promptOn = true;
        }
    }
    //closes prompt on exit
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            pickupPrompt.SetActive(false);
            promptOn = false;
        }

    }

    IEnumerator countdownDialogue()
    {
        GameObject levelManager = GameObject.Find("LevelManager");

        yield return new WaitForSeconds(1);
        DialogueManager.GetInstance().EnterDialogueMode(inkJson);

        while(!DialogueManager.GetInstance().dialogueComplete)
        {
            continue;
        }
        levelManager.GetComponent<TimerAlterDisplay>().timerRunning = true;
        levelManager.GetComponent<LevelOneManager>().turnOnObjects();
        Destroy(this.gameObject, 1);
    }
}
