using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightCycle : MonoBehaviour
{
 //   Vector3 rot=Vector3.zero;
 //   float degpersec = 25;
    [SerializeField] Light DirectionalLight;
    [SerializeField] ClockRotation clockRotation;
 //   [SerializeField] float intensityMultiplier;

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

        }
        else
        {
            DirectionalLight.intensity = 0;
        }
        //rot.x = (clockRotation.dayNormalized * 360f);
        //if (rot.x > 150f && rot.x < 190f)
        //{
        //   float distFromMax = 1f-Mathf.Abs(170f - rot.x)/40f;
        //    Debug.Log(rot.x);
        //    Debug.Log(distFromMax);
        //    DirectionalLight.intensity = distFromMax*intensityMultiplier;
            
        //    transform.eulerAngles = rot;
        //}
        //else
        //{
        //    DirectionalLight.intensity = 0;
        //}
    }
}
