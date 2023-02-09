using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryContainerBarController : MonoBehaviour
{

    public GameObject[] gameObjects;
    public static InventoryContainerBarController instance;

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
    }

    public void AddObject(GameObject go, int index) {
        go.SetActive(true);
        go.layer = 5;
        go.transform.SetParent(this.gameObjects[index].transform);
        go.transform.localPosition = Vector3.zero;
        go.transform.Rotate(0, 0, go.transform.localPosition.y);

        go.transform.eulerAngles = go.GetComponent<CatchableObject>().angleInInventory;
        go.transform.localScale = go.GetComponent<CatchableObject>().scaleInInventory;
        go.transform.localScale += new Vector3(600, 600, 600);
    }

    public void DeleteObject(int index)
    {
        Destroy(this.gameObjects[index].GetComponent<Transform>().GetChild(0).gameObject);
    }

}
