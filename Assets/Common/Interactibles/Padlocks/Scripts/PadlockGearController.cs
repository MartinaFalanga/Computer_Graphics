using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PadlockGearController : MonoBehaviour
{
    
    public int value = 0;
    [SerializeField] private Animator animator;

    public GameObject gear;

    // Start is called before the first frame update
    void Start()
    {
        if(value < 0 || value > 9)
            Debug.Log("Error: value must be in [0,9]");
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseDown() {
        value = (value + 1) % 10;
        Debug.Log("Clicked numeric padlock to value="+value);
        animator.Play("GearRotation" + value, 0,0.0f);

        GetComponent<AudioSource>().Play();

        GameObject parent = gear.transform.parent.gameObject;
        parent.GetComponent<CombinationThreePadlockController>().checkUnlockAndUnlock();
    }

}
