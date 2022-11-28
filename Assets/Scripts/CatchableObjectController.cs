using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatchableObjectController : MonoBehaviour, IInteractiveObject
{

    public Vector3 angleInInventory;
    public Vector3 scaleInInventory;
    public bool isInInventory;    
    public bool isLocked;

    public void ExecuteLogic() {
        GameObject player = GameObject.Find("First Person Controller").gameObject;
        GameObject inventory = player.transform.Find("Inventory").gameObject;

        if(isInInventory) {
            isInInventory = false;
            ReleaseToGround();
            inventory.GetComponent<InventoryController>().deleteObject(gameObject);
        } else {
            if(isLocked == false) {
                isInInventory = true;
                inventory.GetComponent<InventoryController>().AddGameObject(gameObject);
            }
        }
    }

    public void unLock() {
        this.isLocked = false;
    }

    public void ReleaseToGround() {
        // crea copia dell'oggetto e lo mette a terra, ai piedi del giocatore
    }

}
