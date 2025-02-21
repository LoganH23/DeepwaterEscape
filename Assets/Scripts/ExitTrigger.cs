    using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
 * This script handles the player reaching the end of the first level.
 * On hitting the isTrigger collider at the end of the level, the camera
 * should begin to fade out as an explosion effect goes off in the background,
 * followed by movement to the next scene.
*/
public class ExitTrigger : MonoBehaviour
{
    //variables
    [SerializeField] private GameObject mainCamera;
    public AudioSource explode;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            StartCoroutine(fadeToNextScene());
        }
    }

    //coroutine to move to the next scene
    IEnumerator fadeToNextScene()
    {
        mainCamera.GetComponent<CameraFadeOut>().fadeOut = true;
        yield return new WaitForSeconds(3);
        explode.Play();
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("2.Oceanfloor");
    }
}
