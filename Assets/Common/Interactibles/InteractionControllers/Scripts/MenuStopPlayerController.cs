using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuStopPlayerController : MonoBehaviour
{

    public GameObject firstPersonController;
    public GameObject mainCamera;
    
    void OnEnable()
    {
        LockPlayer();
    }

    public void LockPlayer() {
        firstPersonController.GetComponent<CharacterMotor>().canControl = false;
        firstPersonController.GetComponent<CharacterMotor>().enabled = false;
        firstPersonController.GetComponent<MouseLook>().enabled = false;
        CursorManager.instance.UpdateCursor(false);
        mainCamera.GetComponent<MouseLook>().enabled = false;
    }
}
