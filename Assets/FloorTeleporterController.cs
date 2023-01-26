using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorTeleporterController : MonoBehaviour
{
    public GameObject toReplicate;

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.eulerAngles = new Vector3(toReplicate.transform.eulerAngles.x,
            toReplicate.transform.eulerAngles.y - 180, 
            toReplicate.transform.eulerAngles.z);
    }
}
