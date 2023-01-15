using System.Collections;
using System.Collections.Generic;

using SOHNE.Accessibility.Colorblindness;

using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public Animator transition;
    public float transitionTime;
    private static bool sceneChanged = false;
    public static SceneLoader instance;

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
        SetUpdatesInScene();
    }

    public static bool IsSceneChanged() {
        return sceneChanged;
    }

    public void LoadScene(int sceneIndex)
    {
        StartCoroutine(LoadSceneAsync(sceneIndex));
        StartCoroutine(UpdateScene());
    }

    public void LoadSceneFromSavings()
    {
        StartCoroutine(LoadSceneFromSavingsAsync());
        StartCoroutine(UpdateScene());
        StartCoroutine(LoadPlayerAsync());
    }

    public IEnumerator LoadSceneAsync(int sceneIndex)
    {
        transition.SetTrigger("startTransition");
        sceneChanged = true;
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(sceneIndex);
        sceneChanged = false;
        transition.SetTrigger("endTransition");
    }

    public IEnumerator LoadSceneFromSavingsAsync()
    {
        transition.SetTrigger("startTransition");
        sceneChanged = true;
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(SavingController.playerData.currentSceneIndex);
        sceneChanged = false;
        transition.SetTrigger("endTransition");
    }

    public IEnumerator UpdateScene()
    {
        yield return new WaitForSeconds(transitionTime + 0.1f);
        SetUpdatesInScene();
    }

    public IEnumerator LoadPlayerAsync()
    {
        yield return new WaitForSeconds(transitionTime + 0.1f);
        SavingController.instance.LoadGame();
        /*Player player = FindObjectOfType<Player>();
        Debug.Log("Player: " + player);
        if (player != null && playerData != null)
        {
            player.LoadData(playerData);
            Debug.Log("Caricamento completato!");
        }*/
    }

    private void SetUpdatesInScene()
    {
        AudioManager.instance.UpdateValues();
        SettingsManager.instance.UpdateSettings();
        SavingController.instance.UpdateAllDataPersistenceObjects();
    }
}
