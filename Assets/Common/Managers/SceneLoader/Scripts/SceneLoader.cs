using System.Collections;
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
        if (SavingController.playerData == null)
        {
            Debug.LogError("Nessun salvataggio trovato.");
            return;
        }
        LoadScene(SavingController.playerData.currentSceneIndex);
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

    public IEnumerator UpdateScene()
    {
        yield return new WaitForSeconds(transitionTime + 0.1f);
        SetUpdatesInScene();
    }

    public IEnumerator LoadPlayerAsync()
    {
        yield return new WaitForSeconds(transitionTime + 0.1f);
        if (SavingController.playerData != null)
        {
            SavingController.instance.LoadGame();
        }
    }

    private void SetUpdatesInScene()
    {
        AudioManager.instance.UpdateValues();
        SettingsManager.instance.UpdateSettings();
        SavingController.instance.UpdateAllDataPersistenceObjects();
        InventoryController.instance.insertItemsInInventoryBar();
    }
}
