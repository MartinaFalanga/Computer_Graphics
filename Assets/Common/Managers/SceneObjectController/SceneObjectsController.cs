using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneObjectsController : MonoBehaviour
{
    public Dictionary<string, GameObject> nameToGameObject;
    public static SceneObjectsController instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            //Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);
    }


}
