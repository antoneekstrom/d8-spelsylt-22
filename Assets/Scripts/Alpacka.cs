using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(RandomWalk), typeof(Collider2D))]
public class Alpacka : MonoBehaviour
{
    private RandomWalk randomWalk;
    private Interactable interactable;
    private new Collider2D collider;
    private Rigidbody2D rb;

    private bool isCarried = false;

    public float fleeTime = 2;
    public float fleeSpeed = 4;
    public Vector2 fleeDirection;
    private bool isScared = false;
    private float timeUntilNotScared = 0;


    private void Awake()
    {
        randomWalk = GetComponent<RandomWalk>();
        collider = GetComponent<Collider2D>();
        interactable = GetComponent<Interactable>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        timeUntilNotScared += Time.deltaTime;
        if (isScared &&  timeUntilNotScared > fleeTime)
        {
            timeUntilNotScared = 0;
            isScared = false;
            randomWalk.enabled = true;
        }
    }

    private void FixedUpdate()
    {
        if (isScared)
        {
            rb.MovePosition(rb.position + fleeSpeed * Time.fixedDeltaTime * fleeDirection);
        }
    }

    public void Carry(AlpackaFarmer farmer)
    {
        transform.position = farmer.transform.position;
        transform.SetParent(farmer.transform);
        collider.enabled = false;
        randomWalk.enabled = false;
        Destroy(interactable);
        isCarried = true;
    }

    public void Uncarry()
    {
        transform.SetParent(null);
        collider.enabled = true;
        randomWalk.enabled = true;
        isCarried = false;
    }

    public void Scare(Vector2 pos)
    {
        if (!isScared)
        {
            fleeDirection = ((Vector2)transform.position - pos).normalized;
            randomWalk.enabled = false;
            isScared = true;
            print("Alpacka is scared");
        }
    }
}
