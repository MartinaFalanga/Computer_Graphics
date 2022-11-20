using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/** script per impostazioni angolo e scale dell'oggetto da mostrare a schermo quando l'utente vuole interagire con esso */
public class ZoomableObjectController : MonoBehaviour
{
    public Vector3 position;
    public Vector3 angle;
    public Vector3 scale;

    /** passare il game object ObjectZoomInteractionMenu che trovi nel menu a sinistra */
    public GameObject zoomableObjectMenu;

    private IEnumerator OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("ZoomableObjectController - player entered collision");
            if (Input.GetKeyDown(KeyCode.F))
            {
                Debug.Log("ZoomableObjectController - F pressed");
                zoomableObjectMenu.SetActive(true);
                zoomableObjectMenu.GetComponent<ObjectZoomInteractionMenuController>().showObject(gameObject);
                yield return new WaitForSeconds(1);
            }
        }
    }
}
