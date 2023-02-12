using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorManager : MonoBehaviour
{

    public bool isLockedToTheCenter;
    public static CursorManager instance;
    public AudioSource clickSound;
    public Camera mainCamera;
    public MouseLook playerLook;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        Cursor.lockState = CursorLockMode.Locked;
        isLockedToTheCenter = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl) || Input.GetKeyDown(KeyCode.RightControl))
        {
            UpdateCursor(isLockedToTheCenter);
        }
    }

    public void UpdateCursor(bool isLocked)
    {
        Debug.Log("IsLocked: " + isLocked);
        if (!isLocked) {
            mainCamera.GetComponent<MouseLook>().enabled = true;
            playerLook.enabled = true;
            Cursor.lockState = CursorLockMode.Locked;
        }
        else {
            mainCamera.GetComponent<MouseLook>().enabled = false;
            playerLook.enabled = false;
            Cursor.lockState = CursorLockMode.None;
        }
        isLockedToTheCenter = !isLocked;
    }
}
