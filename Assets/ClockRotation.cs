using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockRotation : MonoBehaviour
{
    private const float REAL_SECONDS_PER_INGAME_DAY = 60f;
    private Transform clockHourHandTransform;
    private Transform clockMinuteHandTransform;
    private float day;

    private void Awake()
    {
        clockHourHandTransform = transform.Find("Short_pivot");
        clockMinuteHandTransform = transform.Find("Long_pivot");

    }

    private void Update()
    {
        day += Time.deltaTime / REAL_SECONDS_PER_INGAME_DAY;
        float dayNormalized = day % 1f;
        float rotationDegreesPerDay = 360f;
        clockHourHandTransform.localEulerAngles = new Vector3(0, 0, dayNormalized * rotationDegreesPerDay);
        float hoursPerDay = 24f;
        clockMinuteHandTransform.localEulerAngles = new Vector3(0, 0, dayNormalized * rotationDegreesPerDay * hoursPerDay);
    }
}
