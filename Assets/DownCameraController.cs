using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DownCameraController : MonoBehaviour
{

    public GameObject mainCamera;
    public float difference;

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = new Vector3(mainCamera.transform.position.x, mainCamera.transform.position.y + difference, mainCamera.transform.position.z);
    }
}
