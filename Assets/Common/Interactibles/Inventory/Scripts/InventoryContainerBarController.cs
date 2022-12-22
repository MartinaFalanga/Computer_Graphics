using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryContainerBarController : MonoBehaviour
{

    public GameObject[] gameObjects;
    private const int MAX_OBJECTS = 3;
    
    public void AddObject(GameObject go, int index) {
        go.SetActive(true);
        go.layer = 5;
        go.transform.SetParent(this.gameObjects[index].transform);
        go.transform.localPosition = Vector3.zero;
        go.transform.Rotate(0, 0, go.transform.localPosition.y);

        go.transform.eulerAngles = go.GetComponent<CatchableObjectController>().angleInInventory;
        go.transform.localScale = go.GetComponent<CatchableObjectController>().scaleInInventory;
        go.transform.localScale += new Vector3(600, 600, 600);
    }

    public void removeObject(int index) {
        
    }

}
