using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
 * This script manages in-game events for the second level. Specifically,
 * it checks to see if dialogue with the anglerfish is complete, then 
 * transitions to the next scene
*/
public class Level2Manager : MonoBehaviour
{
    [SerializeField] private GameObject mainCamera;

    // Check to see if dialogue completed
    void Update()
    {
        if(GameObject.Find("DialogueManager").GetComponent<DialogueManager>().dialogueComplete)
        {
            GameObject.Find("DialogueManager").GetComponent<DialogueManager>().dialogueComplete = false;
            StartCoroutine(fadeToNextScene());
        }
    }

    //coroutine to move to next scene
    IEnumerator fadeToNextScene()
    {
        mainCamera.GetComponent<CameraFadeOut>().fadeOut = true;
        yield return new WaitForSeconds(6);
        SceneManager.LoadScene("3.Arena");
    }
}
