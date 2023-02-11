using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuStopPlayerController : MonoBehaviour
{

    public GameObject firstPersonController;
    public bool shouldStartLocked = true;
    
    void OnEnable()
    {
        if (shouldStartLocked)
        {
            LockPlayer();
        }
    }

    public void LockPlayer() {
        firstPersonController.GetComponent<CharacterMotor>().canControl = false;
        firstPersonController.GetComponent<CharacterMotor>().enabled = false;
        firstPersonController.GetComponent<MouseLook>().enabled = false;
        CursorManager.instance.UpdateCursor(true);
    }
}
