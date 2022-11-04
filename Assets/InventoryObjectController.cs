using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryObjectController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            GameObject player = other.gameObject;
            GameObject inventory = player.transform.Find("Inventory").gameObject;

            if (Input.GetKeyDown(KeyCode.F)) {
                // put this object into player inventory if not locked
                if(gameObject.GetComponent<InteractiveObjectsController>().isLocked == false)
                    inventory.GetComponent<InventoryController>().AddGameObject(gameObject);
            }
        }
        yield return new WaitForSeconds(1);
    }   
}
