using UnityEngine;

public class SceneLoaderProxy : MonoBehaviour
{
    public void LoadScene(int sceneIndex)
    {
        SceneLoader.instance.LoadScene(sceneIndex);
    }
}
