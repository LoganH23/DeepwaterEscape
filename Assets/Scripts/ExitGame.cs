using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * This quick script closes the game if a confirmation code is sent.
 * It is primarily called by other scripts/functions
*/
public class ExitGame : MonoBehaviour
{
    // Start is called before the first frame update
    //void Start()
    //{
        
    //}

    // Update is called once per frame
    //void Update()
    //{
        
    //}

    public void QuitGame(int confirm)
    {
        if (confirm == 1)
        {
            Application.Quit();
        }
    }
}
