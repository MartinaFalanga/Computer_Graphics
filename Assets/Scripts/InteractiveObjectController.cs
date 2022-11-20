using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InteractiveObjectController : MonoBehaviour
{
    public GameObject interactionMenuCanvas;

    public GameObject interactionMenuTextmesh;

    public string interactionMenuText; // TODO

    // Start is called before the first frame update
    private IEnumerator OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            interactionMenuTextmesh.GetComponent<TextMeshProUGUI>().text = interactionMenuText;
            interactionMenuCanvas.SetActive(true);
        }
        yield return new WaitForSeconds(1);
    }

    private IEnumerator OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            interactionMenuCanvas.SetActive(false);
        }
        yield return new WaitForSeconds(1);
    }

    private IEnumerator OnTriggerStay(Collider other)
    {
        if (other.tag == "Player") {
            if (Input.GetKeyDown(KeyCode.F)) {
                interactionMenuCanvas.SetActive(false);
            }
        }
        yield return new WaitForSeconds(1);
    }
}
