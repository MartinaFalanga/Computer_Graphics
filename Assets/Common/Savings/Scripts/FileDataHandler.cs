using System.Collections;
using System.Collections.Generic;
using System.IO;

using UnityEngine;

public class FileDataHandler : MonoBehaviour
{
    private string dataDirPath = "";
    private string dataFileName = "";

    public FileDataHandler(string dataDirPath, string dataFileName)
    {
        this.dataDirPath = dataDirPath;
        this.dataFileName = dataFileName;
    }
    public PlayerData Load()
    {
        string fullPath = Path.Combine(dataDirPath, dataFileName);
        PlayerData loadedData = null;
        if (File.Exists(fullPath))
        {
            try
            {
                string dataToLoad = "";
                using (FileStream stream = new(fullPath, FileMode.Open))
                {
                    using (StreamReader reader = new (stream))
                    {
                        dataToLoad = reader.ReadToEnd();
                    }
                }
                loadedData = JsonUtility.FromJson<PlayerData>(dataToLoad);
            }
            catch(System.Exception e)
            {
                Debug.LogError("C'è stato un errore durante il caricamento del file: " + e);
            }
        }
        return loadedData;
    }

    public void Save(PlayerData data)
    {
        string fullPath = Path.Combine(dataDirPath, dataFileName);
        try
        {
            Directory.CreateDirectory(Path.GetDirectoryName(fullPath));
            string dataToStore = JsonUtility.ToJson(data, true);
            using(FileStream stream = new (fullPath, FileMode.Create))
            {
                using(StreamWriter writer = new (stream))
                {
                    writer.Write(dataToStore);
                }
            }
        }
        catch(System.Exception e)
        {
            Debug.LogError("C'è stato un errore durante il salvataggio su file: " + e);
        }
    }



}