using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenusController : MonoBehaviour
{

    public GameObject firstPersonController;
    public GameObject mainCamera;
    public GameObject uiCamera;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            DismissAll();
        }
    }

    
    public void DismissAll()
    {
        Debug.Log("Dismissing all menus");

        uiCamera.SetActive(false);
        DismissMenus();
        UnlockPlayer();
    }

    // private methods

    private void DismissMenus()
    {
        for (var i = gameObject.transform.childCount - 1; i >= 0; i--) {
            gameObject.transform.GetChild(i).gameObject.SetActive(false);
        }
    }

    private void UnlockPlayer() {
        firstPersonController.GetComponent<CharacterMotor>().enabled = true;
        firstPersonController.GetComponent<CharacterMotor>().canControl = true;
        firstPersonController.GetComponent<MouseLook>().enabled = true;
        mainCamera.GetComponent<MouseLook>().enabled = true;
    }

}
