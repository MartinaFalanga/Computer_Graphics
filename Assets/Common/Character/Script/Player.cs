using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, IDataPersistence
{
    private InventoryController inventoryController;

    public InventoryController InventoryController { get => inventoryController; set => inventoryController = value; }

    public void Awake()
    {
        inventoryController = GetComponentInChildren<InventoryController>();
    }

    public void LoadData(PlayerData data)
    {
        int i = 0;
        foreach (CatchableObjectData cod in data.inventoryObjectData)
        {
            CatchableObject co = Resources.Load<CatchableObject>("Prefabs/" + cod.prefabName);
            Debug.Log("Player - co: " + co);
            co.angleInInventory = cod.angleInInventory;
            co.scaleInInventory = cod.scaleInInventory;
            co.isInInventory = cod.isInInventory;
            co.isLocked = cod.isLocked;
            inventoryController.AddGameObject(co);
            i++;
        }

        Vector3 position;
        position.x = data.position[0];
        position.y = data.position[1];
        position.z = data.position[2];
        transform.position = position;
    }

    public void SaveData(ref PlayerData playerData)
    {
        Debug.Log("Siamo in saveData");
        float[] position = new float[3];
        position[0] = transform.position.x;
        position[1] = transform.position.y;
        position[2] = transform.position.z;
        playerData.position = position;

        CatchableObject[] inventoryObjects = inventoryController.inventoryObjects;
        List<CatchableObjectData> iods = new ();
        int i = 0;
        foreach (CatchableObject co in inventoryObjects)
        {
            if (co != null)
            {
                iods.Add(new()
                {
                    angleInInventory = co.angleInInventory,
                    scaleInInventory = co.scaleInInventory,
                    isInInventory = co.isInInventory,
                    isLocked = co.isLocked,
                    prefabName = co.gameObject.name,
                    type = ItemType.Catchable
                });
            }
            i++;
        }
        playerData.inventoryObjectData = iods.ToArray();
        foreach (CatchableObjectData cod in playerData.inventoryObjectData)
        {
            Debug.Log("Ecco il cod: " + cod);
        }
    }
}
