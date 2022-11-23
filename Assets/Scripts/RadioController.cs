using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadioController : MonoBehaviour
{
    
    private IEnumerator OnTriggerStay(Collider other) {
        if (other.tag == "Player") {
            if (Input.GetKeyDown(KeyCode.F)) {
                GetComponent<AudioSource>().Play();
            }
        }
        yield return new WaitForSeconds(1);
    }
}
