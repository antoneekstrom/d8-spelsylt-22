using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animation : MonoBehaviour
{
    private Animator a;
    private Rigidbody2D rb;
    private Transform tr;
    void Start()
    {
        a = GetComponent<Animator>();
        rb = GetComponentInParent<Rigidbody2D>();
        tr = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        a.SetFloat("Speed", rb.velocity.magnitude);
        if (rb.velocity.x > 0.05)
        {
            tr.localScale = new Vector3(-1, 1, 1);
        }
        else if(rb.velocity.x < -0.05)
        {
            tr.localScale = new Vector3(1, 1, 1);
        }
    }
}
