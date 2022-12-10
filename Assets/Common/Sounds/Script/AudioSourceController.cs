using System.Collections;
using UnityEngine;

public class AudioSourceController : MonoBehaviour
{
    public float minDelay = 10f;
    public float maxDelay = 24f;
    private bool inPause = false;
    void Update()
    {
        if (!inPause)
        {
            StartCoroutine(PlayClip());
        }
    }

    IEnumerator PlayClip()
    {
        inPause = true;
        yield return new WaitForSeconds(Random.Range(minDelay, maxDelay));
        GetComponent<AudioSource>().Play();
        inPause = false;
    }
}
