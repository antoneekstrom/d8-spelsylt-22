using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animation : MonoBehaviour
{
    private Animator a;
    private Rigidbody2D rb;
    private Transform tr;
    private bool isFacingLeft = true;
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
        a.SetFloat("SpeedY", rb.velocity.y);
        if (rb.velocity.x > 0.05 && isFacingLeft)
        {
            turn();
        }
        else if(rb.velocity.x < -0.05 && !isFacingLeft)
        {
            turn();
        }
    }

    private void turn()
    {
        tr.localScale = new Vector3(tr.localScale.x * -1, tr.localScale.y, tr.localScale.z);
        isFacingLeft = !isFacingLeft;
    } 
}
