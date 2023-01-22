using UnityEngine;

public class Player : MonoBehaviour, IDataPersistence
{
    public void LoadData(PlayerData data)
    {
        Vector3 position;
        position.x = data.position[0];
        position.y = data.position[1];
        position.z = data.position[2];
        transform.position = position;
    }

    public void SaveData(ref PlayerData playerData)
    {
        float[] position = new float[3];
        position[0] = transform.position.x;
        position[1] = transform.position.y;
        position[2] = transform.position.z;
        playerData.position = position;
    }
}
