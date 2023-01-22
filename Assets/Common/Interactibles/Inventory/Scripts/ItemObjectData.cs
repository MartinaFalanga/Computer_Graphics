using UnityEngine;

[System.Serializable]
public enum ItemType
{
    Catchable,
    Default
}


[System.Serializable]
public class ItemObjectData
{
    public string prefabName;
    public ItemType type;
}
