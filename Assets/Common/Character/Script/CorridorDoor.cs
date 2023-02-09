using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorridorDoor : MonoBehaviour, IInteractiveObject
{

    public GameObject doorLeft;
    [SerializeField] private Animator animatorLeft;

    public GameObject doorRight;
    [SerializeField] private Animator animatorRight;

    private bool doorsOpened = false;

    public bool isLocked;

    public void ExecuteLogic() {
        if(doorsOpened) // then close the doors
        {
            // GetComponent<InteractiveObjectController>().interactionMenuText = "Premi F per aprire la porta";
            //animatorLeft.Play("CloseDoorLeft", 0,0.0f);
            //animatorRight.Play("CloseDoorRight", 0, 0.0f);
        } else // open the doors
        {
            // GetComponent<InteractiveObjectController>().interactionMenuText = "Premi F per chiudere la porta";
            //animatorLeft.Play("OpenDoorLeft", 0, 0.0f);
            //animatorRight.Play("OpenDoorRight", 0, 0.0f);

            CatchableObject[] requiredInventory = GetComponent<LockedDoor>().requiredInventory;
            InventoryController inventoryController = InventoryController.instance;
            bool flag = true;
            foreach(CatchableObject catchableObject in requiredInventory)
            {
                if(!inventoryController.IsAlreadyInInventory(catchableObject))
                {
                    flag = false; break;
                }
            }
            isLocked=!flag;

            if (isLocked)
                gameObject.GetComponent<LockedDoor>().showPadlock();
            else
            {
                foreach (CatchableObject catchableObject in requiredInventory)
                {
                    inventoryController.deleteObject(catchableObject);
                }

                SceneDoorController sceneDoorController = GetComponent<SceneDoorController>();
                if (sceneDoorController != null)
                {
                    sceneDoorController.ChangeScene();
                }
            }
        }
        // doorsOpened = !doorsOpened;
    }

}
