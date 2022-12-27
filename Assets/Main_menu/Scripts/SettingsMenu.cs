using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    public SettingsManager settingsManager;
    public Scrollbar volumeScrollbar;
    public TMPro.TMP_Dropdown graphicsDropdown;
    public TMPro.TMP_Dropdown resolutionsDropdown;
    public TMPro.TMP_Dropdown vsyncDropdown;
    public TMPro.TMP_Dropdown antiAliasingDropdown;
    public TMPro.TMP_Dropdown colorBlindnessDropdown;
    public Toggle fullscreenToggle;
    public Toggle motionBlurToggle;
    public Toggle bloomToggle;
    private Resolution[] resolutions;

        public void Start()
    {
        resolutions = Screen.resolutions;
        resolutionsDropdown.ClearOptions();
        List<string> options = new List<string>();
        int currentResolutionIndex = 0;
        for(int i = 0; i < resolutions.Length; i++)
        {
            var res = resolutions[i];
            options.Add(res.width + " x " + res.height);
            if(res.width == Screen.currentResolution.width &&
                res.height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }
        resolutionsDropdown.AddOptions(options);

        LoadSavings();
    }

    public void LoadSavings()
    {
        SetColorBlindnessMode(PlayerPrefs.GetInt("colorblindness"));
        SetAntiAliasing(PlayerPrefs.GetInt("antialiasingIndex"));
        QualitySettings.antiAliasing = PlayerPrefs.GetInt("antialiasingQuality");
        SetVolume(PlayerPrefs.GetFloat("volume"));
        SetGraphicQuality(PlayerPrefs.GetInt("graphicQuality"));
        SetResolution(PlayerPrefs.GetInt("resolution"));
        SetFullScreen(PlayerPrefs.GetInt("fullscreen") == 1);
        SetVSync(PlayerPrefs.GetInt("vsync"));
        SetMotionBlur(PlayerPrefs.GetInt("motionBlur") == 1);
        SetBloom(PlayerPrefs.GetInt("bloom") == 1);
    }

    public void SetVolume(float volume)
    {
        settingsManager.SetVolume(volume);
        volumeScrollbar.value = volume;
    }

    public void SetGraphicQuality(int qualityIndex)
    {
        settingsManager.SetGraphicQuality(qualityIndex);
        graphicsDropdown.value = qualityIndex;
        graphicsDropdown.RefreshShownValue();
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        settingsManager.SetResolution(resolution, resolutionIndex);
        resolutionsDropdown.value = resolutionIndex;
        resolutionsDropdown.RefreshShownValue();
    }

    public void SetFullScreen(bool isFullScreen)
    {
        settingsManager.SetFullScreen(isFullScreen);
        fullscreenToggle.isOn = isFullScreen;
    }

    public void SetMotionBlur(bool isMotionBlurActive)
    {
        settingsManager.SetMotionBlur(isMotionBlurActive);
        motionBlurToggle.isOn = isMotionBlurActive;
    }

    public void SetBloom(bool isBloomActive)
    {
        settingsManager.SetBloom(isBloomActive);
        bloomToggle.isOn = isBloomActive;
    }

    public void SetAntiAliasing(int antiAliasingIndex)
    {
        settingsManager.SetAntiAliasing(antiAliasingIndex);
        antiAliasingDropdown.value = antiAliasingIndex;
        antiAliasingDropdown.RefreshShownValue();
    }

    public void SetVSync(int vSyncIndex)
    {
        settingsManager.SetVSync(vSyncIndex);
        vsyncDropdown.value = vSyncIndex;
        vsyncDropdown.RefreshShownValue();
    }

    public void SetColorBlindnessMode(int colorBlindnessIndex) {
        settingsManager.SetColorBlindnessMode(colorBlindnessIndex);
        colorBlindnessDropdown.value = colorBlindnessIndex;
        colorBlindnessDropdown.RefreshShownValue();
    }
}
