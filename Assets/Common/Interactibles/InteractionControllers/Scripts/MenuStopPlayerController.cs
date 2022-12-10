using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuStopPlayerController : MonoBehaviour
{
    
    void OnEnable()
    {
        LockPlayer();
    }

    private void LockPlayer() {
        GameObject player = GameObject.Find("First Person Controller").gameObject;
        GameObject mainCamera = GameObject.Find("Main Camera").gameObject;

        player.GetComponent<CharacterMotor>().canControl = false;
        player.GetComponent<CharacterMotor>().enabled = false;
        player.GetComponent<MouseLook>().enabled = false;
        mainCamera.GetComponent<MouseLook>().enabled = false;
    }
}
