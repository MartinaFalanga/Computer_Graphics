using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClassicPadlockController : MonoBehaviour
{
    private GameObject lockedGameObject;

    private GameObject goRequiredInventoryObj1;
    private GameObject goRequiredInventoryObj2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            gameObject.transform.parent.gameObject.SetActive(false);
        }
    }

    public void setActualGameObject(GameObject go) {
        this.lockedGameObject = go;

        GameObject goRequiredInventory = go.GetComponent<LockedDoorController>().requiredInventory;
        goRequiredInventoryObj1 = Instantiate(goRequiredInventory.transform.GetChild(0).gameObject);
        goRequiredInventoryObj2 = Instantiate(goRequiredInventory.transform.GetChild(1).gameObject); 

        GameObject padlockMenuBar = GameObject.Find("InventoryRequiredBar").gameObject;

        goRequiredInventoryObj1.transform.SetParent(padlockMenuBar.transform.GetChild(0));
        goRequiredInventoryObj2.transform.SetParent(padlockMenuBar.transform.GetChild(1));

        goRequiredInventoryObj1.transform.localPosition = new Vector3(0,0,0);
        goRequiredInventoryObj1.layer = 12;
        goRequiredInventoryObj2.transform.localPosition = new Vector3(0,0,0);
        goRequiredInventoryObj2.layer = 12;
    }

    public bool isInventoryValid() {
        GameObject playerInventory = GameObject.Find("Inventory");
        GameObject[] playerInventoryObjects = playerInventory.GetComponent<InventoryController>().gameObjects;

        GameObject[] requiredInventoryObjects = new GameObject[2];

        requiredInventoryObjects[0] = goRequiredInventoryObj1;
        requiredInventoryObjects[1] = goRequiredInventoryObj2;
        
        foreach(GameObject requiredObject in requiredInventoryObjects) {
            bool isInInventory = false;
            foreach(GameObject playerInventoryObject in playerInventoryObjects) {
                if(playerInventoryObject != null) {
                    if(playerInventoryObject.name == requiredObject.name)
                        isInInventory = true;
                }
            }

            if(!isInInventory)
                return false;
        }

        foreach(GameObject requiredObject in requiredInventoryObjects) {
            playerInventory.GetComponent<InventoryController>().deleteObject(requiredObject);
        }

        return true;
    }
}
