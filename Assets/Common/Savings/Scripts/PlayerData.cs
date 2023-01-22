[System.Serializable]
public class PlayerData
{
    public int currentSceneIndex;
    public float[] position;
    public CatchableObjectData[] inventoryObjectsData = new CatchableObjectData[5];
    public SerializableDictionary<string, bool> catchableItemsCollected;
    public PlayerData()
    {
        catchableItemsCollected = new();
    }
}
