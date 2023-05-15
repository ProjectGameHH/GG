using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    public GameObject buttonOff;
    public GameObject buttonOn;
    public bool flag;

    void Start()
    {
        flag = false;
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            buttonOff.SetActive(false);
            buttonOn.SetActive(true);
            flag = true;
        }
    }
}
