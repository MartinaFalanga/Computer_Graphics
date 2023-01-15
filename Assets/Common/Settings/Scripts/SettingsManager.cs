using System.Collections;
using System.Collections.Generic;
using SOHNE.Accessibility.Colorblindness;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class SettingsManager : MonoBehaviour
{
    public static SettingsManager instance;
    private AudioManager audioManager;
    private Colorblindness accessibilityManager;
    private UniversalAdditionalCameraData cameraData;
    private Volume[] renderingVolumes;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            UpdateSettings();
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
    }

    public void UpdateSettings()
    {
        SetInstanceValue();
        cameraData = FindObjectOfType<UniversalAdditionalCameraData>();
        cameraData.antialiasing = AntialiasingMode.None;
        renderingVolumes = FindObjectsOfType<Volume>();
        SetAntiAliasing(PlayerPrefs.GetInt("antialiasingIndex"));
        QualitySettings.antiAliasing = PlayerPrefs.GetInt("antialiasingQuality");
        SetVolume(PlayerPrefs.GetFloat("volume"));
        SetGraphicQuality(PlayerPrefs.GetInt("graphicQuality"));
        SetResolution(Screen.resolutions[PlayerPrefs.GetInt("resolution")], PlayerPrefs.GetInt("resolution"));
        SetFullScreen(PlayerPrefs.GetInt("fullscreen") == 1);
        SetVSync(PlayerPrefs.GetInt("vsync"));
        SetMotionBlur(PlayerPrefs.GetInt("motionBlur") == 1);
        SetBloom(PlayerPrefs.GetInt("bloom") == 1);
        SetColorBlindnessMode(PlayerPrefs.GetInt("colorblindness"));
    }

    private void SetInstanceValue()
    {
        audioManager = AudioManager.instance;
        audioManager.UpdateValues();
        accessibilityManager = Colorblindness.Instance;
        cameraData = FindObjectOfType<UniversalAdditionalCameraData>();
        cameraData.antialiasing = AntialiasingMode.None;
        renderingVolumes = FindObjectsOfType<Volume>();
    }

    public void SetVolume(float volume)
    {
        audioManager.SetVolume(volume);
        PlayerPrefs.SetFloat("volume", volume);
    }

    public void SetGraphicQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
        PlayerPrefs.SetInt("graphicQuality", qualityIndex);
    }

    public void SetResolution(Resolution resolution, int resolutionIndex)
    {
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
        PlayerPrefs.SetInt("resolution", resolutionIndex);
    }

    public void SetFullScreen(bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
        PlayerPrefs.SetInt("fullscreen", isFullScreen ? 1 : 0);
    }

    public void SetMotionBlur(bool isMotionBlurActive)
    {
        MotionBlur tmpBlur, motionBlur;
        foreach (Volume rv in renderingVolumes) {
            if (rv.profile.TryGet<MotionBlur>(out tmpBlur))
            {
                motionBlur = tmpBlur;
                motionBlur.active = isMotionBlurActive;
            }
        }
        PlayerPrefs.SetInt("motionBlur", isMotionBlurActive ? 1 : 0);
    }

    public void SetBloom(bool isBloomActive)
    {
        Bloom tmpBloom, bloom;
        foreach (Volume rv in renderingVolumes)
        {
            if (rv.profile.TryGet<Bloom>(out tmpBloom))
            {
                bloom = tmpBloom;
                bloom.active = isBloomActive;
            }
        }
        PlayerPrefs.SetInt("bloom", isBloomActive ? 1 : 0);
    }

    public void SetAntiAliasing(int antiAliasingIndex)
    {
        switch (antiAliasingIndex)
        {
            case 1:
                QualitySettings.antiAliasing = 4;
                cameraData.antialiasing = AntialiasingMode.FastApproximateAntialiasing;
                break;
            case 2:
                QualitySettings.antiAliasing = 8;
                cameraData.antialiasing = AntialiasingMode.SubpixelMorphologicalAntiAliasing;
                cameraData.antialiasingQuality = AntialiasingQuality.High;
                break;
            default:
                QualitySettings.antiAliasing = 0;
                cameraData.antialiasing = AntialiasingMode.None;
                break;
        }
        PlayerPrefs.SetInt("antialiasingIndex", antiAliasingIndex);
        PlayerPrefs.SetInt("antialiasingQuality", QualitySettings.antiAliasing);
    }

    public void SetVSync(int vSyncIndex)
    {
        QualitySettings.vSyncCount = vSyncIndex;
        PlayerPrefs.SetInt("vsync", vSyncIndex);
    }

    public void SetColorBlindnessMode(int colorBlindnessIndex)
    {
        accessibilityManager.SetCurrentType(colorBlindnessIndex);
        accessibilityManager.InitChange();
        PlayerPrefs.SetInt("colorblindness", colorBlindnessIndex);
    }
}
