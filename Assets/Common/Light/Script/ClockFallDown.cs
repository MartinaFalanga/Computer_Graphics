using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockFallDown : MonoBehaviour
{
    public GameObject lootCreate;
    void Start()
    {

    }

    RaycastHit hit;
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Transform cam = Camera.main.transform;
            if (Physics.Raycast(cam.position, cam.forward, out hit, Mathf.Infinity, ~0))
            {
                GameObject obj = Instantiate(lootCreate);
                obj.transform.localEulerAngles = new Vector3(Random.Range(0, 360), Random.Range(0, 360), 0);
                Vector3 pos = hit.point;
                pos.y = 10.0f;
                obj.transform.position = pos;
            }
        }
    }
}
