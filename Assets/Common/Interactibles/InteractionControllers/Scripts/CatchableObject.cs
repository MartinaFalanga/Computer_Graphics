using UnityEngine;

public class CatchableObject : MonoBehaviour, IInteractiveObject, IDataPersistence
{
    [SerializeField] private string id;
    public Vector3 angleInInventory;
    public Vector3 scaleInInventory;
    public bool isInInventory;
    public bool isLocked;

    [ContextMenu("Generate guid for id")]
    private void GenerateGuid()
    {
        id = System.Guid.NewGuid().ToString();
    }

    public void ExecuteLogic() {
        InventoryController inventory = FindObjectOfType<InventoryController>();

        if(isInInventory) {
            isInInventory = false;
            inventory.deleteObject(this);
        } else {
            if(isLocked == false) {
                inventory.AddGameObject(this);
                isInInventory = true;
                gameObject.SetActive(false);
            }
        }
    }

    public void unLock() {
        this.isLocked = false;
    }

    public override string ToString()
    {
        return "angleInInventory: " + angleInInventory + "\tscaleInInventory: " + scaleInInventory + "\tisInInventory: " + isInInventory + "\tisLocked: " + isLocked;
    }

    public void LoadData(PlayerData playerData)
    {
        playerData.catchableItemsCollected.TryGetValue(id, out isInInventory);
        Debug.Log("L'oggetto " + this.name + " è nel'inventario? " + isInInventory);
        if (isInInventory)
        {
            Debug.Log("E' nell'inventario");
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
        if(playerData.catchableItemsCollected.Count != 0)
        {
            Debug.Log(gameObject.name + " - " + id + " - " + playerData.catchableItemsCollected[id]);
        }
    }
}

[CreateAssetMenu(fileName = "New Catchable Item Object", menuName = "Inventory/Items/Catchable")]
[System.Serializable]
public class CatchableObjectData : ItemObject
{
    public Vector3 angleInInventory;
    public Vector3 scaleInInventory;
    public bool isInInventory;
    public bool isLocked;

    public void Awake()
    {
        type = ItemType.Catchable;
    }

    public override string ToString()
    {
        return "angleInInventory: " + angleInInventory + "\tscaleInInventory: " + scaleInInventory + "\tisInInventory: " + isInInventory + "\tisLocked: " + isLocked;
    }
}