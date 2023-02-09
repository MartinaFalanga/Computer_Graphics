using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/** script per impostazioni angolo e scale dell'oggetto da mostrare a schermo quando l'utente vuole interagire con esso */
public class ZoomableObject : MonoBehaviour, IInteractiveObject
{
    public Vector3 position;
    public Vector3 angle;
    public Vector3 scale;

    public float menuLightIntensity;
    public float menuLightRange;

    /** passare il game object ObjectZoomInteractionMenu che trovi nel menu a sinistra */
    public GameObject zoomableObjectMenu;

    public void ExecuteLogic() {
        Debug.Log("ZoomableObject - ExecuteLogic");

        deletePreExistingObject();
        
        zoomableObjectMenu.SetActive(true);
        zoomableObjectMenu.GetComponent<ObjectZoomInteractionMenuController>().showObject(gameObject);
            
    }

    private void deletePreExistingObject()
    {
        if(zoomableObjectMenu.transform.Find("Object").transform.childCount > 0)
            Destroy(zoomableObjectMenu.transform.Find("Object").transform.GetChild(0).gameObject);
    }

}
