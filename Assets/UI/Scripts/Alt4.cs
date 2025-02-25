using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitGame2 : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftAlt) && Input.GetKeyDown(KeyCode.F4))
        {
            Application.Quit();
        }
    }
}

