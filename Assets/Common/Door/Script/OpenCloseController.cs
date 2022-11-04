using System.Collections;
using UnityEngine;

public class OpenCloseController : MonoBehaviour
{

    public float speed = 1;

    public DoorType doorType;
    public GameObject otherDoorCollider;
    public bool isOpen = false;
    [SerializeField] private bool pauseInteraction = false;

    private IEnumerator OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            Animator anim = this.GetComponentInParent<Animator>();
            Animator otherAnim = otherDoorCollider != null ? otherDoorCollider.GetComponentInParent<Animator>() : null;
            if (Input.GetKeyDown(KeyCode.F) && !pauseInteraction)
            {
                isOpen = !isOpen;
                pauseInteraction = true;
                anim.SetFloat("Speed", speed);
                anim.SetTrigger("OpenClose");
                if (otherAnim != null)
                {
                    otherAnim.SetFloat("Speed", speed);
                    otherAnim.SetTrigger("OpenClose");
                }

                string clipName;
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
                    case DoorType.Cabinet:
                        clipName = isOpen ? "openCabinet" : "closeCabinet";
                        FindObjectOfType<AudioManager>().PlayDelayed(clipName, isOpen ? 0 : .9f / speed);
                        break;
                    default: break;
                }
                
                yield return new WaitForSeconds(1 / speed);
                pauseInteraction = false;
            }
        }
    }
}
