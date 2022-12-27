using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private InventoryController inventoryController;

    public void LoadPlayer(PlayerData data)
    {
        inventoryController.inventoryObjects = data.inventoryObjects;

        Vector3 position;
        position.x = data.position[0];
        position.y = data.position[1];
        position.z = data.position[2];
        transform.position = position;
    }
}
