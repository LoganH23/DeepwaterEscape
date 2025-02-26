using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // Ensure this is included

public class ScreenModeSetting : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown ScreenModeDropDown; // Ensure this is assigned in the Inspector
    private Resolutions resolutions;

    void Start()
    {
        resolutions = FindObjectOfType<Resolutions>();
        if (resolutions == null)
        {
            Debug.LogError("Resolutions script not found in the scene!");
            return;
        }

        if (ScreenModeDropDown == null)
        {
            Debug.LogError("ScreenModeDropDown is not assigned!");
            return;
        }

        int val = PlayerPrefs.GetInt("ScreenMode", 0); // Default to FullScreenWindow
        ScreenModeDropDown.value = val;
        ScreenModeDropDown.RefreshShownValue();
    }

    public void SetScreenMode(int index)
    {
        if (resolutions == null)
        {
            Debug.LogError("Resolutions script not found! Cannot change screen mode.");
            return;
        }

        PlayerPrefs.SetInt("ScreenMode", index);
        PlayerPrefs.Save();

        FullScreenMode mode = (FullScreenMode)index;
        Screen.fullScreenMode = mode;
        Screen.SetResolution(resolutions.resolution.width, resolutions.resolution.height, mode != FullScreenMode.Windowed);

        Debug.Log($"Screen mode set to: {mode}, Resolution: {resolutions.resolution.width} x {resolutions.resolution.height}");
    }
}
