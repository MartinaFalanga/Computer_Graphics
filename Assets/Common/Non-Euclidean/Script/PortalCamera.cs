using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalCamera : MonoBehaviour
{
    public Transform playerCamera;
    public bool isMirror = false;
    public bool isInverted = false;
    public Transform portal;
    public Transform otherPortal;

    // Update is called once per frame
    void LateUpdate()
    {
        if (!isMirror)
        {
            Vector3 playerOffsetFromPortal = playerCamera.position - otherPortal.position;
            if (isInverted)
            {
                playerOffsetFromPortal = new Vector3((-1)*playerOffsetFromPortal.x, playerOffsetFromPortal.y, (-1)*playerOffsetFromPortal.z);
            }
            transform.position = portal.position + playerOffsetFromPortal;
        }
        float angularDifferenceBetweenPortalRotations = Quaternion.Angle(portal.rotation, otherPortal.rotation);

        Quaternion portalRotationalDifference = Quaternion.AngleAxis(angularDifferenceBetweenPortalRotations, Vector3.up);
        Vector3 newCameraDirection = portalRotationalDifference * playerCamera.forward;
        transform.rotation = Quaternion.LookRotation(newCameraDirection, Vector3.up);
        if (isMirror)
        {
            transform.Rotate(0, 180, 0);
        }
    }
}
