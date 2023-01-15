using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public enum ItemType
{
    Catchable,
    Default
}


[System.Serializable]
public class ItemObject
{
    public string prefabName;
    public ItemType type;
}
