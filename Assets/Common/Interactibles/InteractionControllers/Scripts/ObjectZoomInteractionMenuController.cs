using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectZoomInteractionMenuController : MonoBehaviour
{

    public GameObject menuObjectContainer;

    public GameObject menuLight;

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Q))
        {
            Debug.Log("Destroying children");
            DestroyChildren();
            transform.parent.gameObject.GetComponent<MenusController>().DismissAll();
        }
    }
    
    public void showObject(GameObject go) {
        Debug.Log("Showing object in menu");
        GameObject goClone = Instantiate(go);
        goClone.transform.SetParent(gameObject.transform.GetChild(0));

        goClone.transform.localPosition = go.GetComponent<ZoomableObjectController>().position;
        goClone.transform.localScale = go.GetComponent<ZoomableObjectController>().scale;
        goClone.transform.eulerAngles = go.GetComponent<ZoomableObjectController>().angle;
        goClone.layer=12;
        
        SetGameLayerRecursive(goClone,12);

        menuLight.GetComponent<Light>().intensity = go.GetComponent<ZoomableObjectController>().menuLightIntensity;
    }

    // private methods
    
    private void DestroyChildren() {
        for (var i = menuObjectContainer.transform.childCount - 1; i >= 0; i--) {
            Destroy(menuObjectContainer.transform.GetChild(i).gameObject);
        }
    }

    private void SetGameLayerRecursive(GameObject _go, int _layer)
    {
        _go.layer = _layer;
        foreach (Transform child in _go.transform)
        {
            child.gameObject.layer = _layer;

            Transform _HasChildren = child.GetComponentInChildren<Transform>();
            if (_HasChildren != null)
                SetGameLayerRecursive(child.gameObject, _layer);
            
        }
    }


}
