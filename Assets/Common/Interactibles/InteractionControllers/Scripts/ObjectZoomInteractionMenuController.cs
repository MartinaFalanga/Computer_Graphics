using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectZoomInteractionMenuController : MonoBehaviour, ISingleMenuController
{

    public GameObject menuObjectContainer;

    public GameObject menuLight;


    void Update()
    {

    }

    public void showObject(GameObject go)
    {
        Debug.Log("Showing object in menu");
        GameObject goClone = Instantiate(go);
        goClone.transform.SetParent(gameObject.transform.GetChild(0));

        goClone.transform.localPosition = go.GetComponent<ZoomableObject>().position;
        goClone.transform.localScale = go.GetComponent<ZoomableObject>().scale;
        goClone.transform.eulerAngles = go.GetComponent<ZoomableObject>().angle;

        int layer = LayerMask.NameToLayer("UI");

        goClone.layer = layer;


        SetGameLayerRecursive(goClone, layer);

        menuLight.GetComponent<Light>().intensity = go.GetComponent<ZoomableObject>().menuLightIntensity;
        menuLight.GetComponent<Light>().range = go.GetComponent<ZoomableObject>().menuLightRange;
    }


    public void OnDismissMenu()
    {
        Debug.Log("Destroying menu children");
        DestroyChildren();
    }

    // private methods

    private void DestroyChildren()
    {
        for (var i = menuObjectContainer.transform.childCount - 1; i >= 0; i--)
        {
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