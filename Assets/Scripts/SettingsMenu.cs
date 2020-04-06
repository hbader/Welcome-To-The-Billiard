using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{

    public const float DefaultVolumeLevel = 0f;

    public AudioMixer audioMixer;
    Resolution[] resolutions;
    public Dropdown resolutionDropdown;
    public Slider volSLider;
    public Dropdown graphicsDropdown;

    private void Start()
    {
        resolutions = Screen.resolutions;

        resolutionDropdown.ClearOptions();
        List<string> options = new List<string>();

        int currentResolutionIndex = 0;
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            if (!options.Contains(option))
            {
                options.Add(option);
            }

            if (resolutions[i].width == Screen.currentResolution.width &&
                resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }

        // Sets up Menu at start with starting values
        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();

        volSLider.value = PlayerPrefs.GetFloat("masterVolume");
        graphicsDropdown.value = PlayerPrefs.GetInt("qualIndex");
        graphicsDropdown.RefreshShownValue();
    }


    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("masterVolume", volume);
        PlayerPrefs.SetFloat("masterVolume", volume);
    }

    public void SetQuality(int qualIndex)
    {
        QualitySettings.SetQualityLevel(qualIndex);
        PlayerPrefs.SetInt("qualIndex", qualIndex);
    }

    public void SetFullscreen(bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution res = resolutions[resolutionIndex];
        Screen.SetResolution(res.width, res.height, Screen.fullScreen);
    }

}
