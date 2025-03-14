using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackButton : MonoBehaviour
{
    // Function to be called on button click
    public void LoadMain()
    {
        SceneManager.LoadScene("main");
    }
}
