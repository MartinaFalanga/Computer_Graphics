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

    public void showPadlock() {
        padlockMenu.SetActive(true);

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
        padlockMenu.GetComponent<LockMenuController>().Dismiss();

        foreach(GameObject unlockableObject in unlockableObjects) {
            unlockableObject.GetComponent<InteractiveObjectController>().interactionCollider.GetComponent<BoxCollider>().enabled = true;
            unlockableObject.GetComponent<CatchableObjectController>().unLock();
        }

        gameObject.GetComponent<OpenCloseController>().unLock();
    }
}
