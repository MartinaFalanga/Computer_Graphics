using System;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.SceneManagement;

public class InventoryController : MonoBehaviour
{
    public InventorySlot[] inventorySlots;
    public int numOfItems = 0;
    private const int MAX_OBJECTS = 5;
    public static InventoryController instance;

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

    public void AddGameObject(CatchableObject go) {
        if(numOfItems < MAX_OBJECTS) {
            GameObject goCopy = Instantiate(Resources.Load<GameObject>("Prefabs/" + go.name));
            goCopy.name = go.name;
            Utility.CopyComponent<CatchableObject>(go, goCopy);
            goCopy.gameObject.transform.SetParent(inventorySlots[numOfItems].transform);
            inventorySlots[numOfItems].item = goCopy.GetComponent<CatchableObject>();
            if (SceneManager.GetActiveScene().buildIndex != 0)
            {
                insertInInventoryBar(go.name, numOfItems);
            }
            Debug.Log("Object inserted successfully");
            numOfItems++;
        } else {
            Debug.Log("Can't insert game object in your inventory. FULL INVENTORY");
        }
    }

    public CatchableObject[] GetCatchableObjects()
    {
        CatchableObject[] catchableObjects = new CatchableObject[5];
        for(int i=0; i<5; i++)
        {
            InventorySlot slot = inventorySlots[i];
            CatchableObject co;
            if (slot != null && ((co = slot.item) != null || (co = slot.GetComponentInChildren<CatchableObject>()) != null))
            {
                slot.item = co;
                catchableObjects[i] = co;
            }
            else break;
        }
        return catchableObjects;
    }
    /** private methods */

    private void insertInInventoryBar(string objectName, int currIndex) {
        Debug.Log("ObjectName: " + objectName);
        GameObject prefab = Instantiate(Resources.Load<GameObject>("Prefabs/" + objectName));
        InventoryContainerBarController.instance.AddObject(prefab, currIndex);
    }

    public void insertItemsInInventoryBar()
    {
        CatchableObject co;
        for (int i=0; i<numOfItems; i++)
        {
            if (inventorySlots[i] != null && ((co = inventorySlots[i].item) != null || (co = inventorySlots[i].GetComponentInChildren<CatchableObject>()) != null))
            {
                inventorySlots[i].item = co;
                if (SceneManager.GetActiveScene().buildIndex != 0)
                {
                    insertInInventoryBar(co.name, i);
                }
            }
            else break;
        }
    }

    public void deleteObject(CatchableObject toDelete) {
        int i = 0;
        bool deleted = false;
        foreach(InventorySlot slot in inventorySlots) {
            if(slot != null && slot.item != null && slot.item.name == toDelete.name) {
                inventorySlots[i] = null;
                deleted = true;
            }

            if(deleted && i<inventorySlots.Length-1) {
                inventorySlots[i].item = inventorySlots[i+1].item;
            }
            i++;
        }
    }

    public void LoadData(PlayerData playerData)
    {
        int i = 0;
        foreach (CatchableObjectData savedCod in playerData.inventoryObjectsData)
        {
            CatchableObject co = Resources.Load<CatchableObject>("Prefabs/" + savedCod.prefabName);
            co.id = savedCod.id;
            Debug.Log("InventoryController - catchableObject: " + co);
            if (!IsAlreadyInInventory(co))
            {
                co.angleInInventory = savedCod.angleInInventory;
                co.scaleInInventory = savedCod.scaleInInventory;
                co.isInInventory = savedCod.isInInventory;
                co.isLocked = savedCod.isLocked;
                co.prefabName = savedCod.prefabName;
                co.data = savedCod;
                AddGameObject(co);
                co.gameObject.SetActive(true);
            }
            i++;
        }
    }

    private bool IsAlreadyInInventory(CatchableObject coToCheck)
    {
        bool isAlreadyInInventory = false;
        CatchableObject[] cos = GetCatchableObjects();
        foreach(CatchableObject coInInventory in cos)
        {
            if(coInInventory != null && coToCheck.id == coInInventory.id)
            {
                isAlreadyInInventory = true;
            }
        }
        return isAlreadyInInventory;
    }

    public void SaveData(ref PlayerData playerData)
    {
        CatchableObject[] inventoryObjects = GetCatchableObjects();
        List<CatchableObjectData> coList = new();
        foreach (CatchableObject co in inventoryObjects)
        {
            if (co != null)
            {
                CatchableObjectData data = new(co);
                coList.Add(data);
            }
        }
        playerData.inventoryObjectsData = coList.ToArray();
        foreach(CatchableObjectData d in playerData.inventoryObjectsData)
        {
            Debug.Log("Oggetto in playerData: " + d);
        }
    }
}
