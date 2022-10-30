using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenCloseController : MonoBehaviour
{

    public float speed;

    public GameObject door;
    public GameObject otherDoor;

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            Animator anim = door.GetComponentInChildren<Animator>();
            Animator otherAnim = otherDoor != null ? otherDoor.GetComponentInChildren<Animator>() : null;
            if (Input.GetKeyDown(KeyCode.F))
            {
                anim.SetFloat("Speed", speed);
                anim.SetTrigger("OpenClose");
                if (otherAnim != null)
                {
                    otherAnim.SetFloat("Speed", speed);
                    otherAnim.SetTrigger("OpenClose");
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Animator anim = door.GetComponentInChildren<Animator>();
            Animator otherAnim = otherDoor != null ? otherDoor.GetComponentInChildren<Animator>() : null;
            if (this.tag == "Teleport")
            {
                anim.SetFloat("Speed", speed);
                anim.SetTrigger("OpenClose");
                if (otherAnim != null)
                {
                    otherAnim.SetFloat("Speed", speed);
                    otherAnim.SetTrigger("OpenClose");
                }
            }
        }
    }
}
