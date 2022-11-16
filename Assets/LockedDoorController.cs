using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockedDoorController : MonoBehaviour
{

    public GameObject[] unlockableObjects;

    public GameObject padlockMenu;

    private LockType lockType;

    // To refactor
    public GameObject requiredInventory;
    public int[] combination;

    // Start is called before the first frame update
    void Start()
    {
        lockType = padlockMenu.GetComponent<LockMenuController>().lockType;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void showPadlock() {
        padlockMenu.SetActive(true);
        GameObject.Find("First Person Controller").GetComponent<CharacterMotor>().canControl = false;
        //GameObject.Find("First Person Controller").GetComponent<MouseLook>().canControl = false;

        switch(lockType) {
            case LockType.CombinationThree:
                Debug.Log("combination lock three");
                GameObject.Find("CombinationPadlock").GetComponent<CombinationThreePadlockController>().setActualGameObject(gameObject);
                break;
            case LockType.Classic:                
                Debug.Log("combination classic");
                GameObject.Find("ClassicPadlock").GetComponent<ClassicPadlockController>().setActualGameObject(gameObject);
                if(GameObject.Find("ClassicPadlock").GetComponent<ClassicPadlockController>().isInventoryValid()) {
                    unLock();
                }
                break;
            
        }
    }

    public void unLock() {
        padlockMenu.SetActive(false);

        GameObject.Find("First Person Controller").GetComponent<CharacterMotor>().canControl = true;
        //GameObject.Find("First Person Controller").GetComponent<MouseLook>().canControl = true;

        foreach(GameObject unlockableObject in unlockableObjects) {
            unlockableObject.GetComponent<CatchableObjectsController>().unLock();
        }

        gameObject.GetComponent<OpenCloseController>().unLock();
    }
}
