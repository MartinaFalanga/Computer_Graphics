using System.Collections.Generic;

using SOHNE.Accessibility.Colorblindness;

using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{

    public AudioManager audioManager;
    public Colorblindness accessibilityManager;
    public Scrollbar volumeScrollbar;
    public TMPro.TMP_Dropdown graphicsDropdown;
    public TMPro.TMP_Dropdown resolutionsDropdown;
    public TMPro.TMP_Dropdown vsyncDropdown;
    public TMPro.TMP_Dropdown antiAliasingDropdown;
    public TMPro.TMP_Dropdown colorBlindnessDropdown;
    public Toggle fullscreenToggle;
    public Toggle motionBlurToggle;
    public Toggle bloomToggle;
    public UnityEngine.Rendering.Universal.UniversalAdditionalCameraData cameraData;
    private Resolution[] resolutions;
    private Volume renderingVolume;

    public void Start()
    {
        renderingVolume = FindObjectOfType<Volume>();
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
        cameraData.antialiasing = UnityEngine.Rendering.Universal.AntialiasingMode.None;

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
        SetMotionBlur(PlayerPrefs.GetInt("bloom") == 1);
    }

    public void SetVolume(float volume)
    {
        audioManager.SetVolume(volume);
        PlayerPrefs.SetFloat("volume", volume);
        volumeScrollbar.value = volume;
    }

    public void SetGraphicQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
        PlayerPrefs.SetInt("graphicQuality", qualityIndex);
        graphicsDropdown.value = qualityIndex;
        graphicsDropdown.RefreshShownValue();
    }

    public void SetResolution(int resolutionIndex)
    {
        Debug.Log("Risoluzione: " + resolutionIndex);
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
        PlayerPrefs.SetInt("resolution", resolutionIndex);
        resolutionsDropdown.value = resolutionIndex;
        resolutionsDropdown.RefreshShownValue();
    }

    public void SetFullScreen(bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
        PlayerPrefs.SetInt("fullscreen", isFullScreen ? 1 : 0);
        fullscreenToggle.isOn = isFullScreen;
    }

    public void SetMotionBlur(bool isMotionBlurActive)
    {
        MotionBlur tmpBlur, motionBlur;
        if (renderingVolume.profile.TryGet<MotionBlur>(out tmpBlur))
        {
            motionBlur = tmpBlur;
            motionBlur.active = isMotionBlurActive;
        }
        PlayerPrefs.SetInt("motionBlur", isMotionBlurActive ? 1 : 0);
        motionBlurToggle.isOn = isMotionBlurActive;
    }

    public void SetBloom(bool isBloomActive)
    {
        Bloom tmpBloom, bloom;
        if (renderingVolume.profile.TryGet<Bloom>(out tmpBloom))
        {
            bloom = tmpBloom;
            bloom.active = isBloomActive;
        }
        PlayerPrefs.SetInt("bloom", isBloomActive ? 1 : 0);
        bloomToggle.isOn = isBloomActive;
    }

    public void SetAntiAliasing(int antiAliasingIndex)
    {
        switch (antiAliasingIndex)
        {
            case 1: 
                QualitySettings.antiAliasing = 4;
                cameraData.antialiasing = UnityEngine.Rendering.Universal.AntialiasingMode.FastApproximateAntialiasing;
                break;
            case 2: 
                QualitySettings.antiAliasing = 8;
                cameraData.antialiasing = UnityEngine.Rendering.Universal.AntialiasingMode.SubpixelMorphologicalAntiAliasing;
                cameraData.antialiasingQuality = UnityEngine.Rendering.Universal.AntialiasingQuality.High;
                break;
            default: 
                QualitySettings.antiAliasing = 0;
                cameraData.antialiasing = UnityEngine.Rendering.Universal.AntialiasingMode.None;
                break;
        }
        PlayerPrefs.SetInt("antialiasingIndex", antiAliasingIndex);
        PlayerPrefs.SetInt("antialiasingQuality", QualitySettings.antiAliasing);
        antiAliasingDropdown.value = antiAliasingIndex;
        antiAliasingDropdown.RefreshShownValue();
    }

    public void SetVSync(int vSyncIndex)
    {
        QualitySettings.vSyncCount = vSyncIndex;
        PlayerPrefs.SetInt("vsync", vSyncIndex);
        vsyncDropdown.value = vSyncIndex;
        vsyncDropdown.RefreshShownValue();
    }

    public void SetColorBlindnessMode(int colorBlindnessIndex) {
        accessibilityManager.SetCurrentType(colorBlindnessIndex);
        accessibilityManager.InitChange();
        PlayerPrefs.SetInt("colorblindness", colorBlindnessIndex);
        colorBlindnessDropdown.value = colorBlindnessIndex;
        colorBlindnessDropdown.RefreshShownValue();
    }
}
