using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public Animator transition;
    public float transitionTime;

    public void LoadScene(int sceneIndex)
    {
        StartCoroutine(LoadSceneAsync(sceneIndex));
    }

    public IEnumerator LoadSceneAsync(int sceneIndex)
    {
        transition.SetTrigger("startTransition");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(sceneIndex);
        transition.SetTrigger("endTransition");
        yield return new WaitForSeconds(transitionTime);

    }
}
