using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClassicPadlockController : MonoBehaviour
{
    private GameObject lockedGameObject;

    private CatchableObject[] goRequiredInventoryObj;

    public GameObject padlockMenuBar;

    public GameObject firstPersonController;

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
            firstPersonController.GetComponent<CharacterMotor>().canControl = true;
        }
    }

    public void setActualGameObject(GameObject go) {
        this.lockedGameObject = go;

        CatchableObject[] goRequiredInventory = go.GetComponent<LockedDoor>().requiredInventory;
        goRequiredInventoryObj = new CatchableObject[goRequiredInventory.Length];

        int i = 0;
        foreach(CatchableObject goRequiredInventoryGameObject in goRequiredInventory) {
            Debug.Log("Putting " + goRequiredInventoryGameObject.name + " in required inventory");
            goRequiredInventoryObj[i] = Instantiate(goRequiredInventoryGameObject);
            goRequiredInventoryObj[i].transform.SetParent(padlockMenuBar.transform.GetChild(i));
            goRequiredInventoryObj[i].transform.localPosition = new Vector3(0,0,0);
            goRequiredInventoryObj[i].transform.localScale = goRequiredInventoryObj[i].GetComponent<RequiredInventoryDimensionsController>().scale;
            goRequiredInventoryObj[i].transform.eulerAngles = goRequiredInventoryObj[i].GetComponent<RequiredInventoryDimensionsController>().angle;
            goRequiredInventoryObj[i].gameObject.layer = LayerMask.NameToLayer("UI");
            i++;
        }
    }

    public bool isInventoryValid() {
        CatchableObject[] playerInventoryObjects = InventoryController.instance.GetCatchableObjects();

        CatchableObject[] requiredInventoryObjects = new CatchableObject[2];

        int i = 0;
        foreach(CatchableObject go in goRequiredInventoryObj) {
            requiredInventoryObjects[i] = go;
            i++;
        }

        Debug.Log("OOO - requiredInventoryObjects length= " + requiredInventoryObjects.Length);

        foreach (CatchableObject requiredObject in requiredInventoryObjects) {
            bool isInInventory = false;
            Debug.Log("AAA - requiredObject.name = " + requiredObject.name);
            foreach (CatchableObject playerInventoryObject in playerInventoryObjects) {
                if (playerInventoryObject != null)
                {
                    Debug.Log("CCC - playerInventoryObject.name = " + playerInventoryObject.name + " requiredObject.name = " + requiredObject.name);
                    if (playerInventoryObject.name + "(Clone)" == requiredObject.name) // il confronto si basa sul nome
                        isInInventory = true;
                }
            }

            if(!isInInventory)
                return false;
        }

        foreach(CatchableObject requiredObject in requiredInventoryObjects) {
            InventoryController.instance.deleteObject(requiredObject);
        }

        return true;
    }
}
