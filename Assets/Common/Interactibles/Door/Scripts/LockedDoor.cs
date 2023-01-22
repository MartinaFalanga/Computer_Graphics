using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class LockedDoor : MonoBehaviour
{

    public GameObject[] unlockableObjects;

    private GameObject padlock;

    public GameObject menusCanvas;

    public GameObject mainCamera;

    public LockType lockType;

    public CatchableObject[] requiredInventory;

    public int[] combination;

    public void showPadlock() {
        LockMenuController[] lockMenuControllers = menusCanvas.GetComponentsInChildren<LockMenuController>();
        LockMenuController currentLMC = null;
        if (LockType.Classic.Equals(lockType)) {
            currentLMC = FindLockMenuControllerByName("ClassicPadlockMenu");
            currentLMC.gameObject.SetActive(true);
            padlock = currentLMC.GetComponentInChildren<ClassicPadlockController>().gameObject;
        }
        else if(LockType.CombinationThree.Equals(lockType))
        {
            currentLMC = FindLockMenuControllerByName("NumPadlockMenu");
            currentLMC.gameObject.SetActive(true);
            padlock = currentLMC.GetComponentInChildren<CombinationThreePadlockController>().gameObject;
        }

        mainCamera.GetComponent<Camera>().depth = 0;

        switch (lockType) {
            case LockType.CombinationThree:
                padlock.GetComponent<CombinationThreePadlockController>().setActualGameObject(gameObject);
                break;
            case LockType.Classic:
                padlock.GetComponent<ClassicPadlockController>().setActualGameObject(gameObject);
                if(padlock.GetComponent<ClassicPadlockController>().isInventoryValid()) {
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


    private LockMenuController FindLockMenuControllerByName(string padlockMenuName)
    {
        LockMenuController[] lmcs = menusCanvas.GetComponentsInChildren<LockMenuController>(true);
        foreach (LockMenuController lmc in lmcs)
        {
            if (padlockMenuName.Equals(lmc.gameObject.name)){
                return lmc;
            }
        }
        return null;
    }
}