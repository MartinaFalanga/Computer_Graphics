using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTeleport : MonoBehaviour
{

    public float speed = 1;
    public Animator firstAnimator;
    public Animator copyAnimator;
    public AudioSource hardCloseDoorAudioSource;
    public AudioSource tryOpenLockedDoorAudioSource;
    public ShadowStep shadow;
    public Vector3 shadowPosition;
    public Quaternion shadowRotation;

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
            hardCloseDoorAudioSource.PlayDelayed(.9f / speed);
            if(shadow != null)
            {
                StartCoroutine(StartShadowSteps());
                StartCoroutine(StartToTryOpenLockedDoor());
            }
        }
    }

    private IEnumerator StartShadowSteps()
    {
        shadow.PlaySteps();
        shadow.MoveShadow(shadowPosition, shadowRotation);
        yield return new WaitForSeconds(1.5f);
        shadow.StopSteps();
    }
    private IEnumerator StartToTryOpenLockedDoor()
    {
        yield return new WaitForSeconds(1.8f);
        tryOpenLockedDoorAudioSource.Play();
    }
}
