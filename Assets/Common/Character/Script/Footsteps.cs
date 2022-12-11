using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Footsteps : MonoBehaviour
{

    public AudioSource footstepSource;

    private bool isFootstepPlaying;

    private const int NSTEPS = 22;
    private float[] stepCompleteSort = {0f, 0.538f, 1.098f, 1.626f, 2.208f, 2.757f, 3.317f, 3.811f, 4.383f, 4.943f,
                                    5.536f, 5.986f, 6.448f, 7.085f, 7.667f, 8.249f, 8.776f, 9.259f, 9.863f,
                                    10.380f, 11.017f, 11.577f, 12.148f};
    private int currentStep = 0;

    public GameObject camera;

    public GameObject phone;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow)) {
            isFootstepPlaying = true;

            if(footstepSource.time > stepCompleteSort[currentStep]) {
                currentStep = (currentStep + 1) % NSTEPS;
            }
            StartBobbing();
        } else {
            if(footstepSource.time > stepCompleteSort[currentStep]) {
                isFootstepPlaying = false;
                currentStep = 0;
            }
            StopBobbing();
        }
        
        footstepSource.enabled = isFootstepPlaying;
    }

    // private methods

    private void StartBobbing() {
        camera.GetComponent<Animator>().Play("HeadBobbing");
        phone.GetComponent<Animator>().Play("PhoneShaking");
    }

    private void StopBobbing() {
        camera.GetComponent<Animator>().Play("New State");
        phone.GetComponent<Animator>().Play("New State");
    }


}
