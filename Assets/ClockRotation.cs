using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockRotation : MonoBehaviour
{
    private const float REAL_SECONDS_PER_INGAME_DAY = 60f;
    private Transform clockHourHandTransform;
    private Transform clockMinuteHandTransform;
    private float day;
    [HideInInspector] public float dayNormalized;
    private bool isTimeChanging = false;
    [SerializeField] float timeChangeSeconds;
    private float currentTimeChangeSeconds = 0;
    private float timeAtStartAnim;

    private void Awake()
    {
        clockHourHandTransform = transform.Find("Short_pivot");
        clockMinuteHandTransform = transform.Find("Long_pivot");

    }

    private void Update()
    {
        //    day += Time.deltaTime / REAL_SECONDS_PER_INGAME_DAY;
        PlayerInputClock();
        dayNormalized = day % 1f;
        float rotationDegreesPerDay = 720f;
        clockHourHandTransform.localEulerAngles = new Vector3(0, 0, dayNormalized * rotationDegreesPerDay);
        float hoursPerDay = 12f;
        clockMinuteHandTransform.localEulerAngles = new Vector3(0, 0, dayNormalized * rotationDegreesPerDay * hoursPerDay);
    }

    private void PlayerInputClock ()
    {
        if (Input.GetKeyDown(KeyCode.G) && !isTimeChanging && GetComponent<InteractiveObjectController>().isPlayerInInteractionCollider) 
        {
            timeAtStartAnim = day;
            currentTimeChangeSeconds = 0;
            isTimeChanging = true;
            
        }

        if (isTimeChanging)
        {
            currentTimeChangeSeconds += Time.deltaTime;
            currentTimeChangeSeconds = Mathf.Clamp(currentTimeChangeSeconds, 0f, timeChangeSeconds);
            day = timeAtStartAnim + currentTimeChangeSeconds / timeChangeSeconds / 24f;
            if (currentTimeChangeSeconds >= timeChangeSeconds)
            {
                isTimeChanging = false;
            }

        }
    }
}
