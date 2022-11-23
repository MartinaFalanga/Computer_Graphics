using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenusController : MonoBehaviour
{
    
    public void DismissAll() {
        DismissMenus();
        UnlockPlayer();
    }

    // private methods    
    private void DismissMenus() {
        for (var i = gameObject.transform.childCount - 1; i >= 0; i--) {
            gameObject.transform.GetChild(i).gameObject.SetActive(false);
        }
    }

    private void UnlockPlayer() {
        GameObject player = GameObject.Find("First Person Controller").gameObject;
        GameObject mainCamera = GameObject.Find("Main Camera").gameObject;

        player.GetComponent<CharacterMotor>().enabled = true;
        player.GetComponent<CharacterMotor>().canControl = true;
        player.GetComponent<MouseLook>().enabled = true;
        mainCamera.GetComponent<MouseLook>().enabled = true;
    }

}
