using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashingLightController : MonoBehaviour
{
    public Light light;
    public GameObject lamp;
    public bool isFlickering = true;
    public float timeDelay;

    // Update is called once per frame
    void Update()
    {
        if (isFlickering == true)
        {
            StartCoroutine(FlickeringLight());
        }
    }

    IEnumerator FlickeringLight()
    {
        isFlickering = false;
        light.GetComponent<Light>().enabled = true;
        lamp.GetComponent<MeshRenderer>().material.EnableKeyword("_EMISSION");
        timeDelay = Random.Range(0.01f, 1.5f);
        yield return new WaitForSeconds(timeDelay);

        light.GetComponent<Light>().enabled = false;
        lamp.GetComponent<MeshRenderer>().material.DisableKeyword("_EMISSION");
        timeDelay = Random.Range(0.01f, 1.5f);
        yield return new WaitForSeconds(timeDelay);
        isFlickering = true;
    }
}
