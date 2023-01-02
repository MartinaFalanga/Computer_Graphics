using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightCycle : MonoBehaviour
{
    [SerializeField] Light DirectionalLight;
    [SerializeField] ClockRotation clockRotation;
     public GameObject posterindizio;

    private void Start()
    {
        DirectionalLight = GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        float minHours = (1f / 24f) * 13f;
        float maxHours = (1f / 24f) * 18f;
        float minRotation = 159.7f;
        float maxRotation = 182.2f;
        
        if(clockRotation.dayNormalized>minHours && clockRotation.dayNormalized < maxHours)
        {
            float t = (clockRotation.dayNormalized - minHours) / (maxHours - minHours);
            transform.eulerAngles = new Vector3(Mathf.Lerp(minRotation, maxRotation, t),0,0);
            DirectionalLight.intensity = 1;
            posterindizio.SetActive(true);
        }
        else
        {
            DirectionalLight.intensity = 0;
        }

       

    }
}
