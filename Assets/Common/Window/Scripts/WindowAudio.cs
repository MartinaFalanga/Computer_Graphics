using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowAudio : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "DoorLock")
        {
            int randomClipNumber = Random.Range(1, 3);
            string clipName = "openDoor" + randomClipNumber;
            FindObjectOfType<AudioManager>().Play(clipName);
        }
    }

}
