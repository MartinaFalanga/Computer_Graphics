using System.Collections;
using UnityEngine;

public class OpenCloseController : MonoBehaviour, IInteractiveObject
{

    public float speed = 1;
    public DoorType doorType;
    public GameObject otherDoorCollider;
    public bool isOpen = false;
    public bool isLocked = false;
    [SerializeField] private bool pauseInteraction = false;

    private Animator anim;
    private Animator otherAnim;

    void Start() {
        anim = this.GetComponentInParent<Animator>();
        otherAnim = otherDoorCollider != null ? otherDoorCollider.GetComponentInParent<Animator>() : null;
    }

    public void ExecuteLogic() {
        pauseInteraction = true;

        if(isLocked) {
            FindObjectOfType<AudioManager>().Play("lockDoor");
            showPadlock();
        } else {
            openClose();
        }

        new WaitForSeconds(1 / speed);
        pauseInteraction = false;
    }

    public void unLock() {
        this.isLocked = false;
        openClose();
    }

    /** private methods */

    private void openClose() {
        isOpen = !isOpen;
        
        string clipName;
        anim.SetFloat("Speed", speed);
        anim.SetTrigger("OpenClose");
        if (otherAnim != null)
        {
            otherAnim.SetFloat("Speed", speed);
            otherAnim.SetTrigger("OpenClose");
        }

        switch (doorType)
        {
            case DoorType.Door: 
                int randomClipNumber = Random.Range(1, 3);
                clipName = isOpen ? "openDoor" + randomClipNumber : "autoCloseDoor";
                FindObjectOfType<AudioManager>().PlayDelayed(clipName, isOpen ? 0 : .9f / speed);
                break;
            case DoorType.Window:
                FindObjectOfType<AudioManager>().PlayDelayed("openSliding", .2f / speed);
                break;
            case DoorType.Locker:
                clipName = isOpen ? "openLocker" : "closeLocker";
                FindObjectOfType<AudioManager>().PlayDelayed(clipName, isOpen ? 0 : .9f / speed);
                break;
            default: break;
        }

        if(isOpen) {
            changeInteractionMenuText("F: Close");
        } else {
            changeInteractionMenuText("F: Open");
        }
    }

    private void showPadlock() {
        gameObject.GetComponent<LockedDoorController>().showPadlock();
    }

    private void changeInteractionMenuText(string text) {
        gameObject.GetComponent<InteractiveObjectController>().interactionMenuText = text;
    }

}
