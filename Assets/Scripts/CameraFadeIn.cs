using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * This script provides a visual effect to have the camera fade in from black.
 * It uses an animation curve to gradually transfer from a black texture to
 * the game world.
*/
public class CameraFadeIn : MonoBehaviour
{
    //variables
    public bool fadein = true;

    public float speedScale = 1f;
    public Color fadeColor = Color.black;

    public AnimationCurve Curve = new AnimationCurve(new Keyframe(0, 1), new Keyframe(0.5f, 0.5f, -1.5f, -1.5f), new Keyframe(1, 0));
    public bool startFadedOut = false;

    private float alpha = 0f;
    private Texture2D texture;
    private int direction = 0;
    private float time = 0f;

    //begin fade in on start
    private void Start()
    {
        if (fadein == false)
        {
            fadein = true;
        }

        if (startFadedOut)
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

    //check to see if fully faded in
    private void Update()
    {
        if (direction == 0 && fadein)
        {
            fadein = false;

            //Fully faded in
            alpha = 1f;
            time = 0f;
            direction = 1;

        }
    }

    //draws texture to the screen
    public void OnGUI()
    {
        if (alpha > 0f)
        {
            GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), texture);
        }
        if (direction != 0)
        {
            time += direction * Time.deltaTime * speedScale;
            alpha = Curve.Evaluate(time);
            texture.SetPixel(0, 0, new Color(fadeColor.r, fadeColor.g, fadeColor.b, alpha));
            texture.Apply();
            if (alpha <= 0f || alpha >= 1f)
            {
                direction = 0;
            }
        }

    }
}
