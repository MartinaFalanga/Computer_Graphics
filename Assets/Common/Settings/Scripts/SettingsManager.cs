using System.Collections;
using System.Collections.Generic;
using SOHNE.Accessibility.Colorblindness;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class SettingsManager : MonoBehaviour
{

    public AudioManager audioManager;
    public Colorblindness accessibilityManager;
    public static SettingsManager instance;
    private UnityEngine.Rendering.Universal.UniversalAdditionalCameraData cameraData;
    private Volume renderingVolume;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);

        cameraData = FindObjectOfType<UniversalAdditionalCameraData>();
        cameraData.antialiasing = UnityEngine.Rendering.Universal.AntialiasingMode.None;
        renderingVolume = FindObjectOfType<Volume>();
    }

    public void updateSettings()
    {
        cameraData = FindObjectOfType<UniversalAdditionalCameraData>();
        cameraData.antialiasing = UnityEngine.Rendering.Universal.AntialiasingMode.None;
        renderingVolume = FindObjectOfType<Volume>();
        SetColorBlindnessMode(PlayerPrefs.GetInt("colorblindness"));
        SetAntiAliasing(PlayerPrefs.GetInt("antialiasingIndex"));
        QualitySettings.antiAliasing = PlayerPrefs.GetInt("antialiasingQuality");
        SetVolume(PlayerPrefs.GetFloat("volume"));
        SetGraphicQuality(PlayerPrefs.GetInt("graphicQuality"));
        SetResolution(Screen.resolutions[PlayerPrefs.GetInt("resolution")], PlayerPrefs.GetInt("resolution"));
        SetFullScreen(PlayerPrefs.GetInt("fullscreen") == 1);
        SetVSync(PlayerPrefs.GetInt("vsync"));
        SetMotionBlur(PlayerPrefs.GetInt("motionBlur") == 1);
        SetBloom(PlayerPrefs.GetInt("bloom") == 1);
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
        if (renderingVolume.profile.TryGet<MotionBlur>(out tmpBlur))
        {
            motionBlur = tmpBlur;
            motionBlur.active = isMotionBlurActive;
        }
        PlayerPrefs.SetInt("motionBlur", isMotionBlurActive ? 1 : 0);
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
