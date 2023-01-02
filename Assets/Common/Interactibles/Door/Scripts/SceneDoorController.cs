using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneDoorController : MonoBehaviour
{
    public int sceneIndex;
    private SceneLoaderProxy sceneLoaderProxy;

    public void Awake()
    {
        sceneLoaderProxy = FindObjectOfType<SceneLoaderProxy>();
    }

    public void ChangeScene()
    {
        if(sceneLoaderProxy != null)
        {
            sceneLoaderProxy.LoadScene(sceneIndex);
        }
    }
}
