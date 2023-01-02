using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorridorDoorOpener : MonoBehaviour, IInteractiveObject
{

    public GameObject doorLeft;
    [SerializeField] private Animator animatorLeft;

    public GameObject doorRight;
    [SerializeField] private Animator animatorRight;

    private bool doorsOpened = false;

    public void ExecuteLogic() {
        if(doorsOpened) // then close the doors
        {
            GetComponent<InteractiveObjectController>().interactionMenuText = "Premi F per aprire la porta";
            animatorLeft.Play("CloseDoorLeft", 0,0.0f);
            animatorRight.Play("CloseDoorRight", 0, 0.0f);
        } else // open the doors
        {
            GetComponent<InteractiveObjectController>().interactionMenuText = "Premi F per chiudere la porta";
            animatorLeft.Play("OpenDoorLeft", 0, 0.0f);
            animatorRight.Play("OpenDoorRight", 0, 0.0f);
            SceneDoorController sceneDoorController = GetComponent<SceneDoorController>();
            if (sceneDoorController != null)
            {
                sceneDoorController.ChangeScene();
            }
        }
        doorsOpened = !doorsOpened;
    }

}
