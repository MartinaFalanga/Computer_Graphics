using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClassicPadlockController : MonoBehaviour
{
    private GameObject lockedGameObject;

    private GameObject[] goRequiredInventoryObj;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Debug.Log("Dismissing padlock menu");
            gameObject.transform.parent.gameObject.SetActive(false);
            GameObject.Find("First Person Controller").GetComponent<CharacterMotor>().canControl = true;
        }
    }

    public void setActualGameObject(GameObject go) {
        this.lockedGameObject = go;
        GameObject padlockMenuBar = GameObject.Find("InventoryRequiredBar").gameObject;

        GameObject goRequiredInventory = go.GetComponent<LockedDoorController>().requiredInventory;
        goRequiredInventoryObj = new GameObject[goRequiredInventory.transform.childCount];

        int i = 0;
        foreach(Transform goRequiredInventoryChild in goRequiredInventory.transform) {
            goRequiredInventoryObj[i] = Instantiate(goRequiredInventoryChild.gameObject);
            goRequiredInventoryObj[i].transform.SetParent(padlockMenuBar.transform.GetChild(i));
            goRequiredInventoryObj[i].transform.localPosition = new Vector3(0,0,0);
            goRequiredInventoryObj[i].transform.localScale = goRequiredInventoryObj[i].GetComponent<RequiredInventoryDimensionsController>().scale;
            goRequiredInventoryObj[i].transform.eulerAngles = goRequiredInventoryObj[i].GetComponent<RequiredInventoryDimensionsController>().angle;
            goRequiredInventoryObj[i].layer = 12;
            i++;
        }
    }

    public bool isInventoryValid() {
        GameObject playerInventory = GameObject.Find("Inventory");
        GameObject[] playerInventoryObjects = playerInventory.GetComponent<InventoryController>().gameObjects;

        GameObject[] requiredInventoryObjects = new GameObject[2];

        int i = 0;
        foreach(GameObject go in goRequiredInventoryObj) {
            requiredInventoryObjects[i] = go;
            i++;
        }
        
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
