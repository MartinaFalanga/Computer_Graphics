using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionColliderController : MonoBehaviour
{

    public bool isCollidingWithPlayer = false;

    private InteractiveObjectController interactiveObjectController;

    public void SetInteractiveObjectController(InteractiveObjectController interactiveObjectController) {
        this.interactiveObjectController = interactiveObjectController;
    }

    private IEnumerator OnTriggerEnter(Collider other)
    {        
        if (other.tag == "Player")
        {
            isCollidingWithPlayer = true;
            interactiveObjectController.InteractionColliderEntered();
        }

        yield return new WaitForSeconds(0);
    }

    private IEnumerator OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("Player exited collider");
            isCollidingWithPlayer = false;
            interactiveObjectController.InteractionColliderExited();
        }
        
        yield return new WaitForSeconds(0);
    }

}
