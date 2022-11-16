using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatchableObjectsController : MonoBehaviour
{

    public bool isLocked = true;

    public void unLock() {
        this.isLocked = false;
    }
}
