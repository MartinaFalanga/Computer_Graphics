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
        playerData = dataHandler.Load();
    }

    public void NewGame()
    {
        playerData = new PlayerData();

        //Destroy the whole inventory
        InventoryController.instance.numOfItems = 0;
        InventorySlot[] slots = InventoryController.instance.inventorySlots;
        foreach(InventorySlot s in slots)
        {
            s.item = null;
            CatchableObject co = s.GetComponentInChildren<CatchableObject>();
            if (co != null)
            {
                Destroy(co.gameObject);
            }
        }
    }

    public void LoadGame()
    {
        playerData = dataHandler.Load();
        if(playerData == null)
        {
            NewGame();
        }

        foreach (IDataPersistence idpo in dataPersistenceObjectList)
        {
            idpo.LoadData(playerData);
        }
        InventoryController.instance.LoadData(playerData);
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
        InventoryController.instance.SaveData(ref playerData);
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
