using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public int currentSceneIndex;
    public float[] position;
    public CatchableObjectData[] inventoryObjectData;
    public SerializableDictionary<string, bool> catchableItemsCollected;
    public PlayerData()
    {
        catchableItemsCollected = new();
    }
}
