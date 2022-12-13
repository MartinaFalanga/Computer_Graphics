using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockedDoorController : MonoBehaviour
{

    public GameObject[] unlockableObjects;

    public GameObject padlockMenu;

    public GameObject uiCamera;

    public GameObject combinationPadlock;

    public GameObject classicPadlock;

    public GameObject menusCanvas;

    private LockType lockType;

    public GameObject[] requiredInventory;

    public int[] combination;

    // Start is called before the first frame update
    void Start()
    {
        lockType = padlockMenu.GetComponent<LockMenuController>().lockType;
    }

    public void showPadlock() {
        uiCamera.SetActive(true);
        padlockMenu.SetActive(true);

        switch(lockType) {
            case LockType.CombinationThree:
                Debug.Log("combination lock three");
                combinationPadlock.GetComponent<CombinationThreePadlockController>().setActualGameObject(gameObject);
                break;
            case LockType.Classic:                
                Debug.Log("combination classic");
                classicPadlock.GetComponent<ClassicPadlockController>().setActualGameObject(gameObject);
                if(classicPadlock.GetComponent<ClassicPadlockController>().isInventoryValid()) {
                    unLock();
                }
                break;
            
        }
    }

    public void unLock() {
        uiCamera.SetActive(false);
        menusCanvas.GetComponent<MenusController>().DismissAll();

        foreach(GameObject unlockableObject in unlockableObjects) {
            unlockableObject.GetComponent<InteractiveObjectController>().interactionCollider.GetComponent<BoxCollider>().enabled = true;
            unlockableObject.GetComponent<CatchableObjectController>().unLock();
        }

        gameObject.GetComponent<OpenCloseController>().unLock();
    }
}
