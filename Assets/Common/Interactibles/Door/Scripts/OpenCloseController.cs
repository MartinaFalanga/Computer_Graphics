using System.Collections;
using UnityEngine;

public class OpenCloseController : MonoBehaviour, IInteractiveObject
{

    public float speed = 1;
    public DoorType doorType;
    public GameObject otherDoorController;
    public bool isOpen = false;
    public bool isLocked = false;
    public bool isInverse = false;

    private Animator anim;
    private Animator otherAnim;

    void Start()
    {
        anim = this.GetComponentInParent<Animator>();
        otherAnim = otherDoorController != null ? otherDoorController.GetComponentInParent<Animator>() : null;
    }

    public void ExecuteLogic()
    {

        if (isLocked)
        {
            FindObjectOfType<AudioManager>().Play("lockDoor");
            showPadlock();
        }
        else
        {
            openClose();
        }

        new WaitForSeconds(1 / speed);
    }

    public void unLock()
    {
        this.isLocked = false;
        openClose();
    }

    /** private methods */

    private void openClose()
    {
        isOpen = !isOpen;
        string clipName;
        anim.SetFloat("Speed", speed);
        anim.SetTrigger("OpenClose");
        anim.SetBool("IsInverse", isInverse);
        if (otherAnim != null)
        {
            otherAnim.SetFloat("Speed", speed);
            otherAnim.SetTrigger("OpenClose");
            otherAnim.SetBool("Inverse", isInverse);
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

        if (isOpen)
        {
            changeInteractionMenuText("Premi F per chiudere");
        }
        else
        {
            changeInteractionMenuText("Premi F per aprire");
        }
    }

    private void showPadlock()
    {
        gameObject.GetComponent<LockedDoor>().showPadlock();
    }

    private void changeInteractionMenuText(string text)
    {
        InteractiveObjectController ioc = gameObject.GetComponent<InteractiveObjectController>();
        if (ioc == null)
        {
            ioc = gameObject.GetComponentInParent<InteractiveObjectController>();
        }
        if (ioc != null)
        {
            ioc.interactionMenuText = text;
        }
    }

}