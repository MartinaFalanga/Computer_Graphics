using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{

    private void OnTriggerStay(Collider other)
    {
        Debug.Log(other);
        if (other.tag == "Player")
        {
            Animator anim = this.GetComponentInChildren<Animator>();
            Debug.Log(anim);
            if (Input.GetKeyDown(KeyCode.F))
            {
                anim.SetTrigger("OpenClose");
            }
        }
    }
}
