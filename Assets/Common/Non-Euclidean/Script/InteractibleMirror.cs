using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface InteractibleObject
{
    public void OnInteraction();
}

public class InteractibleMirror : MonoBehaviour, InteractibleObject
{
    public Camera mirrorCamera;
    public ShadowStep shadow;
    public Vector3 shadowPosition;
    public Quaternion shadowRotation;

    public void OnInteraction()
    {
        StartCoroutine(StartJumpscare());
        StartCoroutine(MakeJumpscareDisappear());
    }

    public IEnumerator StartJumpscare()
    {
        yield return new WaitForSeconds(6.3f);
        shadow.MoveShadow(shadowPosition, shadowRotation);
        shadow.PlayGlitchSound();
    }
    public IEnumerator MakeJumpscareDisappear()
    {
        yield return new WaitForSeconds(7.4f);
        shadow.MoveShadow(new Vector3(100,100,100), new Quaternion());
        shadow.StopGlitchSound();
    }
}
