using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class MenusController : MonoBehaviour
{

    public GameObject firstPersonController;
    public GameObject mainCamera;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            DismissAll();
        }
    }

    
    public void DismissAll()
    {
        DismissMenus();
        UnlockPlayer();
        mainCamera.GetComponent<Camera>().depth = 2;
    }

    // private methods

    private void DismissMenus()
    {
        foreach(GameObject menu in GameObject.FindGameObjectsWithTag("Menu")){
            menu.SetActive(false);
        }
    }

    public void UnlockPlayer() {
        firstPersonController.GetComponent<CharacterMotor>().enabled = true;
        firstPersonController.GetComponent<CharacterMotor>().canControl = true;
        firstPersonController.GetComponent<MouseLook>().enabled = true;
        CursorManager.instance.UpdateCursor(false);
    }

}
