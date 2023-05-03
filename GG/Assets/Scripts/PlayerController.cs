using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb;
    private Vector2 direction;
    public Animator animator;
    private GameObject sprite1;
    private GameObject sprite2;
    public static Vector2 negativeInfinity;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite1 = GameObject.Find("SpriteWalkUp");
        sprite2 = GameObject.Find("SpriteIdle");
        sprite1.GetComponent<Renderer>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        direction.x = Input.GetAxisRaw("Horizontal");
        direction.y = Input.GetAxisRaw("Vertical");

        if (direction == negativeInfinity)
        {
            sprite1.GetComponent<Renderer>().enabled = false;
            sprite2.GetComponent<Renderer>().enabled = true;
        }
        else
        {
            sprite1.GetComponent<Renderer>().enabled = true;
            sprite2.GetComponent<Renderer>().enabled = false;
        }

        animator.SetFloat("Horizontal", direction.x);
        animator.SetFloat("Vertical", direction.y);
        animator.SetFloat("Speed", direction.sqrMagnitude);
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + direction * speed * Time.fixedDeltaTime);
    }
}
