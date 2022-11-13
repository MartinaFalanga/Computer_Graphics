using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryContainerBarController : MonoBehaviour
{

    public GameObject[] gameObjects;
    private const int MAX_OBJECTS = 3;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void addObject(GameObject go, int index) {
        go.SetActive(true);
        go.layer = 12;
        go.transform.SetParent(this.gameObjects[index].transform);
        go.transform.localPosition = Vector3.zero;
    }

    public void removeObject(int index) {
        
    }

}
