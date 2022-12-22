using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorManager : MonoBehaviour
{

    public bool isLockedToTheCenter;
    public static CursorManager instance;

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
            ChangeCursor();
        }
    }

    public void UpdateCursor(bool isCursorToLock)
    {
        if (isCursorToLock) {
            Cursor.lockState = CursorLockMode.Locked;
        } else {
            Cursor.lockState = CursorLockMode.None;
        }
        isLockedToTheCenter = isCursorToLock;
    }

    public void ChangeCursor()
    {
        if (!isLockedToTheCenter)
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
        }
        isLockedToTheCenter = !isLockedToTheCenter;
    }
}
