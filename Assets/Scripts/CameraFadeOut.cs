using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
 * This script creates a visual effect that fades the camera to black. This can
 * usually be used at the end of a scene to transition between scene changes.
 * This script works by creating a texture that is gradually faded in onto the
 * camera.
*/
public class CameraFadeOut : MonoBehaviour
{
    //variables
    public bool fadeOut = false;

    public float speedScale = 1f;
    public Color fadeColor = Color.black;

    public AnimationCurve Curve = new AnimationCurve(new Keyframe(0, 1), new Keyframe(0.5f, 0.5f, -1.5f, -1.5f), new Keyframe(1, 0));
    public bool startFadedOut = false;

    private float alpha = 0f;
    private Texture2D texture;
    private int direction = 0;
    private float time = 0f;

    //check if fade out is begun, initialize variables
    private void Start()
    {
        if(startFadedOut)
        {
            alpha = 1f;
        }
        else
        {
            alpha = 0f;
        }

        texture = new Texture2D(1, 1);
        texture.SetPixel(0, 0, new Color(fadeColor.r, fadeColor.g, fadeColor.b, alpha));
        texture.Apply();
    }

    //check if fully faded in
    private void Update()
    {
        if(direction == 0 && fadeOut)
        {
            fadeOut = false;

            //Fully faded in
            alpha = 0f;
            time = 1f;
            direction = -1;

        }
    }

    //update texture fade
    public void OnGUI()
    {
        if(alpha > 0f)
        {
            GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), texture);
        }
        if(direction != 0)
        {
            time += direction * Time.deltaTime * speedScale;
            alpha = Curve.Evaluate(time);
            texture.SetPixel(0, 0, new Color(fadeColor.r, fadeColor.g, fadeColor.b, alpha));
            texture.Apply();
            if(alpha <= 0f || alpha >= 1f)
            {
                direction = 0;
            }
        }

    }

}
