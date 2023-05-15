using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestInterration : MonoBehaviour
{
    public GameObject doorClosed;
    public GameObject doorOpened;
    public GameObject buttonOff;
    public GameObject buttonOn;
    public AudioSource audioClip1;
    public AudioSource audioClip2;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            buttonOff.SetActive(false);
            buttonOn.SetActive(true);
            doorClosed.SetActive(false);
            doorOpened.SetActive(true);
            audioClip1.Play();
            audioClip2.Play();
            Destroy(this);
        }
    }
}
