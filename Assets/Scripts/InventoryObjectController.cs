using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryObjectController : MonoBehaviour, IInteractiveObject
{

    public Vector3 angle;
    public Vector3 scale;
    

    public void ExecuteLogic() {
        GameObject player = GameObject.Find("First Person Controller").gameObject;
        GameObject inventory = player.transform.Find("Inventory").gameObject;

        if(gameObject.GetComponent<CatchableObjectsController>().isLocked == false) {
            inventory.GetComponent<InventoryController>().AddGameObject(gameObject);
        }
    }

}
