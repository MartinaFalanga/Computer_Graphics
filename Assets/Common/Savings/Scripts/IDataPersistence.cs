using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDataPersistence
{
    public void LoadData(PlayerData playerData);
    public void SaveData(ref PlayerData playerData);
}
