using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public Animator transition;
    public float transitionTime;
    private SettingsManager settingsManager;
    private static bool sceneChanged = false;

    public static bool IsSceneChanged() {
        return sceneChanged;
    }

    public void LoadScene(int sceneIndex)
    {
        StartCoroutine(LoadSceneAsync(sceneIndex));
    }

    public IEnumerator LoadSceneAsync(int sceneIndex)
    {
        transition.SetTrigger("startTransition");
        sceneChanged = true;
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(sceneIndex);
        sceneChanged = false;
        Debug.Log("Changed");
        settingsManager = FindObjectOfType<SettingsManager>();
        settingsManager.updateSettings();
        transition.SetTrigger("endTransition");
    }
}
