using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionWithButtons : MonoBehaviour
{

    public GameObject doorClosed;
    public GameObject doorOpened;
    public GameObject buttonOff;
    private GameObject player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        if (buttonOff.GetComponent<flag>())
        {
            doorClosed.SetActive(false);
            doorOpened.SetActive(true);
        }
    }

}
