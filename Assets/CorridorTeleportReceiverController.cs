using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorridorTeleportReceiverController : MonoBehaviour
{
    public Transform playerTransform;

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x, playerTransform.position.y, playerTransform.position.z);
    }
}
