using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour
{

    public GameObject[] gameObjects;
    public InventoryContainerBarController inventoryBar;
    private int currIndex = 0;
    private const int MAX_OBJECTS = 3;
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            inventoryBar.transform.parent.gameObject.SetActive(true);
        } else if (Input.GetKeyDown(KeyCode.Q))
        {
            inventoryBar.transform.parent.gameObject.SetActive(false);
        }
    }

    public void AddGameObject(GameObject go) {
        if(currIndex <MAX_OBJECTS) {
            Debug.Log("Inserting object in inventory");
            gameObjects[currIndex] = go;
            go.SetActive(false);
            insertInInventoryBar(go, currIndex);
            Debug.Log("Object inserted successfully");
            currIndex++;
        } else {
            Debug.Log("Can't insert game object in your inventory. FULL INVENTORY");
        }
    }

    /** private methods */

    private void insertInInventoryBar(GameObject goToDuplicate, int currIndex) {
        GameObject go = GameObject.Instantiate(goToDuplicate);
        inventoryBar.addObject(go, currIndex);
    }

    public void deleteObject(GameObject toDelete) {
        int i = 0;
        bool deleted = false;
        foreach(GameObject playerInventoryObject in gameObjects) {
            if(playerInventoryObject != null) {
                if(playerInventoryObject.name == toDelete.name) {
                    gameObjects[i] = null;
                    deleted = true;
                }
            }

            if(deleted && i<gameObjects.Length-1) {
                gameObjects[i] = gameObjects[i+1];
            }
            i++;
        }
    }
}
