using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections.Generic;

public class ResolutionSettings : MonoBehaviour
{
    public TMP_Dropdown resolutionDropdown;
    public Toggle fullscreenToggle;
    public Button applyButton;
    private Resolution[] resolutions;
    private int selectedResolutionIndex;

    void Start()
    {
        resolutions = Screen.resolutions;
        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();
        int currentResolutionIndex = 0;

        for (int i = 0; i < resolutions.Length; i++)
        {
            string resolutionOption = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(resolutionOption);

            // if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            // {
            //     currentResolutionIndex = i;
            // }
        }

        resolutionDropdown.AddOptions(options);

        if (PlayerPrefs.HasKey("ResolutionIndex"))
        {
            currentResolutionIndex = PlayerPrefs.GetInt("ResolutionIndex");
        }
        if (PlayerPrefs.HasKey("Fullscreen"))
        {
            Screen.fullScreen = PlayerPrefs.GetInt("Fullscreen") == 1;
            fullscreenToggle.isOn = Screen.fullScreen;
        }

        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();

        selectedResolutionIndex = currentResolutionIndex;

        resolutionDropdown.onValueChanged.AddListener(SetSelectedResolution);
        fullscreenToggle.onValueChanged.AddListener(SetFullscreen);
        applyButton.onClick.AddListener(ApplyResolution);
    }

    public void SetSelectedResolution(int resolutionIndex)
    {
        selectedResolutionIndex = resolutionIndex;
    }

public void ApplyResolution()
{
    Resolution resolution = resolutions[selectedResolutionIndex];
    if (Screen.width != resolution.width || Screen.height != resolution.height)
    {
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
        PlayerPrefs.SetInt("ResolutionIndex", selectedResolutionIndex);
        Debug.Log("Resolution applied: " + resolution.width + " x " + resolution.height);
    }
    else
    {
        Debug.Log("Selected resolution is already applied.");
    }
}

    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
        PlayerPrefs.SetInt("Fullscreen", isFullscreen ? 1 : 0);
    }
}
