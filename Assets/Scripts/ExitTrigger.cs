    using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitTrigger : MonoBehaviour
{
    [SerializeField] private GameObject mainCamera;
    public AudioSource explode;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            StartCoroutine(fadeToNextScene());
        }
    }

    IEnumerator fadeToNextScene()
    {
        mainCamera.GetComponent<CameraFadeOut>().fadeOut = true;
        yield return new WaitForSeconds(3);
        explode.Play();
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("2.Oceanfloor");
    }
}
