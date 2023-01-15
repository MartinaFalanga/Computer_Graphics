using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class InventoryController : MonoBehaviour
{
    public CatchableObject[] inventoryObjects;
    public InventoryContainerBarController inventoryBar;
    private int numOfItems = 0;
    private const int MAX_OBJECTS = 5;

    public void AddGameObject(CatchableObject go) {
        if(numOfItems < MAX_OBJECTS) {
            inventoryObjects[numOfItems] = go;
            insertInInventoryBar(go.name, numOfItems);
            Debug.Log("Object inserted successfully");
            numOfItems++;
        } else {
            Debug.Log("Can't insert game object in your inventory. FULL INVENTORY");
        }
    }

    /** private methods */

    private void insertInInventoryBar(string objectName, int currIndex) {
        Debug.Log("ObjectName: " + objectName);
        GameObject prefab = Instantiate(Resources.Load<GameObject>("Prefabs/" + objectName)) as GameObject;
        inventoryBar.AddObject(prefab, currIndex);
    }

    public void deleteObject(CatchableObject toDelete) {
        int i = 0;
        bool deleted = false;
        foreach(CatchableObject playerInventoryObject in inventoryObjects) {
            if(playerInventoryObject != null) {
                if(playerInventoryObject.name == toDelete.name) {
                    inventoryObjects[i] = null;
                    deleted = true;
                }
            }

            if(deleted && i<inventoryObjects.Length-1) {
                inventoryObjects[i] = inventoryObjects[i+1];
            }
            i++;
        }
    }
}

[System.Serializable]
public class InventorySlot
{
    public ItemObject item;
    public InventorySlot(ItemObject _item)
    {
        item = _item;
    }
}
