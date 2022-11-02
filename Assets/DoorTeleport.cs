using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTeleport : MonoBehaviour
{

    public float speed = 1;
    public Animator firstAnimator;
    public Animator copyAnimator;
    private static readonly string HARD_CLOSE_DOOR = "hardCloseDoor";

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            firstAnimator.SetFloat("Speed", speed);
            firstAnimator.SetTrigger("OpenClose");
            if (copyAnimator != null)
            {
                copyAnimator.SetFloat("Speed", speed);
                copyAnimator.SetTrigger("OpenClose");
            }
            FindObjectOfType<AudioManager>().PlayDelayed(HARD_CLOSE_DOOR, .9f / speed);
            
        }
    }
}
