using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System.Linq;
using System.Collections;

public class SavingController : MonoBehaviour{

    public static SavingController instance;
    public static Player player;
    public static int savedScene;
    public static PlayerData playerData;
    private List<IDataPersistence> dataPersistenceObjectList;
    private FileDataHandler dataHandler;
    [Header("File Storage config")]
    [SerializeField] private string fileName;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);
    }

    public void Start()
    {
        this.dataHandler = new (Application.persistentDataPath, fileName);
    }

    public void NewGame()
    {
        playerData = new PlayerData();
    }

    public void LoadGame()
    {
        playerData = dataHandler.Load();
        if(playerData == null)
        {
            NewGame();
        }
        //SceneLoader.instance.LoadSceneFromSavings(playerData);

        foreach (IDataPersistence idpo in dataPersistenceObjectList)
        {
            idpo.LoadData(playerData);
        }
        Debug.Log("Caricamento completato!");
    }

    public void SaveGame()
    {
        if(playerData == null)
        {
            NewGame();
        }
        playerData.currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        Debug.Log("dataPersistenceObjectList: " + dataPersistenceObjectList.Count);
        foreach (IDataPersistence idpo in dataPersistenceObjectList)
        {
            idpo.SaveData(ref playerData);
        }
        dataHandler.Save(playerData);
        Debug.Log("Salvataggio completato!");
    }

    /*private void OnApplicationQuit()
    {
        //Autosalvataggio in fase di chiusura dell'applicazione
        SaveGame();
    }*/

    public void UpdateAllDataPersistenceObjects()
    {
        IEnumerable <IDataPersistence> dataPersistenceObjects = FindObjectsOfType<MonoBehaviour>().OfType<IDataPersistence>();
        this.dataPersistenceObjectList = new List<IDataPersistence>(dataPersistenceObjects);
        Debug.Log("trovati dataPersistenceObjectList: " + dataPersistenceObjectList);
    }
}
