using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombinationThreePadlockController : MonoBehaviour
{
    private GameObject lockedGameObject;

    private int firstNumUnlock;
    private int secondNumUnlock;
    private int thirdNumUnlock;


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Q))
        {
            Debug.Log("Dismissing menu");
            gameObject.transform.parent.gameObject.SetActive(false);
            GameObject.Find("First Person Controller").GetComponent<CharacterMotor>().canControl = true;
        }
    }

    public void checkUnlockAndUnlock() {
        GameObject firstGear = transform.Find("FirstGear").gameObject;
        GameObject secondGear = transform.Find("SecondGear").gameObject;
        GameObject thirdGear = transform.Find("ThirdGear").gameObject;

        int valueFirstGear = firstGear.GetComponent<PadlockGearController>().value;
        int valueSecondGear = secondGear.GetComponent<PadlockGearController>().value;
        int valueThirdGear = thirdGear.GetComponent<PadlockGearController>().value;

        if(valueFirstGear == firstNumUnlock && valueSecondGear == secondNumUnlock && valueThirdGear == thirdNumUnlock) {
            Debug.Log("Padlock unlocked");
            this.lockedGameObject.GetComponent<LockedDoor>().unLock();
        }
    }

    public void setActualGameObject(GameObject go) {
        this.lockedGameObject = go;
        this.firstNumUnlock = lockedGameObject.GetComponent<LockedDoor>().combination[0];
        this.secondNumUnlock = lockedGameObject.GetComponent<LockedDoor>().combination[1];
        this.thirdNumUnlock = lockedGameObject.GetComponent<LockedDoor>().combination[2];
    }

    /** private methods */


}
