using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;

public class DayNightCycle : MonoBehaviour
{
    [SerializeField] public GameObject DirectionalLight;
    Light DirectonalLightLight;
    [SerializeField] ClockRotation clockRotation;
    public MeshRenderer text;


    private void Start()
    {
       // DirectionalLight = GetComponent<Light>();
        DirectonalLightLight = DirectionalLight.GetComponent<Light>();

    }

    // Update is called once per frame
    void Update()
    {
        float minHours = (1f / 24f) * 13f;
        float maxHours = (1f / 24f) * 18f;
        float minRotation = 159.7f;
        float maxRotation = 182.2f;
        float mezzogiorno1 = 159.7f;
        float mezzogiorno2 = 164.2f;
        float una1 = 164.3f;
        float una2 = 168.7f;
        float due1 = 168.8f;
        float due2 = 173.2f;
        float tre1 = 173.3f;
        float tre2 = 177.7f;
        float quattro1 = 177.8f;
        float quattro2 = 182.1f;

        if (clockRotation.dayNormalized>minHours && clockRotation.dayNormalized < maxHours)
        {
            float t = (clockRotation.dayNormalized - minHours) / (maxHours - minHours);
            transform.eulerAngles = new Vector3(Mathf.Lerp(minRotation, maxRotation, t),0,0);
            DirectonalLightLight.intensity = 1;
            Debug.Log("Value x rotation:" + DirectionalLight.transform.eulerAngles.x); //Restituisce valori diversi da quelli attesi!
            if (DirectionalLight.transform.rotation.x >= mezzogiorno1 && DirectionalLight.transform.rotation.x <= mezzogiorno2)
            {
                text.material.color = new Color(255f, 0f, 0f, 255f);
            }
            else if (DirectionalLight.transform.rotation.x >= una1 && DirectionalLight.transform.rotation.x <= una2)
            {
                text.material.color = new Color(255f, 0f, 0f, 200f);
            }
            else if (DirectionalLight.transform.rotation.x >= due1 && DirectionalLight.transform.rotation.x <= due2)
            {
                text.material.color = new Color(255f, 0f, 0f, 150f);
            }
            else if (DirectionalLight.transform.rotation.x >= tre1 && DirectionalLight.transform.rotation.x <= tre2)
            {
                text.material.color = new Color(255f, 0f, 0f, 100f);
            }
            else if (DirectionalLight.transform.rotation.x >= quattro1 && DirectionalLight.transform.rotation.x <= quattro2)
            {
                text.material.color = new Color(255f, 0f, 0f, 70f);
            }
        }
        else
        {
            DirectonalLightLight.intensity = 0;
            text.material.color = new Color(255f, 0f, 0f, 0f);
        }

    }

}
