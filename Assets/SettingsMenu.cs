using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{

    public AudioManager audioManager;

    public TMPro.TMP_Dropdown resolutionsDropdown;
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
        resolutionsDropdown.value = currentResolutionIndex;
        resolutionsDropdown.RefreshShownValue();
    }

    public void SetVolume(float volume)
    {
        audioManager.SetVolume(volume);
    }

    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    public void SetFullScreen(bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
    }

    public void SetAntiAliasing(int antiAliasingIndex)
    {
        Debug.Log(antiAliasingIndex);
        switch (antiAliasingIndex)
        {
            case 1: QualitySettings.antiAliasing = 2; break;
            case 2: QualitySettings.antiAliasing = 4; break;
            case 3: QualitySettings.antiAliasing = 8; break;
            default: QualitySettings.antiAliasing = 0; break;
        }
    }

    public void SetVSync(int vSyncIndex)
    {
        Debug.Log(vSyncIndex);
        QualitySettings.vSyncCount = vSyncIndex;
    }
}
