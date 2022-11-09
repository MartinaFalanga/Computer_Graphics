/*using System.Collections;
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
        if(light != null) {
            light.GetComponent<Light>().enabled = true;
        }
        lamp.GetComponent<MeshRenderer>().material.EnableKeyword("_EMISSION");
        timeDelay = Random.Range(0.01f, 1.5f);
        yield return new WaitForSeconds(timeDelay);

        if (light != null)
        {
            light.GetComponent<Light>().enabled = false;
        }
        lamp.GetComponent<MeshRenderer>().material.DisableKeyword("_EMISSION");
        timeDelay = Random.Range(0.01f, 1.5f);
        yield return new WaitForSeconds(timeDelay);
        isFlickering = true;
    }

}*/




using UnityEngine;
using System.Collections.Generic;
using System.Collections;

// Written by Steve Streeting 2017
// License: CC0 Public Domain http://creativecommons.org/publicdomain/zero/1.0/

/// <summary>
/// Component which will flicker a linked light while active by changing its
/// intensity between the min and max values given. The flickering can be
/// sharp or smoothed depending on the value of the smoothing parameter.
///
/// Just activate / deactivate this component as usual to pause / resume flicker
/// </summary>
public class FlashingLightController : MonoBehaviour
{
    [Tooltip("External light to flicker; you can leave this null if you attach script to a light")]
    public new Light light;
    [Tooltip("External light to flicker; you can leave this null if you attach script to a light")]
    public new GameObject lamp;
    [Tooltip("Minimum random light intensity")]
    public float minIntensity = 0f;
    [Tooltip("Maximum random light intensity")]
    public float maxIntensity = 1f;
    [Tooltip("How much to smooth out the randomness; lower values = sparks, higher = lantern")]
    [Range(1, 50)]
    public int smoothing = 5;

    // Continuous average calculation via FIFO queue
    // Saves us iterating every time we update, we just change by the delta
    Queue<float> smoothQueue;
    float lastSum = 0;
    private Vector3 originalColor;
    private Material lampMaterial;
    private AudioSource audio;
    private float originalVolume;
    private bool isFlickering;


    /// <summary>
    /// Reset the randomness and start again. You usually don't need to call
    /// this, deactivating/reactivating is usually fine but if you want a strict
    /// restart you can do.
    /// </summary>
    public void Reset()
    {
        smoothQueue.Clear();
        lastSum = 0;
    }

    void Start()
    {
        Debug.Log("Lampada: " + lamp);
        Component[] components = lamp.GetComponents(typeof(Component));
        foreach (Component component in components)
        {
            Debug.Log(component.ToString());
        }
        smoothQueue = new Queue<float>(smoothing);
        // External or internal light?
        if (light == null)
        {
            light = GetComponent<Light>();
        }
        if(lamp != null)
        {
            lampMaterial = lamp.GetComponent<MeshRenderer>().material;
            originalColor = lampMaterial.GetVector("_EmissionColor");
        }
        audio = lamp.GetComponent<AudioSource>();
        originalVolume = audio.volume;
        audio.Play();
    }

    void Update()
    {
        StartCoroutine(FlickeringLight());
    }


    IEnumerator FlickeringLight()
    {
        if (light != null || lamp != null)
        {
            isFlickering = false;

            // pop off an item if too big
            while (smoothQueue.Count >= smoothing)
            {
                lastSum -= smoothQueue.Dequeue();
            }

            // Generate random new item, calculate new average
            float newVal = Random.Range(minIntensity, maxIntensity);
            smoothQueue.Enqueue(newVal);
            lastSum += newVal;

            // Calculate new smoothed average
            if (light != null)
            {
                light.intensity = lastSum / (float)smoothQueue.Count;
            }
            if (lampMaterial != null)
            {
                lampMaterial.SetVector("_EmissionColor", originalColor * newVal);

                audio.volume = originalVolume * newVal;
            }
            yield return new WaitForSeconds(Random.Range(0.3f, 1.0f));
            isFlickering = true;
        }
    }

}
