using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockMenuController : MonoBehaviour
{

    public LockType lockType;

    public void Dismiss() {
        transform.parent.gameObject.GetComponent<MenusController>().DismissAll();
    }
}
