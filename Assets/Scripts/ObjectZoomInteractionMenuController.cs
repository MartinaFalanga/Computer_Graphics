using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectZoomInteractionMenuController : MonoBehaviour
{

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Q))
        {
            Debug.Log("Dismissing menu");
            gameObject.SetActive(false);
            GameObject.Find("First Person Controller").GetComponent<CharacterMotor>().canControl = true;
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
    }


}
