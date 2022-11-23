using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryContainerBarController : MonoBehaviour
{

    public GameObject[] gameObjects;
    private const int MAX_OBJECTS = 3;
    
    public void addObject(GameObject go, int index) {
        go.SetActive(true);
        go.layer = 12;
        go.transform.SetParent(this.gameObjects[index].transform);
        go.transform.localPosition = Vector3.zero;
        
        go.transform.eulerAngles = go.GetComponent<CatchableObjectController>().angleInInventory;
        go.transform.localScale = go.GetComponent<CatchableObjectController>().scaleInInventory;
    }

    public void removeObject(int index) {
        
    }

}
