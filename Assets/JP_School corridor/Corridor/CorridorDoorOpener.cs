using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorridorDoorOpener : MonoBehaviour
{

    public GameObject doorLeft;
    [SerializeField] private Animator animatorLeft;

    public GameObject doorRight;
    [SerializeField] private Animator animatorRight;


    private bool hasEnter = false;
    private bool doorsOpened = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (hasEnter)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                Debug.Log("Pressed F Key");
                openCloseDoors();
            }
        }
    }

    void OnMouseEnter()
    {
        Debug.Log("Mouse is entered Door. Preff F to open doors");
        hasEnter = true;
        showInteractionMenu();
    }

    void OnMouseExit()
    {
        Debug.Log("Mouse is out Door. No actions can be performed");
        hasEnter = false;
    }

    /* PRIVATE METHODS **/

    private void showInteractionMenu()
    {
        Debug.Log("Press F to open doors");
    }

    private void openCloseDoors()
    {
        if(doorsOpened) // then close the doors
        {
            animatorLeft.Play("CloseDoorLeft", 0,0.0f);
            animatorRight.Play("CloseDoorRight", 0, 0.0f);
        } else // open the doors
        {
            animatorLeft.Play("OpenDoorLeft", 0, 0.0f);
            animatorRight.Play("OpenDoorRight", 0, 0.0f);
        }
        doorsOpened = !doorsOpened;
    }

}
