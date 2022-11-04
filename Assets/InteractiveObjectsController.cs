using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveObjectsController : MonoBehaviour
{

    public bool isLocked = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void unLock() {
        this.isLocked = false;
    }
}
