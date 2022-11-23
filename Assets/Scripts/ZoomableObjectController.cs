using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/** script per impostazioni angolo e scale dell'oggetto da mostrare a schermo quando l'utente vuole interagire con esso */
public class ZoomableObjectController : MonoBehaviour, IInteractiveObject
{
    public Vector3 position;
    public Vector3 angle;
    public Vector3 scale;

    public float menuLightIntensity;

    /** passare il game object ObjectZoomInteractionMenu che trovi nel menu a sinistra */
    public GameObject zoomableObjectMenu;

    public void ExecuteLogic() {
        Debug.Log("ZoomableObjectController - ExecuteLogic");
        
        zoomableObjectMenu.SetActive(true);
        zoomableObjectMenu.GetComponent<ObjectZoomInteractionMenuController>().showObject(gameObject);
    }
    
}
