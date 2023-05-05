using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLayer : MonoBehaviour
{
    public bool isStatic = false;
    public float offset = 0;
    private int sortingOrder = 0;
    private new Renderer renderer;

    private void Awake()
    {
        renderer = GetComponent<Renderer>();

    }
    private void LateUpdate()
    {
        renderer.sortingOrder = (int)(sortingOrder - transform.position.y + offset);
        if (isStatic)
        {
            Destroy(this);
        }
    }
}
