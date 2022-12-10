using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveRadioController : MonoBehaviour, IInteractiveObject
{

    public void ExecuteLogic() {
        PlaySound();
    }

    private void PlaySound() {
        GetComponent<AudioSource>().Play();
    }
    
}
