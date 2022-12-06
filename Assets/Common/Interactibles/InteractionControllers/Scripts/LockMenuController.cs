using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockMenuController : MonoBehaviour
{

    public LockType lockType;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Dismiss();
        }
    }

    public void Dismiss() {
        transform.parent.gameObject.GetComponent<MenusController>().DismissAll();
    }
}
