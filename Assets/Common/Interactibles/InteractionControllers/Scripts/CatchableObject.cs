using UnityEngine;

public class CatchableObject : MonoBehaviour, IInteractiveObject, IDataPersistence
{
    public string id;
    public Vector3 angleInInventory;
    public Vector3 scaleInInventory;
    public bool isInInventory;
    public bool isLocked;
    public string prefabName;
    public CatchableObjectData data;
    public ItemType type = ItemType.Catchable;

    [ContextMenu("Generate guid for id")]
    private void GenerateGuid()
    {
        id = System.Guid.NewGuid().ToString();
    }

    public void ExecuteLogic() {
        InventoryController inventory = InventoryController.instance;
        if(isInInventory) {
            isInInventory = false;
            inventory.deleteObject(this);
        } else {
            if(isLocked == false) {
                isInInventory = true;
                inventory.AddGameObject(this);
                gameObject.SetActive(false);
            }
        }
    }

    public void unLock() {
        isLocked = false;
    }

    public override string ToString()
    {
        return "id:" + id + "\tangleInInventory: " + angleInInventory + "\tscaleInInventory: " + scaleInInventory + "\tisInInventory: " + isInInventory
            + "\tisLocked: " + isLocked + "\tprefabName: " + prefabName;
    }

    public void LoadData(PlayerData playerData)
    {
        playerData.catchableItemsCollected.TryGetValue(id, out isInInventory);
        if (isInInventory)
        {
            this.gameObject.SetActive(false);
        }
    }

    public void SaveData(ref PlayerData playerData)
    {
        if (playerData.catchableItemsCollected.ContainsKey(id))
        {
            playerData.catchableItemsCollected.Remove(id);
        }
        playerData.catchableItemsCollected.Add(id, isInInventory);
    }
}

[CreateAssetMenu(fileName = "New Catchable Item Object", menuName = "Inventory/Items/Catchable")]
[System.Serializable]
public class CatchableObjectData : ItemObjectData
{
    public string id;
    public Vector3 angleInInventory;
    public Vector3 scaleInInventory;
    public bool isInInventory;
    public bool isLocked;

    public CatchableObjectData(string id, Vector3 angleInInventory, Vector3 scaleInInventory, bool isInInventory, bool isLocked, string prefabName)
    {
        Setup(id, angleInInventory, scaleInInventory, isInInventory, isLocked, prefabName);
    }

    public CatchableObjectData(CatchableObject co)
    {
        Setup(co.id, co.angleInInventory, co.scaleInInventory, co.isInInventory, co.isLocked, co.prefabName);
    }

    private void Setup(string id, Vector3 angleInInventory, Vector3 scaleInInventory, bool isInInventory, bool isLocked, string prefabName)
    {
        this.id = id;
        this.angleInInventory = angleInInventory;
        this.scaleInInventory = scaleInInventory;
        this.isInInventory = isInInventory;
        this.isLocked = isLocked;
        this.prefabName = prefabName;
    }
    public void Awake()
    {
        type = ItemType.Catchable;
    }

    public override string ToString()
    {
        return "id:" + id + "\tangleInInventory: " + angleInInventory + "\tscaleInInventory: " + scaleInInventory + "\tisInInventory: " + isInInventory
            + "\tisLocked: " + isLocked + "\tprefabName: " + prefabName;
    }
}