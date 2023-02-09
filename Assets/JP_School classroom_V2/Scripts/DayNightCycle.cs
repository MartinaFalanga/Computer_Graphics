using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;

public class DayNightCycle : MonoBehaviour
{
    private GameObject DirectionalLight;
    Light DirectonalLightLight;
    [SerializeField] ClockRotation clockRotation;
    public MeshRenderer text;
    public GameObject exitDoorCollider;



    private void Start()
    {
        DirectionalLight = gameObject;
        DirectonalLightLight = GetComponent<Light>();

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 rot = new Vector3(
            (360 - (gameObject.transform.localRotation.eulerAngles.x - 180)) % 360,
            (gameObject.transform.localRotation.eulerAngles.y - 180) % 360, 
            (gameObject.transform.localRotation.eulerAngles.z - 180) % 360);


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
            if (rot.x >= mezzogiorno1 && rot.x <= mezzogiorno2)
            { 
                text.material.color = new Color(255f/255f, 0f, 0f, 255f/255f);
                exitDoorCollider.SetActive(true);
            }
            else if (rot.x >= una1 && rot.x <= una2)
            {
                text.material.color = new Color(255f/255f, 0f, 0f, 200f/255f);
                exitDoorCollider.SetActive(true);
            }
            else if (rot.x >= due1 && rot.x <= due2)
            {
                text.material.color = new Color(255f/255f, 0f, 0f, 150f/255f);
                exitDoorCollider.SetActive(true);
            }
            else if (rot.x >= tre1 && rot.x <= tre2)
            {
                text.material.color = new Color(255f/255f, 0f, 0f, 100f/255f);
                exitDoorCollider.SetActive(true);
            }
            else if (rot.x >= quattro1 && rot.x <= quattro2)
            {
                text.material.color = new Color(255f/255f, 0f, 0f, 70f/255f);
                exitDoorCollider.SetActive(true);
            }
        }
        else
        {
            DirectonalLightLight.intensity = 0;
            text.material.color = new Color(255f / 255f, 0f, 0f, 0f);
        }

    }

}
