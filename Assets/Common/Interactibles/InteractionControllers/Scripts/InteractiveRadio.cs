using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveRadio : MonoBehaviour, IInteractiveObject
{

    public void ExecuteLogic() {
        PlaySound();
    }

    private void PlaySound() {
        GetComponent<AudioSource>().Play();
    }
    
}
