using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryObjectController : MonoBehaviour
{

    public Vector3 angle;
    public Vector3 scale;

    /* private methods */
    private IEnumerator OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            GameObject player = other.gameObject;
            GameObject inventory = player.transform.Find("Inventory").gameObject;

            if (Input.GetKeyDown(KeyCode.F)) {
                // put this object into player inventory if not locked
                if(gameObject.GetComponent<CatchableObjectsController>().isLocked == false) {
                    inventory.GetComponent<InventoryController>().AddGameObject(gameObject);
                }
            }
        }
        yield return new WaitForSeconds(1);
    }

    

}
