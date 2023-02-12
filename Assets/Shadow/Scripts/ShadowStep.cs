using UnityEngine;

public class ShadowStep : MonoBehaviour
{
    public AudioSource stepsSound;
    public AudioSource glitchSound;
    public void MoveShadow(Vector3 position, Quaternion rotation)
    {
        transform.position = position;
        transform.rotation = rotation;
    }

    public void PlaySteps()
    {
        stepsSound.Play();
    }

    public void StopSteps()
    {
        stepsSound.Stop();
    }

    public void PlayGlitchSound()
    {
        glitchSound.Play();
    }

    public void StopGlitchSound()
    {
        glitchSound.Stop();
    }
}
