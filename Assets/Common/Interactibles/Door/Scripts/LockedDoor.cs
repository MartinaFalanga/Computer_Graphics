using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockedDoor : MonoBehaviour
{

    public GameObject[] unlockableObjects;

    public GameObject padlockMenu;

    public GameObject combinationPadlock;

    public GameObject classicPadlock;

    public GameObject menusCanvas;

    public GameObject mainCamera;

    private LockType lockType;

    public CatchableObject[] requiredInventory;

    public int[] combination;

    // Start is called before the first frame update
    void Start()
    {
        lockType = padlockMenu.GetComponent<LockMenuController>().lockType;
    }

    public void showPadlock() {
        padlockMenu.SetActive(true);
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera");

        FindObjectOfType<Camera>().depth = 0;

        switch (lockType) {
            case LockType.CombinationThree:
                combinationPadlock.GetComponent<CombinationThreePadlockController>().setActualGameObject(gameObject);
                break;
            case LockType.Classic:
                classicPadlock.GetComponent<ClassicPadlockController>().setActualGameObject(gameObject);
                if(classicPadlock.GetComponent<ClassicPadlockController>().isInventoryValid()) {
                    unLock();
                }
                break;
            
        }
    }

    public void unLock() {
        foreach(GameObject unlockableObject in unlockableObjects) {
            unlockableObject.GetComponent<InteractiveObjectController>().interactionCollider.GetComponent<BoxCollider>().enabled = true;
            unlockableObject.GetComponent<CatchableObject>().unLock();
        }
        gameObject.GetComponent<OpenCloseController>().unLock();
        menusCanvas.GetComponent<MenusController>().DismissAll();
    }
}
