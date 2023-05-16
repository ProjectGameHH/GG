using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportTo2Location : MonoBehaviour
{
    public Transform point;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            other.transform.position = point.transform.position;
        }
    }
}
